using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Accord.Video.DirectShow;
using System.IO;
using System.Drawing;

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

        //public static string GetMD5HashFromFile(string fileName)
        // {
        //     try
        //    {
        //        FileStream file = new FileStream(fileName, FileMode.Open);
        //       System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //        byte[] retVal = md5.ComputeHash(file);
        //        file.Close();

        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i<retVal.Length; i++)
        //        {
        //           sb.Append(retVal[i].ToString("x2"));
        //        }
        //        return sb.ToString();
        //   }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
        //     }
        //}

    }
}
