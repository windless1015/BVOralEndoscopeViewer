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

namespace BVOralEndoscopeViewer
{
    public partial class VideoCaptureWindow : Form
    {

        private SynchronizationContext syncContext = null;
        private SerialPortHelper serialDevice = null;
        public VideoCaptureWindow()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;
        }

        private void VideoCaptureWindow_Load(object sender, EventArgs e)
        {
            serialDevice = new SerialPortHelper();
            bool isFindDevice = serialDevice.FindDevice();
            serialDevice.SerialPortCmdRecv += new SerialPortCmdRecvHandler(CmdRecvHandle);
            
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
