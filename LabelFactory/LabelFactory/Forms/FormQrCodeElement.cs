using System;
using System.Drawing;
using System.Windows.Forms;
using LabelCommon;

namespace LabelDesigner
{
    public partial class FormQrCodeElement : Form
    {
        #region 类属性
        public QrCodeElementClass QrCodeElement { get; private set; }
        public Bitmap ElementImage { get; private set; }
        #endregion

        #region 类私有成员变量
        private string _id;
        private string _context;
        private string _rotateFlip = "RotateNoneFlipNone";
        private int _x = 0;
        private int _y = 0;
        // private int _width = 0;
        // private int _height = 0;
        //  private bool _inversion = false;
        private byte _magnify = 1;
        private string _errorCorrectionLevel = "M";
        private string _mapping;
        private Color _foreColor = Color.Black;
        private Color _backColor = Color.White;
        #endregion

        #region 类构造器
        public FormQrCodeElement(string id)
        {
            InitializeComponent();
            this.QrCodeElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormQrCodeElement(QrCodeElementClass qcec)
        {
            InitializeComponent();
            this.QrCodeElement = qcec;
            this.btnEdit.Enabled = true;
            this.btnNew.Enabled = false;
        }
        #endregion

        private void InitComboRotateFlip()
        {
            this.cboRotateFlip.Items.Add("RotateNoneFlipNone");//0
            this.cboRotateFlip.Items.Add("Rotate90FlipNone");//1
            this.cboRotateFlip.Items.Add("Rotate180FlipNone");//2
            this.cboRotateFlip.Items.Add("Rotate270FlipNone");//3
            this.cboRotateFlip.Items.Add("RotateNoneFlipX");//4
            this.cboRotateFlip.Items.Add("Rotate90FlipX");//5
            this.cboRotateFlip.Items.Add("RotateNoneFlipY");//6
            this.cboRotateFlip.Items.Add("Rotate90FlipY");//7
            this.cboRotateFlip.SelectedIndex = 0;
        }
        private void InitComboErrorCorrectionLevel()
        {
            this.cboErrorCorrectionLevel.Items.Add("L");
            this.cboErrorCorrectionLevel.Items.Add("M");
            this.cboErrorCorrectionLevel.Items.Add("Q");
            this.cboErrorCorrectionLevel.Items.Add("H");
            this.cboErrorCorrectionLevel.SelectedIndex = 1;
        }
        private bool ElementDataIsValid()
        {
            if (string.IsNullOrEmpty(_context)) return false;

            return true;
        }

        private void SetElement()
        {
            this.QrCodeElement.ID = this._id;
            this.QrCodeElement.Context = this._context;
            this.QrCodeElement.RotateFlip = this._rotateFlip;
            this.QrCodeElement.X = this._x;
            this.QrCodeElement.Y = this._y;
            this.QrCodeElement.ErrorCorrectionLevel = this._errorCorrectionLevel;
            this.QrCodeElement.Magnify = this._magnify;
            this.QrCodeElement.Mapping = this._mapping;
            this.QrCodeElement.ForeColor = this._foreColor;
            this.QrCodeElement.BackColor = this._backColor;

            GetBitmap();
        }

        private void GetBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetQrcodeGma(this.QrCodeElement);

            this.panelView.BackgroundImage = this.ElementImage;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }

        private void FormTextElement_Load(object sender, EventArgs e)
        {
            InitComboErrorCorrectionLevel();
            InitComboRotateFlip();

            if (this.QrCodeElement != null)
            {
                this._id = this.QrCodeElement.ID;
                this.lblID.Text = this.QrCodeElement.ID;
                this.txtContext.Text = this.QrCodeElement.Context;
                this.txtX.Text = this.QrCodeElement.X.ToString();
                this.txtY.Text = this.QrCodeElement.Y.ToString();
                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.QrCodeElement.RotateFlip);
                this.cboErrorCorrectionLevel.SelectedIndex = this.cboErrorCorrectionLevel.Items.IndexOf(this.QrCodeElement.ErrorCorrectionLevel);
                this.txtMagnify.Text = this.QrCodeElement.Magnify.ToString();
                this._mapping = this.QrCodeElement.Mapping;
                this.TxtMapping.Text = this.QrCodeElement.Mapping;
                this.LblForeColor.BackColor = this.QrCodeElement.ForeColor;
                this.LblBackColor.BackColor = this.QrCodeElement.BackColor;
            }
            else
            {   //新建元素
                this.lblID.Text = this._id;
                this.txtMagnify.Text = this._magnify.ToString();
                this.LblForeColor.BackColor = this._foreColor;
                this.LblBackColor.BackColor = this._backColor;
            }
        }

        private void CboRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._rotateFlip = this.cboRotateFlip.Text;
        }

        private void TxtContext_TextChanged(object sender, EventArgs e)
        {
            this._context = this.txtContext.Text;
        }

        private void TxtX_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtX.Text, out this._x);
        }

        private void TxtY_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtY.Text, out this._y);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            if (this.QrCodeElement == null) this.QrCodeElement = new QrCodeElementClass();
            SetElement();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            this.QrCodeElement = new QrCodeElementClass();
            SetElement();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetElement();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TxtMagnify_TextChanged(object sender, EventArgs e)
        {
            byte.TryParse(this.txtMagnify.Text, out this._magnify);
        }

        private void CboErrorCorrectionLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._errorCorrectionLevel = this.cboErrorCorrectionLevel.Text;
        }
        private void TxtMapping_TextChanged(object sender, EventArgs e)
        {
            this._mapping = this.TxtMapping.Text;
        }

        private void LblColor_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            ColorDialog cd = new()
            {
                AllowFullOpen = true,
                FullOpen = true,
                ShowHelp = true,
                Color = (lbl == this.LblForeColor) ? this._foreColor : this._backColor,
            };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (lbl == this.LblForeColor)
                {
                    this.LblForeColor.BackColor = cd.Color;
                }
                else if (lbl == this.LblBackColor)
                {
                    this.LblBackColor.BackColor = cd.Color;
                }
            }
            lbl.BackColor = cd.Color;
        }

        private void LblForeColor_BackColorChanged(object sender, EventArgs e)
        {
            this._foreColor = this.LblForeColor.BackColor;
        }

        private void LblBackColor_BackColorChanged(object sender, EventArgs e)
        {
            this._backColor = this.LblBackColor.BackColor;
        }
    }
}