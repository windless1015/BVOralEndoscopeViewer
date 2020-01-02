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
    public partial class VideoCaptureWindow : Form
    {

        private SynchronizationContext syncContext = null;
        private SerialPortHelper serialDevice = null;
        private SimpleTcpClient socketClient = null;
        public VideoCaptureWindow()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;
        }

        private void VideoCaptureWindow_Load(object sender, EventArgs e)
        {
            //需要根据设备类型进行new不同的通信方式
            serialDevice = new SerialPortHelper();
            bool isFindDevice = serialDevice.FindDevice();
            //serialDevice.SerialPortCmdRecv += new SerialPortCmdRecvHandler(CmdRecvHandle);
            serialDevice.SerialPortCmdRecv += CmdRecvHandle;

            socketClient = new SimpleTcpClient().Connect("10.10.10.254", 3333);
            socketClient.DataReceived += SocketClient_DataReceived;

            /*
             string sendCMD = "{\n\t\"mcucmd\":\t\"0104000100060000\"\n}";
            socketClient.WriteLineAndGetReply(sendCMD, TimeSpan.FromSeconds(1));
             */
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
                MicroLensFlg = true; NormalFlg = false; FigureFlg = false;
            }
            else if (cmd == "14000500") //一般模式
            {
                MicroLensFlg = false; NormalFlg = true; FigureFlg = false;
            }
            else if (cmd == "2A000C00")//人像模式
            {
                MicroLensFlg = false; NormalFlg = false; FigureFlg = true;
            }

            Action actionDelegate = () =>
            {
                MicroLensModeBtn.Checked = MicroLensFlg;
                NormalModeBtn.Checked = NormalFlg;
                FigureModeBtn.Checked = FigureFlg;
            };
            //上述三个按钮的父控件便是ToolStrip_Icons,所以直接从它进行Invoke
            ToolStrip_Icons.Invoke(actionDelegate); 
        }

        private void TakePhoto(object obj)
        {

        }


        

    }
}
