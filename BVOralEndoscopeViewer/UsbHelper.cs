using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using LibUsbDotNet.DeviceNotify;

namespace BVOralEndoscopeViewer
{
    class UsbHelper
    {
        private UsbDevice MyUsbDevice;
        private IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
        private UsbEndpointWriter writer;
        private UsbEndpointReader reader;

        public bool OpenDevice(int vid, int pid)
        {
            UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(vid, pid);
            UsbRegDeviceList DeviceList = UsbDevice.AllLibUsbDevices;
            UsbRegistry RegInfo = DeviceList.Find(myUsbFinder);
            if (RegInfo != null)
            {
                MyUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);
            }
            return true;
             
        }
    }
}
