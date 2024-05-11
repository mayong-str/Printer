
namespace LabelDesigner
{
    partial class LabelPreviewPanel
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
            this.PicImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicImage.Location = new System.Drawing.Point(133, 15);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(292, 50);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // LabelPreviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PicImage);
            this.Name = "LabelPreviewPanel";
            this.Size = new System.Drawing.Size(635, 434);
            this.Load += new System.EventHandler(this.LabelPreviewPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicImage;
    }
}
