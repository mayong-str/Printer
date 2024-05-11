namespace LabelDesigner
{
    partial class FormBarcodeElement
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRotateFlip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMagnify = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cboViewText = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.panelView = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.TxtMapping = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.LblBackColor = new System.Windows.Forms.Label();
            this.LblForeColor = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelView.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码格式：";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(83, 60);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(161, 20);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.CboType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "条码高度：";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(83, 86);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(89, 21);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.TextChanged += new System.EventHandler(this.TxtHeight_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "点";
            // 
            // cboRotateFlip
            // 
            this.cboRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotateFlip.FormattingEnabled = true;
            this.cboRotateFlip.Location = new System.Drawing.Point(83, 161);
            this.cboRotateFlip.Name = "cboRotateFlip";
            this.cboRotateFlip.Size = new System.Drawing.Size(161, 20);
            this.cboRotateFlip.TabIndex = 8;
            this.cboRotateFlip.SelectedIndexChanged += new System.EventHandler(this.CboRotateFlip_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "旋转角度：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(250, 58);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "创建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(83, 33);
            this.txtContext.Name = "txtContext";
            this.txtContext.Size = new System.Drawing.Size(161, 21);
            this.txtContext.TabIndex = 13;
            this.txtContext.TextChanged += new System.EventHandler(this.TxtContext_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "条码文本：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "ID号：";
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblID.Location = new System.Drawing.Point(83, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(161, 21);
            this.lblID.TabIndex = 15;
            this.lblID.Text = "ID";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(250, 84);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 23);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(83, 113);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(60, 21);
            this.txtX.TabIndex = 18;
            this.txtX.TextChanged += new System.EventHandler(this.TxtX_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "位置X：";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(184, 113);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(60, 21);
            this.txtY.TabIndex = 19;
            this.txtY.TextChanged += new System.EventHandler(this.TxtY_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "Y：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "宽度比例：";
            // 
            // txtMagnify
            // 
            this.txtMagnify.Location = new System.Drawing.Point(83, 186);
            this.txtMagnify.Name = "txtMagnify";
            this.txtMagnify.Size = new System.Drawing.Size(89, 21);
            this.txtMagnify.TabIndex = 22;
            this.txtMagnify.TextChanged += new System.EventHandler(this.TxtMagnify_TextChanged);
            // 
            // cboViewText
            // 
            this.cboViewText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewText.FormattingEnabled = true;
            this.cboViewText.Location = new System.Drawing.Point(83, 211);
            this.cboViewText.Name = "cboViewText";
            this.cboViewText.Size = new System.Drawing.Size(161, 20);
            this.cboViewText.TabIndex = 24;
            this.cboViewText.SelectedIndexChanged += new System.EventHandler(this.CboViewText_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "显示文本：";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(250, 209);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(83, 23);
            this.btnFont.TabIndex = 25;
            this.btnFont.Text = "字体";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.BtnFont_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(182, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "倍";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "文本字体：";
            // 
            // lblFont
            // 
            this.lblFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFont.Location = new System.Drawing.Point(83, 234);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(250, 48);
            this.lblFont.TabIndex = 28;
            // 
            // panelView
            // 
            this.panelView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Controls.Add(this.lblSize);
            this.panelView.Controls.Add(this.label13);
            this.panelView.Location = new System.Drawing.Point(339, 9);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(319, 297);
            this.panelView.TabIndex = 30;
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(1, 244);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(54, 29);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "W\r\nH";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "预览";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(250, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(83, 23);
            this.btnView.TabIndex = 31;
            this.btnView.Text = "预览 >>";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // TxtMapping
            // 
            this.TxtMapping.Location = new System.Drawing.Point(83, 285);
            this.TxtMapping.Name = "TxtMapping";
            this.TxtMapping.Size = new System.Drawing.Size(250, 21);
            this.TxtMapping.TabIndex = 59;
            this.TxtMapping.TextChanged += new System.EventHandler(this.TxtMapping_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 58;
            this.label14.Text = "文本映射：";
            // 
            // LblBackColor
            // 
            this.LblBackColor.BackColor = System.Drawing.Color.White;
            this.LblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBackColor.Location = new System.Drawing.Point(184, 137);
            this.LblBackColor.Name = "LblBackColor";
            this.LblBackColor.Size = new System.Drawing.Size(21, 21);
            this.LblBackColor.TabIndex = 67;
            this.LblBackColor.BackColorChanged += new System.EventHandler(this.LblBackColor_BackColorChanged);
            this.LblBackColor.Click += new System.EventHandler(this.LblColor_Click);
            // 
            // LblForeColor
            // 
            this.LblForeColor.BackColor = System.Drawing.Color.White;
            this.LblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblForeColor.Location = new System.Drawing.Point(83, 137);
            this.LblForeColor.Name = "LblForeColor";
            this.LblForeColor.Size = new System.Drawing.Size(21, 21);
            this.LblForeColor.TabIndex = 66;
            this.LblForeColor.BackColorChanged += new System.EventHandler(this.LblForeColor_BackColorChanged);
            this.LblForeColor.Click += new System.EventHandler(this.LblColor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(125, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 65;
            this.label15.Text = "背景色：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 64;
            this.label16.Text = "前景色：";
            // 
            // FormBarcodeElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 315);
            this.Controls.Add(this.LblBackColor);
            this.Controls.Add(this.LblForeColor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TxtMapping);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.cboViewText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMagnify);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cboRotateFlip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label1);
            this.Name = "FormBarcodeElement";
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.FormBarcodeElement_Load);
            this.panelView.ResumeLayout(false);
            this.panelView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRotateFlip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMagnify;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ComboBox cboViewText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtMapping;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LblBackColor;
        private System.Windows.Forms.Label LblForeColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}