﻿namespace LabelDesigner
{
    partial class FormPrinter
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
            this.BtnTcpPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTcpPrint
            // 
            this.BtnTcpPrint.Location = new System.Drawing.Point(12, 12);
            this.BtnTcpPrint.Name = "BtnTcpPrint";
            this.BtnTcpPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnTcpPrint.TabIndex = 13;
            this.BtnTcpPrint.Text = "TCP打印";
            this.BtnTcpPrint.UseVisualStyleBackColor = true;
            this.BtnTcpPrint.Click += new System.EventHandler(this.BtnTcpPrint_Click);
            // 
            // FormPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 293);
            this.Controls.Add(this.BtnTcpPrint);
            this.Name = "FormPrinter";
            this.Text = "FormPrinter";
            this.Load += new System.EventHandler(this.FormPrinter_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnTcpPrint;
    }
}