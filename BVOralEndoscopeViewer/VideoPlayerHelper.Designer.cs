namespace BVOralEndoscopeViewer
{
    partial class VideoPlayerHelper
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PicBox_DisplayImg = new Accord.Controls.PictureBox();
            this.VideoSourcePlayer = new Accord.Controls.VideoSourcePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_DisplayImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBox_DisplayImg
            // 
            this.PicBox_DisplayImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBox_DisplayImg.Image = null;
            this.PicBox_DisplayImg.Location = new System.Drawing.Point(0, 0);
            this.PicBox_DisplayImg.Margin = new System.Windows.Forms.Padding(4);
            this.PicBox_DisplayImg.Name = "PicBox_DisplayImg";
            this.PicBox_DisplayImg.Size = new System.Drawing.Size(361, 248);
            this.PicBox_DisplayImg.TabIndex = 0;
            this.PicBox_DisplayImg.TabStop = false;
            // 
            // VideoSourcePlayer
            // 
            this.VideoSourcePlayer.AutoSizeControl = true;
            this.VideoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VideoSourcePlayer.BorderColor = System.Drawing.Color.Transparent;
            this.VideoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoSourcePlayer.KeepAspectRatio = true;
            this.VideoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.VideoSourcePlayer.Margin = new System.Windows.Forms.Padding(4);
            this.VideoSourcePlayer.Name = "VideoSourcePlayer";
            this.VideoSourcePlayer.Size = new System.Drawing.Size(361, 248);
            this.VideoSourcePlayer.TabIndex = 1;
            this.VideoSourcePlayer.VideoSource = null;
            this.VideoSourcePlayer.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayer_NewFrame);
            // 
            // VideoPlayerHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VideoSourcePlayer);
            this.Controls.Add(this.PicBox_DisplayImg);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoPlayerHelper";
            this.Size = new System.Drawing.Size(361, 248);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_DisplayImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Accord.Controls.PictureBox PicBox_DisplayImg;
        private Accord.Controls.VideoSourcePlayer VideoSourcePlayer;
    }
}
