namespace BVOralEndoscopeViewer
{
    partial class VideoCaptureWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoCaptureWindow));
            this.toolStrip_Icons = new System.Windows.Forms.ToolStrip();
            this.MicroLensModeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NormalModeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FigureModeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_Btns = new System.Windows.Forms.ToolStrip();
            this.ToolStripComboBoxResolution = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SnapshotBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RecordingBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.listView_browse = new System.Windows.Forms.ListView();
            this.videoPlayerHelper = new BVOralEndoscopeViewer.VideoPlayerHelper();
            this.toolStrip_Icons.SuspendLayout();
            this.toolStrip_Btns.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Icons
            // 
            this.toolStrip_Icons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MicroLensModeBtn,
            this.toolStripSeparator1,
            this.NormalModeBtn,
            this.toolStripSeparator2,
            this.FigureModeBtn});
            this.toolStrip_Icons.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Icons.Name = "toolStrip_Icons";
            this.toolStrip_Icons.Size = new System.Drawing.Size(1106, 25);
            this.toolStrip_Icons.TabIndex = 0;
            this.toolStrip_Icons.Text = "toolStrip1";
            // 
            // MicroLensModeBtn
            // 
            this.MicroLensModeBtn.AutoSize = false;
            this.MicroLensModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MicroLensModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MicroLensModeBtn.Name = "MicroLensModeBtn";
            this.MicroLensModeBtn.Size = new System.Drawing.Size(100, 22);
            this.MicroLensModeBtn.Tag = "0";
            this.MicroLensModeBtn.Text = "微距模式";
            this.MicroLensModeBtn.ToolTipText = "微距模式";
            this.MicroLensModeBtn.Click += new System.EventHandler(this.ModeBtns_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // NormalModeBtn
            // 
            this.NormalModeBtn.AutoSize = false;
            this.NormalModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NormalModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("NormalModeBtn.Image")));
            this.NormalModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NormalModeBtn.Name = "NormalModeBtn";
            this.NormalModeBtn.Size = new System.Drawing.Size(100, 22);
            this.NormalModeBtn.Tag = "1";
            this.NormalModeBtn.Text = "一般模式";
            this.NormalModeBtn.Click += new System.EventHandler(this.ModeBtns_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // FigureModeBtn
            // 
            this.FigureModeBtn.AutoSize = false;
            this.FigureModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FigureModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("FigureModeBtn.Image")));
            this.FigureModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FigureModeBtn.Name = "FigureModeBtn";
            this.FigureModeBtn.Size = new System.Drawing.Size(100, 22);
            this.FigureModeBtn.Tag = "2";
            this.FigureModeBtn.Text = "人像模式";
            this.FigureModeBtn.Click += new System.EventHandler(this.ModeBtns_Click);
            // 
            // toolStrip_Btns
            // 
            this.toolStrip_Btns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBoxResolution,
            this.toolStripSeparator3,
            this.SnapshotBtn,
            this.toolStripSeparator4,
            this.RecordingBtn,
            this.toolStripSeparator5,
            this.SettingBtn});
            this.toolStrip_Btns.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_Btns.Name = "toolStrip_Btns";
            this.toolStrip_Btns.Size = new System.Drawing.Size(1106, 25);
            this.toolStrip_Btns.TabIndex = 1;
            this.toolStrip_Btns.Text = "toolStrip1";
            // 
            // ToolStripComboBoxResolution
            // 
            this.ToolStripComboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBoxResolution.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ToolStripComboBoxResolution.Name = "ToolStripComboBoxResolution";
            this.ToolStripComboBoxResolution.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SnapshotBtn
            // 
            this.SnapshotBtn.AutoSize = false;
            this.SnapshotBtn.AutoToolTip = false;
            this.SnapshotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SnapshotBtn.Image = ((System.Drawing.Image)(resources.GetObject("SnapshotBtn.Image")));
            this.SnapshotBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SnapshotBtn.Name = "SnapshotBtn";
            this.SnapshotBtn.Size = new System.Drawing.Size(100, 22);
            this.SnapshotBtn.Text = "拍照";
            this.SnapshotBtn.Click += new System.EventHandler(this.SnapshotBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RecordingBtn
            // 
            this.RecordingBtn.AutoSize = false;
            this.RecordingBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RecordingBtn.Image = ((System.Drawing.Image)(resources.GetObject("RecordingBtn.Image")));
            this.RecordingBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RecordingBtn.Name = "RecordingBtn";
            this.RecordingBtn.Size = new System.Drawing.Size(100, 22);
            this.RecordingBtn.Text = "录像";
            this.RecordingBtn.Click += new System.EventHandler(this.RecordingBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // SettingBtn
            // 
            this.SettingBtn.AutoSize = false;
            this.SettingBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SettingBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingBtn.Image")));
            this.SettingBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(100, 22);
            this.SettingBtn.Text = "设置";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 610);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1106, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // listView_browse
            // 
            this.listView_browse.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView_browse.HideSelection = false;
            this.listView_browse.Location = new System.Drawing.Point(880, 50);
            this.listView_browse.Name = "listView_browse";
            this.listView_browse.Size = new System.Drawing.Size(226, 560);
            this.listView_browse.TabIndex = 4;
            this.listView_browse.UseCompatibleStateImageBehavior = false;
            this.listView_browse.DoubleClick += new System.EventHandler(this.ListView_browse_DoubleClick);
            // 
            // videoPlayerHelper
            // 
            this.videoPlayerHelper.AutoSize = true;
            this.videoPlayerHelper.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoPlayerHelper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerHelper.Location = new System.Drawing.Point(0, 50);
            this.videoPlayerHelper.Name = "videoPlayerHelper";
            this.videoPlayerHelper.Size = new System.Drawing.Size(1106, 582);
            this.videoPlayerHelper.TabIndex = 2;
            this.videoPlayerHelper.videoType = BVOralEndoscopeViewer.VideoStreamType.NO_VIDEO;
            // 
            // VideoCaptureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 632);
            this.Controls.Add(this.listView_browse);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.videoPlayerHelper);
            this.Controls.Add(this.toolStrip_Btns);
            this.Controls.Add(this.toolStrip_Icons);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VideoCaptureWindow";
            this.ShowIcon = false;
            this.Text = "影像采集";
            this.Load += new System.EventHandler(this.VideoCaptureWindow_Load);
            this.toolStrip_Icons.ResumeLayout(false);
            this.toolStrip_Icons.PerformLayout();
            this.toolStrip_Btns.ResumeLayout(false);
            this.toolStrip_Btns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Icons;
        private System.Windows.Forms.ToolStripButton MicroLensModeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton NormalModeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton FigureModeBtn;
        private System.Windows.Forms.ToolStrip toolStrip_Btns;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxResolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton SnapshotBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton RecordingBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton SettingBtn;
        private VideoPlayerHelper videoPlayerHelper;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListView listView_browse;
    }
}

