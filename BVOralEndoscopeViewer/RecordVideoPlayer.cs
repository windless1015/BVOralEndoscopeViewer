using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVOralEndoscopeViewer
{
    public partial class RecordVideoPlayer : Form
    {
        public string videoFilePath { get; set; }
        private string totalTime;

        public delegate void UpdateControlsDelegate(); //Execute when video loads
        public RecordVideoPlayer()
        {
            InitializeComponent();
            trackBar_play.Minimum = 0;
        }

        public void SetMedia(string videoPath)
        {
            vlcControl.VlcMediaPlayer.SetMedia(new FileInfo(videoPath));
            videoFilePath = videoPath;
        }

        public void Play()
        {
            vlcControl.Play();
        }

        public void Stop()
        {
            vlcControl.Stop();
        }


        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "暂停")
            {
                vlcControl.Pause();
                btnPause.Text = "播放";
            }
            else if (btnPause.Text == "播放")
            {
                btnPause.Text = "暂停";
                if (vlcControl.IsPlaying)
                {
                    vlcControl.Pause();
                }
                else
                {
                    vlcControl.VlcMediaPlayer.SetMedia(new FileInfo(videoFilePath));
                    trackBar_play.Value = 0;
                    vlcControl.Play();
                }
            }
            
        }



        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void trackBar_play_Scroll(object sender, EventArgs e)
        {
            vlcControl.VlcMediaPlayer.Time = trackBar_play.Value * 1000;
        }

        private void trackBar_play_ValueChanged(object sender, EventArgs e)
        {
            var position = (float)(trackBar_play.Value * 1.0 / trackBar_play.Maximum);
            vlcControl.Position = position;
        }

        private void RecordVideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlcControl.Stop();
            e.Cancel = true; //不真正关闭窗体,仅仅是隐藏
            this.Hide();
        }

        private void vlcControl_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            InvokeUpdateControls();
        }

        public void InvokeUpdateControls()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsDelegate(currentTrackTime));
            }
            else
            {
                currentTrackTime();
            }
        }

        private void currentTrackTime()
        {
            trackBar_play.Value = (int)vlcControl.VlcMediaPlayer.Time / 1000;
        }

        //Event handler for setting trackBar1.Maximum on media load
        private void vlcControl_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            Invoke(new Action(() =>
            {
                var vlc = (Vlc.DotNet.Forms.VlcControl)sender;
                trackBar_play.Maximum = (int)vlc.Length / 1000;
            }));
        }

        private void vlcControl_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e)
        {
            totalTime = TimeSpan.FromMilliseconds(e.NewLength).ToString(@"hh\:mm\:ss");
        }

        private void vlcControl_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                label_progress.Text = TimeSpan.FromMilliseconds(e.NewTime).ToString(@"hh\:mm\:ss") + " / " + totalTime;
            }));
        }

        private void vlcControl_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                btnPause.Text = "播放";
                
            }));
        }

        private void vlcControl_Paused(object sender, Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs e)
        {
            //Invoke(new Action(() =>
            //{
            //    btnPause.Text = "播放";
            //}));
        }
    }
}
