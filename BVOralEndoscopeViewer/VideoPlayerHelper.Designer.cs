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
            this.VideoSourcePlayer = new Accord.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // VideoSourcePlayer
            // 
            this.VideoSourcePlayer.AutoSizeControl = true;
            this.VideoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VideoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoSourcePlayer.KeepAspectRatio = true;
            this.VideoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.VideoSourcePlayer.Name = "VideoSourcePlayer";
            this.VideoSourcePlayer.Size = new System.Drawing.Size(700, 463);
            this.VideoSourcePlayer.TabIndex = 0;
            this.VideoSourcePlayer.Text = "videoSourcePlayer1";
            this.VideoSourcePlayer.VideoSource = null;
            // 
            // VideoPlayerHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VideoSourcePlayer);
            this.Name = "VideoPlayerHelper";
            this.Size = new System.Drawing.Size(700, 463);
            this.ResumeLayout(false);

        }

        #endregion

        private Accord.Controls.VideoSourcePlayer VideoSourcePlayer;
    }
}
