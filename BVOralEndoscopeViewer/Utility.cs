using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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
    }
}
