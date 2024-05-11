using LabelCommon;
using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class FormMain : Form
    {
        #region 私有变量
        private string labelStorePath;
        private LabelDesignerPanel ldp;
        #endregion

        #region 构造器
        public FormMain()
        {
            InitializeComponent();
            InitializeVariables();
        }
        #endregion

        private void InitializeVariables()
        {
            this.labelStorePath = ConfigurationManager.AppSettings["LabelStoreFolder"];

        }

        private void InitDesignerPanel()
        {
            int x = (this.ClientSize.Width - this.ldp.Width) / 2;
            int y = (this.ClientSize.Height - this.TsMain.Height - this.ldp.Height) < 0 ? 0 : (this.ClientSize.Height - this.ldp.Height) / 2;
            ldp.Location = new Point(x, y);
            //ldp.Dock = DockStyle.Bottom;
            ldp.Anchor = AnchorStyles.Top;
            ldp.DisplayGrid = true;
            this.Controls.Add(ldp);

            this.TsmiView.Enabled = this.tsmiElement.Enabled = true;
            this.tsmiOpen.Enabled = this.TsmiNew.Enabled = false;
            this.tsmiSave.Enabled = this.tsmiSaveAsImage.Enabled = this.tsmiClose.Enabled = this.tsmiPrint.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void TsmiNew_Click(object sender, EventArgs e)
        {
            FormNewLabel formNewLabel = new();
            if (formNewLabel.ShowDialog() == DialogResult.OK)
            {
                Global.WorkLabel = new(formNewLabel.LabelBasic, new ArrayList());
                ldp = new LabelDesignerPanel()
                {
                    EditMode = true,

                };
                InitDesignerPanel();
            }
        }

        private void TsmiSave_Click(object sender, EventArgs e)
        {
            if (this.ldp == null) return;
            this.saveFileDialog1.InitialDirectory = this.labelStorePath;
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML文件(*.xml)|*.xml";
            this.saveFileDialog1.FileName = Global.WorkLabel.BasicInfo.Name + ".xml";
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                LabelFormatAndXml.LabelFormat2Xml(Global.WorkLabel.BasicInfo, this.ldp.LabelElements, this.saveFileDialog1.FileName);
            }
        }

        private void TsmiSaveAsImage_Click(object sender, EventArgs e)
        {
            if (this.ldp == null) return;

            //Bitmap bmp = LabelPanelToImage();
            Bitmap bmp = Global.WorkLabel.LabelBitmap;
            this.saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            this.saveFileDialog1.DefaultExt = "bmp";
            this.saveFileDialog1.Filter = "BMP文件(*.bmp)|*.bmp";
            this.saveFileDialog1.FileName = Global.WorkLabel.BasicInfo.Name + ".bmp";
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bmp.Save(this.saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void TsmiBarcodeElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewBarcodeElement();
        }
        private void TsmiTextElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewTextElement();
        }
        private void TsmiQrCodeElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewQrCodeElement();
        }

        private void TsmiDataMatrixElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewDataMatrixElement();
        }
        private void TsmiLineElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewLineElement();
        }
        private void TsmiImageElement_Click(object sender, EventArgs e)
        {
            this.ldp.CreateNewImageElement();
        }
        private void TsmiOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = this.labelStorePath;
            this.openFileDialog1.FileName = string.Empty;
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                LabelFormatAndXml.Xml2LabelFormat(this.openFileDialog1.FileName, out LabelBasicInfoClass lbic, out ArrayList elements);
                Global.WorkLabel = new LabelClass(lbic, elements);
                ldp = new LabelDesignerPanel()
                {
                    EditMode = true
                };
                InitDesignerPanel();
            }
        }

        private void TsmiClose_Click(object sender, EventArgs e)
        {

            if (this.ldp != null)
            {
                this.Controls.Remove(this.ldp);
                this.ldp = null;
            }

            this.Refresh();
            this.TsmiView.Enabled = this.tsmiElement.Enabled = false;
            this.tsmiOpen.Enabled = this.TsmiNew.Enabled = true;
            this.tsmiSave.Enabled = this.tsmiSaveAsImage.Enabled = this.tsmiClose.Enabled = this.tsmiPrint.Enabled = false;
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TsmiPrint_Click(object sender, EventArgs e)
        {
            //FormPrinterUsb formPrinter = new(this.lpp.Bitmap, Global.WorkLabel.BasicInfo);
            FormPrinterUsb formPrinter = new(Global.WorkLabel.LabelBitmap, Global.WorkLabel.BasicInfo);
            if (formPrinter.ShowDialog() == DialogResult.OK) { }

            //FormPrinter formPrinter = new(Global.WorkLabel);
            //if (formPrinter.ShowDialog() == DialogResult.OK) { }

            //FormPrinteEpsonr formPrinter = new();
            //if (formPrinter.ShowDialog() == DialogResult.OK) { }

        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ldp != null)
            {

            }
        }

        private void TsmiPreviewMode_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            this.TsmiEditMode.Checked = !tsmi.Checked;
            this.ldp.EditMode = !tsmi.Checked;

        }

        private void TsmiEditMode_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            this.TsmiPreviewMode.Checked = !tsmi.Checked;
            this.ldp.EditMode = tsmi.Checked;

        }

        private void TsbtnOpen_Click(object sender, EventArgs e)
        {

        }


    }
}
