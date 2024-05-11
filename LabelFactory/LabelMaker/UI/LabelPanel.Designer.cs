namespace LabelMaker
{
    partial class LabelPanel
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
            this.PicLabel = new System.Windows.Forms.PictureBox();
            this.GrpStatus = new System.Windows.Forms.GroupBox();
            this.ChkConnStatus = new System.Windows.Forms.CheckBox();
            this.ChkHeaderUp = new System.Windows.Forms.CheckBox();
            this.ChkPause = new System.Windows.Forms.CheckBox();
            this.ChkRibbon = new System.Windows.Forms.CheckBox();
            this.ChkPaper = new System.Windows.Forms.CheckBox();
            this.ChkRes = new System.Windows.Forms.CheckBox();
            this.ChkReq = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicLabel)).BeginInit();
            this.GrpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicLabel
            // 
            this.PicLabel.BackColor = System.Drawing.Color.White;
            this.PicLabel.Location = new System.Drawing.Point(0, 64);
            this.PicLabel.Name = "PicLabel";
            this.PicLabel.Size = new System.Drawing.Size(609, 507);
            this.PicLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicLabel.TabIndex = 0;
            this.PicLabel.TabStop = false;
            // 
            // GrpStatus
            // 
            this.GrpStatus.Controls.Add(this.ChkConnStatus);
            this.GrpStatus.Controls.Add(this.ChkHeaderUp);
            this.GrpStatus.Controls.Add(this.ChkPause);
            this.GrpStatus.Controls.Add(this.ChkRibbon);
            this.GrpStatus.Controls.Add(this.ChkPaper);
            this.GrpStatus.Controls.Add(this.ChkRes);
            this.GrpStatus.Controls.Add(this.ChkReq);
            this.GrpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpStatus.Location = new System.Drawing.Point(0, 0);
            this.GrpStatus.Name = "GrpStatus";
            this.GrpStatus.Size = new System.Drawing.Size(609, 58);
            this.GrpStatus.TabIndex = 1;
            this.GrpStatus.TabStop = false;
            // 
            // ChkConnStatus
            // 
            this.ChkConnStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkConnStatus.Location = new System.Drawing.Point(176, 20);
            this.ChkConnStatus.Name = "ChkConnStatus";
            this.ChkConnStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkConnStatus.TabIndex = 6;
            this.ChkConnStatus.Text = "通讯状态";
            this.ChkConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkConnStatus.UseVisualStyleBackColor = true;
            this.ChkConnStatus.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkHeaderUp
            // 
            this.ChkHeaderUp.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkHeaderUp.Location = new System.Drawing.Point(520, 20);
            this.ChkHeaderUp.Name = "ChkHeaderUp";
            this.ChkHeaderUp.Size = new System.Drawing.Size(80, 24);
            this.ChkHeaderUp.TabIndex = 5;
            this.ChkHeaderUp.Text = "打印头抬起";
            this.ChkHeaderUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkHeaderUp.UseVisualStyleBackColor = true;
            this.ChkHeaderUp.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkPause
            // 
            this.ChkPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPause.Location = new System.Drawing.Point(262, 20);
            this.ChkPause.Name = "ChkPause";
            this.ChkPause.Size = new System.Drawing.Size(80, 24);
            this.ChkPause.TabIndex = 4;
            this.ChkPause.Text = "暂停";
            this.ChkPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkPause.UseVisualStyleBackColor = true;
            this.ChkPause.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkRibbon
            // 
            this.ChkRibbon.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkRibbon.Location = new System.Drawing.Point(434, 20);
            this.ChkRibbon.Name = "ChkRibbon";
            this.ChkRibbon.Size = new System.Drawing.Size(80, 24);
            this.ChkRibbon.TabIndex = 3;
            this.ChkRibbon.Text = "色带";
            this.ChkRibbon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkRibbon.UseVisualStyleBackColor = true;
            this.ChkRibbon.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkPaper
            // 
            this.ChkPaper.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPaper.Location = new System.Drawing.Point(348, 20);
            this.ChkPaper.Name = "ChkPaper";
            this.ChkPaper.Size = new System.Drawing.Size(80, 24);
            this.ChkPaper.TabIndex = 2;
            this.ChkPaper.Text = "标签纸";
            this.ChkPaper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkPaper.UseVisualStyleBackColor = true;
            this.ChkPaper.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkRes
            // 
            this.ChkRes.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkRes.Location = new System.Drawing.Point(92, 20);
            this.ChkRes.Name = "ChkRes";
            this.ChkRes.Size = new System.Drawing.Size(80, 24);
            this.ChkRes.TabIndex = 1;
            this.ChkRes.Text = "打印响应";
            this.ChkRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkRes.UseVisualStyleBackColor = true;
            this.ChkRes.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // ChkReq
            // 
            this.ChkReq.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkReq.Location = new System.Drawing.Point(6, 20);
            this.ChkReq.Name = "ChkReq";
            this.ChkReq.Size = new System.Drawing.Size(80, 24);
            this.ChkReq.TabIndex = 0;
            this.ChkReq.Text = "打印请求";
            this.ChkReq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkReq.UseVisualStyleBackColor = true;
            this.ChkReq.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // LabelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpStatus);
            this.Controls.Add(this.PicLabel);
            this.Name = "LabelPanel";
            this.Size = new System.Drawing.Size(609, 571);
            ((System.ComponentModel.ISupportInitialize)(this.PicLabel)).EndInit();
            this.GrpStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicLabel;
        private System.Windows.Forms.GroupBox GrpStatus;
        private System.Windows.Forms.CheckBox ChkReq;
        private System.Windows.Forms.CheckBox ChkHeaderUp;
        private System.Windows.Forms.CheckBox ChkPause;
        private System.Windows.Forms.CheckBox ChkRibbon;
        private System.Windows.Forms.CheckBox ChkPaper;
        private System.Windows.Forms.CheckBox ChkRes;
        private System.Windows.Forms.CheckBox ChkConnStatus;
    }
}
