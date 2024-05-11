namespace LabelMaker
{
    partial class DevicesStatusPanel
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
            this.ChkSqlStatus = new System.Windows.Forms.CheckBox();
            this.ChkFxStatus = new System.Windows.Forms.CheckBox();
            this.ChkR04CpuStatus = new System.Windows.Forms.CheckBox();
            this.ChkInsideLabelingStatus = new System.Windows.Forms.CheckBox();
            this.ChkOutsideLabelingStatus = new System.Windows.Forms.CheckBox();
            this.GrpDevicesStatus = new System.Windows.Forms.GroupBox();
            this.GrpDevicesStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkSqlStatus
            // 
            this.ChkSqlStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkSqlStatus.Location = new System.Drawing.Point(6, 11);
            this.ChkSqlStatus.Name = "ChkSqlStatus";
            this.ChkSqlStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkSqlStatus.TabIndex = 7;
            this.ChkSqlStatus.Text = "数据库连接";
            this.ChkSqlStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkSqlStatus.UseVisualStyleBackColor = true;
            // 
            // ChkFxStatus
            // 
            this.ChkFxStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkFxStatus.Location = new System.Drawing.Point(92, 11);
            this.ChkFxStatus.Name = "ChkFxStatus";
            this.ChkFxStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkFxStatus.TabIndex = 8;
            this.ChkFxStatus.Text = "Fx5UCPU";
            this.ChkFxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkFxStatus.UseVisualStyleBackColor = true;
            // 
            // ChkR04CpuStatus
            // 
            this.ChkR04CpuStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkR04CpuStatus.Location = new System.Drawing.Point(178, 11);
            this.ChkR04CpuStatus.Name = "ChkR04CpuStatus";
            this.ChkR04CpuStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkR04CpuStatus.TabIndex = 9;
            this.ChkR04CpuStatus.Text = "R04CPU";
            this.ChkR04CpuStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkR04CpuStatus.UseVisualStyleBackColor = true;
            // 
            // ChkInsideLabelingStatus
            // 
            this.ChkInsideLabelingStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkInsideLabelingStatus.Location = new System.Drawing.Point(264, 11);
            this.ChkInsideLabelingStatus.Name = "ChkInsideLabelingStatus";
            this.ChkInsideLabelingStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkInsideLabelingStatus.TabIndex = 10;
            this.ChkInsideLabelingStatus.Text = "内贴标机";
            this.ChkInsideLabelingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkInsideLabelingStatus.UseVisualStyleBackColor = true;
            // 
            // ChkOutsideLabelingStatus
            // 
            this.ChkOutsideLabelingStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkOutsideLabelingStatus.Location = new System.Drawing.Point(350, 11);
            this.ChkOutsideLabelingStatus.Name = "ChkOutsideLabelingStatus";
            this.ChkOutsideLabelingStatus.Size = new System.Drawing.Size(80, 24);
            this.ChkOutsideLabelingStatus.TabIndex = 11;
            this.ChkOutsideLabelingStatus.Text = "外贴标机";
            this.ChkOutsideLabelingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkOutsideLabelingStatus.UseVisualStyleBackColor = true;
            // 
            // GrpDevicesStatus
            // 
            this.GrpDevicesStatus.Controls.Add(this.ChkOutsideLabelingStatus);
            this.GrpDevicesStatus.Controls.Add(this.ChkInsideLabelingStatus);
            this.GrpDevicesStatus.Controls.Add(this.ChkSqlStatus);
            this.GrpDevicesStatus.Controls.Add(this.ChkR04CpuStatus);
            this.GrpDevicesStatus.Controls.Add(this.ChkFxStatus);
            this.GrpDevicesStatus.Location = new System.Drawing.Point(3, 3);
            this.GrpDevicesStatus.Name = "GrpDevicesStatus";
            this.GrpDevicesStatus.Size = new System.Drawing.Size(436, 42);
            this.GrpDevicesStatus.TabIndex = 12;
            this.GrpDevicesStatus.TabStop = false;
            // 
            // DevicesStatusPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpDevicesStatus);
            this.Name = "DevicesStatusPanel";
            this.Size = new System.Drawing.Size(445, 52);
            this.Resize += new System.EventHandler(this.DevicesStatusPanel_Resize);
            this.GrpDevicesStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkSqlStatus;
        private System.Windows.Forms.CheckBox ChkFxStatus;
        private System.Windows.Forms.CheckBox ChkR04CpuStatus;
        private System.Windows.Forms.CheckBox ChkInsideLabelingStatus;
        private System.Windows.Forms.CheckBox ChkOutsideLabelingStatus;
        private System.Windows.Forms.GroupBox GrpDevicesStatus;
    }
}
