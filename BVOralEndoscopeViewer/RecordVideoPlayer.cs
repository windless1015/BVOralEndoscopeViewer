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
        public RecordVideoPlayer()
        {
            InitializeComponent();
            trackBar_play.Minimum = 0;
            trackBar_play.Maximum = 1000;

        }
        public void Play()
        {
            vlcControl.Play(new FileInfo(videoFilePath));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            vlcControl.Play(new FileInfo(videoFilePath));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

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

        }

        private void trackBar_play_ValueChanged(object sender, EventArgs e)
        {
            var position = (float)(trackBar_play.Value *1.0 / trackBar_play.Maximum);
            vlcControl.Position = position;
        }
    }
}
