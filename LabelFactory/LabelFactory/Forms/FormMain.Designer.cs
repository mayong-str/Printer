namespace LabelDesigner
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEditingAreaBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiPreviewMode = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBarcodeElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQrCodeElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataMatrixElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLineElement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImageElement = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsslX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslY = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TsMain = new System.Windows.Forms.ToolStrip();
            this.TsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.TsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.TsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.TSbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.TsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.TsmiView,
            this.tsmiElement});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(223, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiNew,
            this.tsmiOpen,
            this.toolStripMenuItem2,
            this.tsmiSave,
            this.tsmiSaveAsImage,
            this.tsmiClose,
            this.toolStripMenuItem3,
            this.tsmiPrint,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(71, 24);
            this.tsmiFile.Text = "文件(F)";
            // 
            // TsmiNew
            // 
            this.TsmiNew.Name = "TsmiNew";
            this.TsmiNew.Size = new System.Drawing.Size(167, 26);
            this.TsmiNew.Text = "新建(N)";
            this.TsmiNew.Click += new System.EventHandler(this.TsmiNew_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(167, 26);
            this.tsmiOpen.Text = "打开(O)";
            this.tsmiOpen.Click += new System.EventHandler(this.TsmiOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Enabled = false;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(167, 26);
            this.tsmiSave.Text = "保存(S)";
            this.tsmiSave.Click += new System.EventHandler(this.TsmiSave_Click);
            // 
            // tsmiSaveAsImage
            // 
            this.tsmiSaveAsImage.Enabled = false;
            this.tsmiSaveAsImage.Name = "tsmiSaveAsImage";
            this.tsmiSaveAsImage.Size = new System.Drawing.Size(167, 26);
            this.tsmiSaveAsImage.Text = "另存为图片";
            this.tsmiSaveAsImage.Click += new System.EventHandler(this.TsmiSaveAsImage_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Enabled = false;
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(167, 26);
            this.tsmiClose.Text = "关闭(C)";
            this.tsmiClose.Click += new System.EventHandler(this.TsmiClose_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Enabled = false;
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(167, 26);
            this.tsmiPrint.Text = "打印(P)";
            this.tsmiPrint.Click += new System.EventHandler(this.TsmiPrint_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(167, 26);
            this.tsmiExit.Text = "退出(x)";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // TsmiView
            // 
            this.TsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiEditingAreaBackgroundColor,
            this.toolStripMenuItem4,
            this.TsmiPreviewMode,
            this.TsmiEditMode});
            this.TsmiView.Enabled = false;
            this.TsmiView.Name = "TsmiView";
            this.TsmiView.Size = new System.Drawing.Size(73, 24);
            this.TsmiView.Text = "查看(V)";
            // 
            // TsmiEditingAreaBackgroundColor
            // 
            this.TsmiEditingAreaBackgroundColor.Name = "TsmiEditingAreaBackgroundColor";
            this.TsmiEditingAreaBackgroundColor.Size = new System.Drawing.Size(167, 26);
            this.TsmiEditingAreaBackgroundColor.Text = "编辑区底色";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(164, 6);
            // 
            // TsmiPreviewMode
            // 
            this.TsmiPreviewMode.CheckOnClick = true;
            this.TsmiPreviewMode.Name = "TsmiPreviewMode";
            this.TsmiPreviewMode.Size = new System.Drawing.Size(167, 26);
            this.TsmiPreviewMode.Text = "预览模式";
            this.TsmiPreviewMode.CheckedChanged += new System.EventHandler(this.TsmiPreviewMode_CheckedChanged);
            // 
            // TsmiEditMode
            // 
            this.TsmiEditMode.Checked = true;
            this.TsmiEditMode.CheckOnClick = true;
            this.TsmiEditMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TsmiEditMode.Name = "TsmiEditMode";
            this.TsmiEditMode.Size = new System.Drawing.Size(167, 26);
            this.TsmiEditMode.Text = "编辑模式";
            this.TsmiEditMode.CheckedChanged += new System.EventHandler(this.TsmiEditMode_CheckedChanged);
            // 
            // tsmiElement
            // 
            this.tsmiElement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTextElement,
            this.tsmiBarcodeElement,
            this.tsmiQrCodeElement,
            this.tsmiDataMatrixElement,
            this.tsmiLineElement,
            this.tsmiImageElement});
            this.tsmiElement.Enabled = false;
            this.tsmiElement.Name = "tsmiElement";
            this.tsmiElement.Size = new System.Drawing.Size(71, 24);
            this.tsmiElement.Text = "元素(E)";
            // 
            // tsmiTextElement
            // 
            this.tsmiTextElement.Name = "tsmiTextElement";
            this.tsmiTextElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiTextElement.Text = "文字(T)";
            this.tsmiTextElement.Click += new System.EventHandler(this.TsmiTextElement_Click);
            // 
            // tsmiBarcodeElement
            // 
            this.tsmiBarcodeElement.Name = "tsmiBarcodeElement";
            this.tsmiBarcodeElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiBarcodeElement.Text = "条码(B)";
            this.tsmiBarcodeElement.Click += new System.EventHandler(this.TsmiBarcodeElement_Click);
            // 
            // tsmiQrCodeElement
            // 
            this.tsmiQrCodeElement.Name = "tsmiQrCodeElement";
            this.tsmiQrCodeElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiQrCodeElement.Text = "QR码(Q)";
            this.tsmiQrCodeElement.Click += new System.EventHandler(this.TsmiQrCodeElement_Click);
            // 
            // tsmiDataMatrixElement
            // 
            this.tsmiDataMatrixElement.Name = "tsmiDataMatrixElement";
            this.tsmiDataMatrixElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiDataMatrixElement.Text = "DM码(D)";
            this.tsmiDataMatrixElement.Click += new System.EventHandler(this.TsmiDataMatrixElement_Click);
            // 
            // tsmiLineElement
            // 
            this.tsmiLineElement.Name = "tsmiLineElement";
            this.tsmiLineElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiLineElement.Text = "直线(L)";
            this.tsmiLineElement.Click += new System.EventHandler(this.TsmiLineElement_Click);
            // 
            // tsmiImageElement
            // 
            this.tsmiImageElement.Name = "tsmiImageElement";
            this.tsmiImageElement.Size = new System.Drawing.Size(154, 26);
            this.tsmiImageElement.Text = "图片(I)";
            this.tsmiImageElement.Click += new System.EventHandler(this.TsmiImageElement_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslX,
            this.tsslY});
            this.statusStripMain.Location = new System.Drawing.Point(0, 875);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1549, 26);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsslX
            // 
            this.tsslX.Name = "tsslX";
            this.tsslX.Size = new System.Drawing.Size(23, 20);
            this.tsslX.Text = "X:";
            // 
            // tsslY
            // 
            this.tsslY.Name = "tsslY";
            this.tsslY.Size = new System.Drawing.Size(22, 20);
            this.tsslY.Text = "Y:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML文件(*.xml)|*.xml";
            // 
            // TsMain
            // 
            this.TsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.TsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbtnOpen,
            this.TsbtnClose,
            this.TsbtnSave,
            this.TSbtnPrint,
            this.toolStripSeparator1,
            this.toolStripComboBox1});
            this.TsMain.Location = new System.Drawing.Point(0, 31);
            this.TsMain.Name = "TsMain";
            this.TsMain.Size = new System.Drawing.Size(258, 28);
            this.TsMain.TabIndex = 2;
            this.TsMain.Text = "toolStrip1";
            // 
            // TsbtnOpen
            // 
            this.TsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("TsbtnOpen.Image")));
            this.TsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnOpen.Name = "TsbtnOpen";
            this.TsbtnOpen.Size = new System.Drawing.Size(29, 25);
            this.TsbtnOpen.Text = "toolStripButton1";
            this.TsbtnOpen.ToolTipText = "打开";
            this.TsbtnOpen.Click += new System.EventHandler(this.TsbtnOpen_Click);
            // 
            // TsbtnClose
            // 
            this.TsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("TsbtnClose.Image")));
            this.TsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnClose.Name = "TsbtnClose";
            this.TsbtnClose.Size = new System.Drawing.Size(29, 25);
            this.TsbtnClose.Text = "toolStripButton2";
            this.TsbtnClose.ToolTipText = "关闭";
            // 
            // TsbtnSave
            // 
            this.TsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("TsbtnSave.Image")));
            this.TsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnSave.Name = "TsbtnSave";
            this.TsbtnSave.Size = new System.Drawing.Size(29, 25);
            this.TsbtnSave.Text = "toolStripButton3";
            this.TsbtnSave.ToolTipText = "保存";
            // 
            // TSbtnPrint
            // 
            this.TSbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("TSbtnPrint.Image")));
            this.TSbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSbtnPrint.Name = "TSbtnPrint";
            this.TSbtnPrint.Size = new System.Drawing.Size(29, 25);
            this.TSbtnPrint.Text = "toolStripButton1";
            this.TSbtnPrint.ToolTipText = "打印";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownWidth = 1;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "最小移动量：1点",
            "最小移动量：2点",
            "最小移动量：3点",
            "最小移动量：4点",
            "最小移动量：6点",
            "最小移动量：8点",
            "最小移动量：9点",
            "最小移动量：12点",
            "最小移动量：16点",
            "最小移动量：24点"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.ToolTipText = "标签元素最小移动量";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1549, 901);
            this.Controls.Add(this.TsMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标签设计器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.TsMain.ResumeLayout(false);
            this.TsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem TsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiElement;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextElement;
        private System.Windows.Forms.ToolStripMenuItem tsmiBarcodeElement;
        private System.Windows.Forms.ToolStripMenuItem tsmiQrCodeElement;
        private System.Windows.Forms.ToolStripMenuItem tsmiLineElement;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslX;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsImage;
        private System.Windows.Forms.ToolStripStatusLabel tsslY;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImageElement;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem TsmiView;
        private System.Windows.Forms.ToolStripMenuItem TsmiEditingAreaBackgroundColor;
        private System.Windows.Forms.ToolStrip TsMain;
        private System.Windows.Forms.ToolStripButton TsbtnOpen;
        private System.Windows.Forms.ToolStripButton TsbtnClose;
        private System.Windows.Forms.ToolStripButton TsbtnSave;
        private System.Windows.Forms.ToolStripButton TSbtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem TsmiPreviewMode;
        private System.Windows.Forms.ToolStripMenuItem TsmiEditMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataMatrixElement;
    }
}