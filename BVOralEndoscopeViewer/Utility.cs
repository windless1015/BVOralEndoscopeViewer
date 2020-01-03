using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Accord.Video.DirectShow;

namespace BVOralEndoscopeViewer
{
    public class Utility
    {
        //判断与目标设备网络是否连通
        public static bool IsDeviceNetworkConnected(string ip)
        {
            Ping p = new Ping();
            int timeout = 50; // Timeout 时间，单位：毫秒
            PingReply reply = p.Send(ip, timeout);
            if (reply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }

        public static string GetUSBCameraMonikerString()
        {
            string monikerString = null;
            FilterInfoCollection VideoDevicesCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in VideoDevicesCollection)
            {
                if (item.Name.Equals("SKT-OL400C-13A"))
                {
                    monikerString = item.MonikerString;
                }
            }
            return monikerString;
        }
    }
}
