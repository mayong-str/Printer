namespace LabelDesigner
{
    partial class FormLineElement
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
            this.lblSize = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelView = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cboRotateFlip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTickness = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.LblForeColor = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelView.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(2, 220);
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
            // panelView
            // 
            this.panelView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Controls.Add(this.lblSize);
            this.panelView.Controls.Add(this.label13);
            this.panelView.Location = new System.Drawing.Point(335, 12);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(319, 252);
            this.panelView.TabIndex = 31;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(246, 115);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(83, 23);
            this.btnView.TabIndex = 47;
            this.btnView.Text = "预览 >>";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "Y：";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(180, 90);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(60, 21);
            this.txtY.TabIndex = 42;
            this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(79, 90);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(60, 21);
            this.txtX.TabIndex = 41;
            this.txtX.TextChanged += new System.EventHandler(this.txtX_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "位置X：";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(246, 212);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 23);
            this.btnEdit.TabIndex = 39;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblID.Location = new System.Drawing.Point(79, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(250, 21);
            this.lblID.TabIndex = 38;
            this.lblID.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "ID号：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(246, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(246, 183);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 23);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "创建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cboRotateFlip
            // 
            this.cboRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotateFlip.FormattingEnabled = true;
            this.cboRotateFlip.Location = new System.Drawing.Point(79, 117);
            this.cboRotateFlip.Name = "cboRotateFlip";
            this.cboRotateFlip.Size = new System.Drawing.Size(161, 20);
            this.cboRotateFlip.TabIndex = 32;
            this.cboRotateFlip.SelectedIndexChanged += new System.EventHandler(this.cboRotateFlip_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "旋转角度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "粗细：";
            // 
            // txtTickness
            // 
            this.txtTickness.Location = new System.Drawing.Point(79, 63);
            this.txtTickness.Name = "txtTickness";
            this.txtTickness.Size = new System.Drawing.Size(95, 21);
            this.txtTickness.TabIndex = 51;
            this.txtTickness.TextChanged += new System.EventHandler(this.txtTickness_TextChanged);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(79, 36);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(95, 21);
            this.txtLength.TabIndex = 50;
            this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(32, 39);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(41, 12);
            this.lblLength.TabIndex = 49;
            this.lblLength.Text = "长度：";
            // 
            // LblForeColor
            // 
            this.LblForeColor.BackColor = System.Drawing.Color.White;
            this.LblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblForeColor.Location = new System.Drawing.Point(79, 140);
            this.LblForeColor.Name = "LblForeColor";
            this.LblForeColor.Size = new System.Drawing.Size(21, 21);
            this.LblForeColor.TabIndex = 68;
            this.LblForeColor.BackColorChanged += new System.EventHandler(this.LblForeColor_BackColorChanged);
            this.LblForeColor.Click += new System.EventHandler(this.LblColor_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 67;
            this.label16.Text = "颜色：";
            // 
            // FormLineElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 269);
            this.Controls.Add(this.LblForeColor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTickness);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cboRotateFlip);
            this.Controls.Add(this.panelView);
            this.Name = "FormLineElement";
            this.Text = "Line";
            this.Load += new System.EventHandler(this.FormTextElement_Load);
            this.panelView.ResumeLayout(false);
            this.panelView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cboRotateFlip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTickness;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label LblForeColor;
        private System.Windows.Forms.Label label16;
    }
}