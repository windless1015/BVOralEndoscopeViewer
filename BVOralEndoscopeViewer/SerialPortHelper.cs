using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace BVOralEndoscopeViewer
{
    //类外
    public delegate void SerialPortCmdRecvHandler(string cmd);

    class SerialPortHelper
    {
        public SerialPort comPortDevice = null;
        string[] AllPortNamesList;
        bool isFindDeviceFlag = false; //是否找到我们要的串口设备

        //声明事件本身,使用event关键字
        public event SerialPortCmdRecvHandler SerialPortCmdRecv;

        public SerialPortHelper()
        {
            comPortDevice = new SerialPort();//构造串口设备
            AllPortNamesList = SerialPort.GetPortNames();//获取当前系统中所有串口的名字,例如COM1, COM3
            comPortDevice.DataReceived += ComPortDevice_DataReceived;
        }
        ~SerialPortHelper()
        {
            if (comPortDevice.IsOpen)
            {
                comPortDevice.Close();
            }
        }

        private void ComPortDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comDeviceInstance = (SerialPort)sender;
            byte[] RecvDataBytes = new byte[comDeviceInstance.BytesToRead];
            comDeviceInstance.Read(RecvDataBytes, 0, RecvDataBytes.Length);//读取数据
            if (isFindDeviceFlag) //进入正常指令接受的阶段,大部分是在这个阶段
            {
                string recvCmdString = StringOperator.ByteArrayToString(ref RecvDataBytes);
                SerialPortCmdRecv(recvCmdString);//接受到下位机的指令触发事件,通知外界
            }
            else //进入寻找设备的阶段
            {
                byte[] TargetCmdBytes = new byte[] { 0x01, 0x01, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00 };
                if (StringOperator.CompareByteArraysEqual(ref RecvDataBytes, ref TargetCmdBytes))
                {
                    isFindDeviceFlag = true;
                }
            }
        }

        public bool FindDevice()
        {
            //遍历所有串口,向每一个串口发送心跳指令11001400, 串口如果收到11110000表示找到目标设备
            foreach (string comName in AllPortNamesList)
            {
                string heartBeatCommand = "11011400";
                InitPort(comName); //先打开设备
                if (comPortDevice.IsOpen)
                {
                    byte[] CmdBytes = StringOperator.ConvertStringToHEXByte(heartBeatCommand);
                    comPortDevice.Write(CmdBytes, 0, CmdBytes.Length);
                    Thread.Sleep(80);//等待接受数据判断isFindDeviceFlag
                    if (!isFindDeviceFlag)
                    {
                        comPortDevice.Close(); //没有收到回复需要关闭这个串口
                    }
                    else  //找到目标串口就返回true
                    {
                        return true;                
                    }
                }
            }
            return false;
        }

        private void InitPort(string comName)
        {
            if (comPortDevice.IsOpen)
            {
                comPortDevice.Close();
            }
            comPortDevice.PortName = comName;
            comPortDevice.BaudRate = 115200;
            comPortDevice.Parity = Parity.None;
            comPortDevice.DataBits = 8;
            comPortDevice.StopBits = StopBits.One;
            comPortDevice.Open();
        }

    }
}
