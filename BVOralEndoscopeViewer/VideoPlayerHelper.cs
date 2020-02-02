using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;

namespace BVOralEndoscopeViewer
{
    public enum VideoStreamType
    {
        USB = 0,
        WIFI = 1,
        LOCAL_FILE = 2,
        NO_VIDEO = 3
    }
    public partial class VideoPlayerHelper : UserControl
    {
        //视频流, 接口类定义,可以是设备的视频流,也可以是mjpeg的视频流
        private IVideoSource videoStreamSource { get; set; }
        //视频数据类型, WIFI 和 USB
        public VideoStreamType videoType { get; set; }
        //视频的名字字符串
        private string deviceMonikerString { get; set; }
        //当前是否显示的是截图
        public bool IsCurSnapshot { get; set; }
        public Bitmap frame { get; set; }

        public event NewFrameGeneratedHandler NewFrameGenerated;
        public VideoPlayerHelper()
        {
            InitializeComponent();
            //把picturebox的显示图片模式设置为铺满模式
            PicBox_DisplayImg.SizeMode = PictureBoxSizeMode.StretchImage;
            videoStreamSource = null;
            videoType = VideoStreamType.NO_VIDEO;
            deviceMonikerString = null;
            IsCurSnapshot = false;

        }

        //判断视频的类型,usb或者wifi
        public void CheckVideoType()
        {
            //先判断usb连接的情况
            deviceMonikerString = Utility.GetUSBCameraMonikerString();
            if (deviceMonikerString != null)
            {
                videoType = VideoStreamType.USB;
                return;
            }
            //再判断wifi情况下设备是否连通
            bool isWIFIConnected = Utility.IsDeviceNetworkConnected("10.10.10.254");
            if (isWIFIConnected)
            {
                deviceMonikerString = "http://10.10.10.254:8080";
                videoType = VideoStreamType.WIFI;
                return;
            }

        }

        public void OpenVideoSource()
        {
            videoStreamSource = null;
            //把picturebox放在后面,把videosoureplayer放在前面
            PicBox_DisplayImg.SendToBack();
            VideoSourcePlayer.BringToFront();
            if (deviceMonikerString == null)
                return;
            //先关闭
            switch (videoType)
            {
                case VideoStreamType.USB:
                    videoStreamSource = new VideoCaptureDevice(deviceMonikerString);
                    VideoCapabilities[] videoCapabilities = ((VideoCaptureDevice)videoStreamSource).VideoCapabilities;
                    ((VideoCaptureDevice)videoStreamSource).VideoResolution = videoCapabilities[0];
                    ((VideoCaptureDevice)videoStreamSource).SnapshotResolution = videoCapabilities[0];
                    //设置帧大小
                    frame = new Bitmap(videoCapabilities[0].FrameSize.Width, videoCapabilities[0].FrameSize.Height);
                    break;
                case VideoStreamType.WIFI:
                    videoStreamSource = new MJPEGStream(deviceMonikerString);
                    frame = new Bitmap(1280, 720);
                    break;
                case VideoStreamType.LOCAL_FILE:
                    videoStreamSource = new VideoFileSource(deviceMonikerString);
                    frame = new Bitmap(1280, 720);
                    break;
                default:
                    break;
            }
            VideoSourcePlayer.VideoSource = videoStreamSource;
            VideoSourcePlayer.Start();
            IsCurSnapshot = false;
        }

        public void CloseVideoSource()
        {
            if (videoStreamSource != null)
            {
                frame.Dispose();
                videoStreamSource.SignalToStop();
                videoStreamSource.Stop();
            }
        }

        public void DisplaySnapshot(ref Bitmap curFrame)
        {
            PicBox_DisplayImg.BringToFront();
            VideoSourcePlayer.SendToBack();
            lock (curFrame) 
            {
                PicBox_DisplayImg.Image = curFrame;
            }
            IsCurSnapshot = true;
            PicBox_DisplayImg.Show();
        }

        public void PlayVideoFile(ref string path)
        {
            CloseVideoSource();
            //PicBox_DisplayImg.SendToBack();
            //VideoSourcePlayer.BringToFront();
            deviceMonikerString = path;
            videoType = VideoStreamType.LOCAL_FILE;
            OpenVideoSource();
        }


        public void ResumeVideo()
        {
            PicBox_DisplayImg.SendToBack();
            VideoSourcePlayer.BringToFront();
            IsCurSnapshot = false;
        }

        public void ShowImageOrVideo(string absPath, string extension)
        {
            if (extension == "jpeg" || extension == "jpg")
            {
                Image img = Image.FromFile(absPath);
                Bitmap bm = new Bitmap(img);
                DisplaySnapshot(ref bm);
            }
            else if (extension == "avi" || extension == "mp4")
            {
                //PlayVideoFile(ref absPath);
                RecordVideoPlayer recordPlayer = new RecordVideoPlayer();
                recordPlayer.videoFilePath = absPath;
                recordPlayer.Show();
                recordPlayer.Play();
            }
        }

        private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            //frame = (Bitmap)image.Clone();//深拷贝

        }

        public delegate void NewFrameGeneratedHandler(object sender, ref Bitmap image);

    }
}
