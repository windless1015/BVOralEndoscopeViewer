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

namespace BVOralEndoscopeViewer
{
    public enum VideoStreamType
    {
        USB = 0,
        WIFI = 1,
        NO_VIDEO = 2
    }

    public partial class VideoPlayerHelper : UserControl
    {
        public VideoPlayerHelper()
        {
            InitializeComponent();
            videoStreamSource = null;
            videoType = VideoStreamType.NO_VIDEO;
            deviceMonikerString = null;
        }

        //视频流, 接口类定义,可以是设备的视频流,也可以是mjpeg的视频流
        private IVideoSource videoStreamSource { get; set; }
        //视频数据类型, WIFI 和 USB
        public VideoStreamType videoType { get; set; }
        //视频的名字字符串
        private string deviceMonikerString { get; set; }


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
            if (deviceMonikerString == null)
                return;
            //先关闭

            if (videoType == VideoStreamType.USB)
            {
                videoStreamSource = new VideoCaptureDevice(deviceMonikerString);
                VideoCapabilities[] videoCapabilities = ((VideoCaptureDevice)videoStreamSource).VideoCapabilities;
                ((VideoCaptureDevice)videoStreamSource).VideoResolution = videoCapabilities[0];
                ((VideoCaptureDevice)videoStreamSource).SnapshotResolution = videoCapabilities[0];
            }
            else if (videoType == VideoStreamType.WIFI)
            {
                videoStreamSource = new MJPEGStream(deviceMonikerString);
            }
            VideoSourcePlayer.VideoSource = videoStreamSource;
            VideoSourcePlayer.Start();
            
        }

    }
}
