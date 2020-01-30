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
            this.imageVideoBrowserSideBar = new BVOralEndoscopeViewer.ImageVideoBrowserSideBar();
            this.videoPlayerHelper = new BVOralEndoscopeViewer.VideoPlayerHelper();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip_Icons.SuspendLayout();
            this.toolStrip_Btns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Icons
            // 
            this.toolStrip_Icons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Icons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MicroLensModeBtn,
            this.toolStripSeparator1,
            this.NormalModeBtn,
            this.toolStripSeparator2,
            this.FigureModeBtn});
            this.toolStrip_Icons.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Icons.Name = "toolStrip_Icons";
            this.toolStrip_Icons.Size = new System.Drawing.Size(1475, 25);
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
            this.toolStrip_Btns.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStrip_Btns.Size = new System.Drawing.Size(1475, 28);
            this.toolStrip_Btns.TabIndex = 1;
            this.toolStrip_Btns.Text = "toolStrip1";
            // 
            // ToolStripComboBoxResolution
            // 
            this.ToolStripComboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBoxResolution.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ToolStripComboBoxResolution.Name = "ToolStripComboBoxResolution";
            this.ToolStripComboBoxResolution.Size = new System.Drawing.Size(160, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
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
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
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
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
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
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 768);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1475, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // imageVideoBrowserSideBar
            // 
            this.imageVideoBrowserSideBar.AutoSize = true;
            this.imageVideoBrowserSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageVideoBrowserSideBar.FileDataPath = null;
            this.imageVideoBrowserSideBar.Location = new System.Drawing.Point(0, 0);
            this.imageVideoBrowserSideBar.Name = "imageVideoBrowserSideBar";
            this.imageVideoBrowserSideBar.Size = new System.Drawing.Size(271, 715);
            this.imageVideoBrowserSideBar.TabIndex = 4;
            // 
            // videoPlayerHelper
            // 
            this.videoPlayerHelper.AutoSize = true;
            this.videoPlayerHelper.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoPlayerHelper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayerHelper.frame = null;
            this.videoPlayerHelper.IsCurSnapshot = false;
            this.videoPlayerHelper.Location = new System.Drawing.Point(0, 0);
            this.videoPlayerHelper.Margin = new System.Windows.Forms.Padding(5);
            this.videoPlayerHelper.Name = "videoPlayerHelper";
            this.videoPlayerHelper.Size = new System.Drawing.Size(1200, 715);
            this.videoPlayerHelper.TabIndex = 2;
            this.videoPlayerHelper.videoType = BVOralEndoscopeViewer.VideoStreamType.NO_VIDEO;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 53);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.videoPlayerHelper);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.imageVideoBrowserSideBar);
            this.splitContainer.Size = new System.Drawing.Size(1475, 715);
            this.splitContainer.SplitterDistance = 1200;
            this.splitContainer.TabIndex = 5;
            // 
            // VideoCaptureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 790);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip_Btns);
            this.Controls.Add(this.toolStrip_Icons);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VideoCaptureWindow";
            this.ShowIcon = false;
            this.Text = "影像采集";
            this.Load += new System.EventHandler(this.VideoCaptureWindow_Load);
            this.toolStrip_Icons.ResumeLayout(false);
            this.toolStrip_Icons.PerformLayout();
            this.toolStrip_Btns.ResumeLayout(false);
            this.toolStrip_Btns.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
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
        private ImageVideoBrowserSideBar imageVideoBrowserSideBar;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

