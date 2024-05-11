namespace LabelFactory
{
    partial class LabelCommandPanel
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFixedText = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnQrCode = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnVariableText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFixedText
            // 
            this.btnFixedText.Location = new System.Drawing.Point(3, 3);
            this.btnFixedText.Name = "btnFixedText";
            this.btnFixedText.Size = new System.Drawing.Size(48, 48);
            this.btnFixedText.TabIndex = 0;
            this.btnFixedText.Text = "固定文字";
            this.btnFixedText.UseVisualStyleBackColor = true;
            this.btnFixedText.Click += new System.EventHandler(this.btnFixedText_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(111, 3);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(48, 48);
            this.btnBarcode.TabIndex = 1;
            this.btnBarcode.Text = "一维条码";
            this.btnBarcode.UseVisualStyleBackColor = true;
            // 
            // btnQrCode
            // 
            this.btnQrCode.Location = new System.Drawing.Point(165, 3);
            this.btnQrCode.Name = "btnQrCode";
            this.btnQrCode.Size = new System.Drawing.Size(48, 48);
            this.btnQrCode.TabIndex = 2;
            this.btnQrCode.Text = "二维QR码";
            this.btnQrCode.UseVisualStyleBackColor = true;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(219, 3);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(48, 48);
            this.btnImage.TabIndex = 3;
            this.btnImage.Text = "图片";
            this.btnImage.UseVisualStyleBackColor = true;
            // 
            // btnVariableText
            // 
            this.btnVariableText.Location = new System.Drawing.Point(57, 3);
            this.btnVariableText.Name = "btnVariableText";
            this.btnVariableText.Size = new System.Drawing.Size(48, 48);
            this.btnVariableText.TabIndex = 4;
            this.btnVariableText.Text = "可变文字";
            this.btnVariableText.UseVisualStyleBackColor = true;
            // 
            // LabelCommandPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnVariableText);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnQrCode);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btnFixedText);
            this.Name = "LabelCommandPanel";
            this.Size = new System.Drawing.Size(271, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFixedText;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnQrCode;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnVariableText;
    }
}
