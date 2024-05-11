namespace LabelDesigner
{
    partial class FormNewLabel
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
            this.txtLabelName = new System.Windows.Forms.TextBox();
            this.txtLabelWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLabelHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rdo8Dot = new System.Windows.Forms.RadioButton();
            this.rdo12Dot = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.CobNumberPerLine = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtGap = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签名字：";
            // 
            // txtLabelName
            // 
            this.txtLabelName.Location = new System.Drawing.Point(83, 6);
            this.txtLabelName.Name = "txtLabelName";
            this.txtLabelName.Size = new System.Drawing.Size(179, 21);
            this.txtLabelName.TabIndex = 1;
            this.txtLabelName.TextChanged += new System.EventHandler(this.txtLabelName_TextChanged);
            // 
            // txtLabelWidth
            // 
            this.txtLabelWidth.Location = new System.Drawing.Point(83, 33);
            this.txtLabelWidth.Name = "txtLabelWidth";
            this.txtLabelWidth.Size = new System.Drawing.Size(83, 21);
            this.txtLabelWidth.TabIndex = 3;
            this.txtLabelWidth.TextChanged += new System.EventHandler(this.txtLabelWidth_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "标签宽度：";
            // 
            // txtLabelHeight
            // 
            this.txtLabelHeight.Location = new System.Drawing.Point(83, 60);
            this.txtLabelHeight.Name = "txtLabelHeight";
            this.txtLabelHeight.Size = new System.Drawing.Size(83, 21);
            this.txtLabelHeight.TabIndex = 5;
            this.txtLabelHeight.TextChanged += new System.EventHandler(this.txtLabelHeight_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "标签高度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "毫米";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "毫米";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(83, 140);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "创建标签";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(187, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消创建";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "点/毫米";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "标签粒度：";
            // 
            // rdo8Dot
            // 
            this.rdo8Dot.AutoSize = true;
            this.rdo8Dot.Location = new System.Drawing.Point(83, 113);
            this.rdo8Dot.Name = "rdo8Dot";
            this.rdo8Dot.Size = new System.Drawing.Size(29, 16);
            this.rdo8Dot.TabIndex = 13;
            this.rdo8Dot.TabStop = true;
            this.rdo8Dot.Text = "8";
            this.rdo8Dot.UseVisualStyleBackColor = true;
            this.rdo8Dot.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdo12Dot
            // 
            this.rdo12Dot.AutoSize = true;
            this.rdo12Dot.Location = new System.Drawing.Point(129, 113);
            this.rdo12Dot.Name = "rdo12Dot";
            this.rdo12Dot.Size = new System.Drawing.Size(35, 16);
            this.rdo12Dot.TabIndex = 14;
            this.rdo12Dot.TabStop = true;
            this.rdo12Dot.Text = "12";
            this.rdo12Dot.UseVisualStyleBackColor = true;
            this.rdo12Dot.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "每行标签：";
            // 
            // CobNumberPerLine
            // 
            this.CobNumberPerLine.FormattingEnabled = true;
            this.CobNumberPerLine.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CobNumberPerLine.Location = new System.Drawing.Point(83, 87);
            this.CobNumberPerLine.Name = "CobNumberPerLine";
            this.CobNumberPerLine.Size = new System.Drawing.Size(39, 20);
            this.CobNumberPerLine.TabIndex = 17;
            this.CobNumberPerLine.SelectedIndexChanged += new System.EventHandler(this.CobNumberPerLine_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "毫米";
            // 
            // TxtGap
            // 
            this.TxtGap.Location = new System.Drawing.Point(187, 87);
            this.TxtGap.Name = "TxtGap";
            this.TxtGap.Size = new System.Drawing.Size(40, 21);
            this.TxtGap.TabIndex = 19;
            this.TxtGap.TextChanged += new System.EventHandler(this.TxtGap_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "个，间隙：";
            // 
            // FormNewLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 174);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtGap);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CobNumberPerLine);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdo12Dot);
            this.Controls.Add(this.rdo8Dot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLabelHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLabelWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLabelName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建标签";
            this.Load += new System.EventHandler(this.FormNewLabel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLabelName;
        private System.Windows.Forms.TextBox txtLabelWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLabelHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdo8Dot;
        private System.Windows.Forms.RadioButton rdo12Dot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CobNumberPerLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtGap;
        private System.Windows.Forms.Label label10;
    }
}