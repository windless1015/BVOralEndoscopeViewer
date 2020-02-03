using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimpleTCP;

namespace BVOralEndoscopeViewer
{
    public enum ModeStatus
    {
        MicroLensMode = 0,
        NormalMode = 1,
        FigureMode = 2
    }

    public partial class VideoCaptureWindow : Form
    {

        private SynchronizationContext syncContext = null;
        private SerialPortHelper serialDevice = null;
        private SimpleTcpClient socketClient = null;
        private VideoStreamType videoType = VideoStreamType.NO_VIDEO;
        RecordVideoPlayer recordPlayer = new RecordVideoPlayer();
        
        public VideoCaptureWindow()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;
            //把侧边栏双击的事件绑定到videoPlayerHelper的显示图片和录像视频播放的的委托事件中去.
            imageVideoBrowserSideBar.DisplaySelectedItem += 
                new ImageVideoBrowserSideBar.DisplaySelectedItemHandler(videoPlayerHelper.ShowSnapshot);
            imageVideoBrowserSideBar.DisplaySelectedItem +=
                new ImageVideoBrowserSideBar.DisplaySelectedItemHandler(PlayRecordVideo);
        }

        public void PlayRecordVideo(string absPath, string extension)
        {
            if (extension == "avi" || extension == "mp4")
            {
                recordPlayer.SetMedia(absPath);
                recordPlayer.StartPosition = FormStartPosition.CenterScreen;
                recordPlayer.BringToFront();

                recordPlayer.Show();

                recordPlayer.Play();
                
            }
        }


        ////////////////////////////////界面逻辑事务////////////////////////////////////////////
        private void VideoCaptureWindow_Load(object sender, EventArgs e)
        {
            //设置侧面显示栏的数据路径
            imageVideoBrowserSideBar.FileDataPath = "F:/projects/Bangvo/images";
            imageVideoBrowserSideBar.Reorder();
            return;
            videoPlayerHelper.CheckVideoType();
            videoType = videoPlayerHelper.videoType;
            if (videoType == VideoStreamType.USB)
            {
                //需要根据设备类型进行new不同的通信方式
                serialDevice = new SerialPortHelper();
                bool isFindDevice = serialDevice.FindDevice();
                if (isFindDevice)
                {
                    serialDevice.SerialPortCmdRecv += CmdRecvHandle;
                }
            }
            else if (videoType == VideoStreamType.WIFI)
            {
                socketClient = new SimpleTcpClient();
                socketClient.Connect("10.10.10.254", 3333);
                socketClient.DataReceived += SocketClient_DataReceived;
            }
            videoPlayerHelper.OpenVideoSource();

        }

        private void ModeBtns_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ModeStatus mode = (ModeStatus)(Convert.ToInt32((btn.Tag)));
            //我给三个按钮设置了Tag属性,分别为0,1,2,适用枚举强制类型转换为目标参数
            ProcessModeBtnsClick(mode);
        }


        ///////////////////////////////////////////////////////////////////////////////
        private void ProcessModeBtnsClick(ModeStatus mode)
        {
            //选择对于那个的按钮,
            bool MicroLensFlg = false, NormalFlg = false, FigureFlg = false;
            string cmdStringBody = null;
            switch (mode)
            {
                case ModeStatus.MicroLensMode:
                    MicroLensFlg = true;
                    cmdStringBody = "01010200";
                    break;
                case ModeStatus.NormalMode:
                    NormalFlg = true;
                    cmdStringBody = "14010600";
                    break;
                case ModeStatus.FigureMode:
                    FigureFlg = true;
                    cmdStringBody = "2A010D00";
                    break;
            }
            MicroLensModeBtn.Checked = MicroLensFlg;
            NormalModeBtn.Checked = NormalFlg;
            FigureModeBtn.Checked = FigureFlg;
            //根据当前连接模式发送对应的指令
            if (videoType == VideoStreamType.WIFI)
            {
                string wifiCmdFormat = "{\n\t\"mcucmd\":\t\"" + cmdStringBody + "\"\n}";
                socketClient.WriteLineAndGetReply(wifiCmdFormat, TimeSpan.FromSeconds(1));
            }
            else if (videoType == VideoStreamType.USB)
            {
                serialDevice.WriteCmd(cmdStringBody);
            }
        }


        //接受的数据格式为  "{\n\t\"mcucmd\":\t\"0101010101010101\"\n}"
        private void SocketClient_DataReceived(object sender, SimpleTCP.Message e)
        {
            string socketMsg = e.MessageString;
            socketMsg = socketMsg.Substring(14, 16);//得到0101010101010101
            for (int i = 0; i < 8; i++)
            {
                socketMsg = socketMsg.Remove(i, 1);
            }
            CmdRecvHandle(socketMsg);
        }


        //接受到指令处理逻辑
        private void CmdRecvHandle(string recvCmd)
        {
            
            if (recvCmd == "")//心跳指令
            {

            }
            else if (recvCmd == "02000200") //拍照
            {
                syncContext.Post(TakePhoto, null);
            }
            else if (recvCmd == "11111111") //休眠
            {
                return;
            }
            else
                IconsChangeEvent(ref recvCmd);
        }

        private void IconsChangeEvent(ref string cmd)
        {
            bool MicroLensFlg = false, NormalFlg = false, FigureFlg = false;
            if (cmd == "01000100") //微距模式
            {
                MicroLensFlg = true;
            }
            else if (cmd == "14000500") //一般模式
            {
                NormalFlg = true;
            }
            else if (cmd == "2A000C00")//人像模式
            {
                FigureFlg = true;
            }

            Action actionDelegate = () =>
            {
                MicroLensModeBtn.Checked = MicroLensFlg;
                NormalModeBtn.Checked = NormalFlg;
                FigureModeBtn.Checked = FigureFlg;
            };
            //上述三个按钮的父控件便是ToolStrip_Icons,所以直接从它进行Invoke
            toolStrip_Icons.Invoke(actionDelegate); 
        }

        private void TakePhoto(object obj)
        {
            if (videoPlayerHelper.IsCurSnapshot)
            {
                videoPlayerHelper.ResumeVideo();
            }
            else
            {
                ShowSnapshot();
            }
        }

        private void ShowSnapshot()
        {
            Action action = () => 
            {
                Bitmap bm = new Bitmap(videoPlayerHelper.frame);
                videoPlayerHelper.DisplaySnapshot(ref bm);
            };

            if (videoPlayerHelper.InvokeRequired)
            {
                videoPlayerHelper.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void SnapshotBtn_Click(object sender, EventArgs e)
        {
            if (videoPlayerHelper.IsCurSnapshot)
            {
                videoPlayerHelper.ResumeVideo();
            }
            else
            {
                ShowSnapshot();
            }
        }

        private void RecordingBtn_Click(object sender, EventArgs e)
        {
            
        }

    }
}
