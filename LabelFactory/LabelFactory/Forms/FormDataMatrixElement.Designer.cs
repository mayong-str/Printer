namespace LabelDesigner
{
    partial class FormDataMatrixElement
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
            this.txtContext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cboRotateFlip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cboErrorCorrectionLevel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMagnify = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMapping = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnView.Location = new System.Drawing.Point(246, 86);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(83, 23);
            this.btnView.TabIndex = 47;
            this.btnView.Text = "预览 >>";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "Y：";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(180, 63);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(60, 21);
            this.txtY.TabIndex = 42;
            this.txtY.TextChanged += new System.EventHandler(this.TxtY_TextChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(79, 63);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(60, 21);
            this.txtX.TabIndex = 41;
            this.txtX.TextChanged += new System.EventHandler(this.TxtX_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 66);
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
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
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
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(79, 36);
            this.txtContext.Name = "txtContext";
            this.txtContext.Size = new System.Drawing.Size(250, 21);
            this.txtContext.TabIndex = 36;
            this.txtContext.TextChanged += new System.EventHandler(this.TxtContext_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "文本：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(246, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(246, 169);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 23);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "创建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // cboRotateFlip
            // 
            this.cboRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotateFlip.FormattingEnabled = true;
            this.cboRotateFlip.Location = new System.Drawing.Point(79, 116);
            this.cboRotateFlip.Name = "cboRotateFlip";
            this.cboRotateFlip.Size = new System.Drawing.Size(161, 20);
            this.cboRotateFlip.TabIndex = 32;
            this.cboRotateFlip.SelectedIndexChanged += new System.EventHandler(this.CboRotateFlip_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "旋转角度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "纠错等级：";
            // 
            // cboErrorCorrectionLevel
            // 
            this.cboErrorCorrectionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErrorCorrectionLevel.FormattingEnabled = true;
            this.cboErrorCorrectionLevel.Location = new System.Drawing.Point(79, 90);
            this.cboErrorCorrectionLevel.Name = "cboErrorCorrectionLevel";
            this.cboErrorCorrectionLevel.Size = new System.Drawing.Size(161, 20);
            this.cboErrorCorrectionLevel.TabIndex = 54;
            this.cboErrorCorrectionLevel.SelectedIndexChanged += new System.EventHandler(this.CboErrorCorrectionLevel_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 58;
            this.label11.Text = "倍";
            // 
            // txtMagnify
            // 
            this.txtMagnify.Location = new System.Drawing.Point(79, 142);
            this.txtMagnify.Name = "txtMagnify";
            this.txtMagnify.Size = new System.Drawing.Size(89, 21);
            this.txtMagnify.TabIndex = 57;
            this.txtMagnify.TextChanged += new System.EventHandler(this.TxtMagnify_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "宽度比例：";
            // 
            // TxtMapping
            // 
            this.TxtMapping.Location = new System.Drawing.Point(79, 169);
            this.TxtMapping.Name = "TxtMapping";
            this.TxtMapping.Size = new System.Drawing.Size(161, 21);
            this.TxtMapping.TabIndex = 60;
            this.TxtMapping.TextChanged += new System.EventHandler(this.TxtMapping_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "文本映射：";
            // 
            // FormDataMatrixElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 269);
            this.Controls.Add(this.TxtMapping);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMagnify);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboErrorCorrectionLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnView);
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
            this.Controls.Add(this.panelView);
            this.Name = "FormDataMatrixElement";
            this.Text = "DataMatrix";
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
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cboRotateFlip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboErrorCorrectionLevel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMagnify;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtMapping;
        private System.Windows.Forms.Label label1;
    }
}