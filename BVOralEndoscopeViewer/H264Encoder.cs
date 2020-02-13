using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NSH264Encoder;
using System.Drawing.Imaging;

namespace BVOralEndoscopeViewer
{
    class NsH264Encoder
    {
        private H264Encoder h264Encoder;
        private bool isRecording = false;
        private Rectangle rect;
        private int imageHeight;
        public void StartRecording(int width,int height)
        {
            if (h264Encoder == null)
            {
                h264Encoder = new H264Encoder();
                h264Encoder.SetupEncode(@"D:\tttttt.mp4", width, height, 30);
                isRecording = true;
                rect = new Rectangle(0, 0, width, height);
                imageHeight = height;
            }
        }

        public void StopRecording()
        {
            if (h264Encoder != null)
            {
                isRecording = false;
                h264Encoder.CloseEncode();
                h264Encoder.Dispose();
                h264Encoder = null;
                
            }
        }

        public void Encode(Bitmap frame)
        {
            if (!isRecording)
                return;
            BitmapData bmpData = frame.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);


            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * imageHeight;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);


            h264Encoder.WriteFrame(rgbValues);
            // Unlock the bits.
            frame.UnlockBits(bmpData);
        }

    }
}
