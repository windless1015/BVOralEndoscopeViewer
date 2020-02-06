using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVOralEndoscopeViewer
{
    class AccordVideoWriter
    {
        private VideoFileWriter videoWriter;
        public bool IsRecording { get; private set; }
        public bool HasRecorded { get; private set; }
        public bool IsPlaying { get; private set; }
        public DateTime RecordingStartTime { get; private set; }
        public string OutputPath { get; private set; }
        public Rectangle CaptureRegion { get; set; }


        public void StartRecording()
        {
            if (IsRecording || !IsPlaying)
                return;

            Rectangle area = CaptureRegion;
            //string fileName = NewFileName();

            int height = area.Height;
            int width = area.Width;
            //Accord.Math.Rational framerate = new Accord.Math.Rational(1000, screenStream.FrameInterval);
            int videoBitRate = 1200 * 1000;

            //OutputPath = Path.Combine(main.CurrentDirectory, fileName);
            RecordingStartTime = DateTime.MinValue;
            //string fileName, int width, int height, Rational frameRate, VideoCodec codec, int bitRate
            //videoWriter = new VideoFileWriter(fileName, width, height, framerate, VideoCodec.H264, videoBitRate);
            //videoWriter = new VideoFileWriter();
            //videoWriter.BitRate = videoBitRate;
            //videoWriter.FrameRate = framerate;
            //videoWriter.Width = width;
            //videoWriter.Height = height;
            //videoWriter.VideoCodec = VideoCodec.H264;
            //videoWriter.VideoOptions["crf"] = "18"; // visually lossless
            //videoWriter.VideoOptions["preset"] = "veryfast";
            //videoWriter.VideoOptions["tune"] = "zerolatency";
            //videoWriter.VideoOptions["x264opts"] = "no-mbtree:sliced-threads:sync-lookahead=0";

            //this.lastFrameTime = DateTime.MinValue;

           // videoWriter.Open(OutputPath);

            HasRecorded = false;
            IsRecording = true;
        }


        public void StopRecording()
        {
            if (!IsRecording)
                return;

            //lock (syncObj)
            {
                IsRecording = false;

                if (videoWriter != null)
                {
                    videoWriter.Close();
                    videoWriter.Dispose();
                    videoWriter = null;
                }

                HasRecorded = true;
            }
        }
    }
}
