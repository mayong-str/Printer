namespace LabelDesigner
{
    partial class FormPrinterUsb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.BtnConnClose = new System.Windows.Forms.Button();
            this.BtnConnOpen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(489, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 29);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // BtnConnClose
            // 
            this.BtnConnClose.Location = new System.Drawing.Point(489, 322);
            this.BtnConnClose.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnClose.Name = "BtnConnClose";
            this.BtnConnClose.Size = new System.Drawing.Size(100, 29);
            this.BtnConnClose.TabIndex = 2;
            this.BtnConnClose.Text = "关闭连接";
            this.BtnConnClose.UseVisualStyleBackColor = true;
            this.BtnConnClose.Click += new System.EventHandler(this.BtnConnClose_Click);
            // 
            // BtnConnOpen
            // 
            this.BtnConnOpen.Location = new System.Drawing.Point(489, 214);
            this.BtnConnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnOpen.Name = "BtnConnOpen";
            this.BtnConnOpen.Size = new System.Drawing.Size(100, 29);
            this.BtnConnOpen.TabIndex = 4;
            this.BtnConnOpen.Text = "打开";
            this.BtnConnOpen.UseVisualStyleBackColor = true;
            this.BtnConnOpen.Click += new System.EventHandler(this.BtnConnOpen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPrinterUsb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnConnOpen);
            this.Controls.Add(this.BtnConnClose);
            this.Controls.Add(this.btnPrint);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrinterUsb";
            this.Text = "FormPrinter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button BtnConnClose;
        private System.Windows.Forms.Button BtnConnOpen;
        private System.Windows.Forms.Button button1;
    }
}