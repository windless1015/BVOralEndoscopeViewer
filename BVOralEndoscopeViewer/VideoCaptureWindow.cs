using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVOralEndoscopeViewer
{
    public partial class VideoCaptureWindow : Form
    {
        private SerialPortHelper serialDevice = null;
        public VideoCaptureWindow()
        {
            InitializeComponent();
        }

        private void VideoCaptureWindow_Load(object sender, EventArgs e)
        {
            serialDevice = new SerialPortHelper();
            serialDevice.SerialPortCmdRecv += new SerialPortCmdRecvHandler(CmdRecvHandle);
            bool isFindDevice = serialDevice.FindDevice();
        }

  

        private void CmdRecvHandle(string cmd)
        {
            string aaa = cmd;
        }
    }
}
