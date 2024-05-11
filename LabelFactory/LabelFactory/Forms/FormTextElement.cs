using LabelCommon;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class FormTextElement : Form
    {
        #region 类属性
        public TextElementClass TextElement { get; private set; }
        public Bitmap ElementImage { get; private set; }
        #endregion

        #region 类私有成员变量
        private string _id;
        private string _context;
        private string _rotateFlip = "RotateNoneFlipNone";
        private int _x = 0;
        private int _y = 0;
        private int _width = 0;
        private int _height = 0;
        private bool _inversion = false;
        private Font _font;
        private ContentAlignment _textAlign;
        private string _mapping;
        private Color _foreColor = Color.Black;
        private Color _backColor = Color.White;
        #endregion

        #region 类构造器
        public FormTextElement(string id)
        {
            InitializeComponent();
            this.TextElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormTextElement(TextElementClass te)
        {
            InitializeComponent();
            this.TextElement = te;
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

        private void IntComboTextAlign()
        {
            this.cboTextAlign.Items.Add("TopLeft");
            this.cboTextAlign.Items.Add("TopCenter");
            this.cboTextAlign.Items.Add("TopRight");
            this.cboTextAlign.Items.Add("MiddleLeft");
            this.cboTextAlign.Items.Add("MiddleCenter");
            this.cboTextAlign.Items.Add("MiddleRight");
            this.cboTextAlign.Items.Add("BottomLeft");
            this.cboTextAlign.Items.Add("BottomCenter");
            this.cboTextAlign.Items.Add("BottomRight");
            this.cboTextAlign.SelectedIndex = 4;
        }


        private bool ElementDataIsValid()
        {
            if (string.IsNullOrEmpty(_context)) return false;
            if (_font == null) return false;
            return true;
        }

        private void SetTextElement()
        {
            this.TextElement.ID = this._id;
            this.TextElement.Context = this._context;
            this.TextElement.RotateFlip = this._rotateFlip;
            this.TextElement.X = this._x;
            this.TextElement.Y = this._y;
            this.TextElement.Width = this._width;
            this.TextElement.Height = this._height;
            this.TextElement.TextFont = this._font;
            this.TextElement.Inversion = this._inversion;
            this.TextElement.TextAlign = this._textAlign;
            this.TextElement.Mapping = this._mapping;
            this.TextElement.ForeColor = this._foreColor;
            this.TextElement.BackColor = this._backColor;

            GetBitmap();
        }

        private void GetBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetText(this.TextElement);
            this.panelView.BackgroundImage = this.ElementImage;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }

        private void FormTextElement_Load(object sender, EventArgs e)
        {
            IntComboTextAlign();
            InitComboRotateFlip();

            if (this.TextElement != null)
            {
                this._id = this.TextElement.ID;
                this.lblID.Text = this.TextElement.ID;
                this.txtContext.Text = this.TextElement.Context;
                this.txtX.Text = this.TextElement.X.ToString();
                this.txtY.Text = this.TextElement.Y.ToString();
                this.txtPanelWidth.Text = this.TextElement.Width.ToString();
                this.txtPanelHeight.Text = this.TextElement.Height.ToString();
                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.TextElement.RotateFlip);
                this._font = this.TextElement.TextFont;
                this.lblFont.Text = this.TextElement.TextFont.ToString();
                this._inversion = this.TextElement.Inversion;
                this.chkBlack.Checked = this.TextElement.Inversion;
                this.cboTextAlign.SelectedIndex = this.cboTextAlign.Items.IndexOf(this.TextElement.TextAlign.ToString());
                this._mapping = this.TextElement.Mapping;
                this.TxtMapping.Text = this.TextElement.Mapping;
                this.LblForeColor.BackColor = this.TextElement.ForeColor;
                this.LblBackColor.BackColor = this.TextElement.BackColor;
            }
            else
            {   //新建Text元素
                this.lblID.Text = this._id;
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

        private void BtnFont_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this._font;
            if (DialogResult.OK == this.fontDialog1.ShowDialog())
            {
                this._font = this.fontDialog1.Font;
                this.lblFont.Text = this._font.ToString();
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            if (this.TextElement == null) this.TextElement = new TextElementClass();
            SetTextElement();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            this.TextElement = new TextElementClass();
            SetTextElement();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetTextElement();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TxtPanelWidth_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtPanelWidth.Text, out this._width);
        }

        private void TxtPanelHeight_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtPanelHeight.Text, out this._height);
        }

        private void ChkBlack_CheckedChanged(object sender, EventArgs e)
        {
            this._inversion = this.chkBlack.Checked;
        }

        private void CboTextAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._textAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), this.cboTextAlign.SelectedItem.ToString());
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
