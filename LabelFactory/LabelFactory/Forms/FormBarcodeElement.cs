using System;
using System.Windows.Forms;
using LabelCommon;
using System.Drawing;

namespace LabelDesigner
{
    public partial class FormBarcodeElement : Form
    {
        #region 类属性
        public BarcodeElementClass BarcodeElement { get; private set; }

        public Bitmap ElementImage { get; private set; }
        #endregion

        #region 类私有成员变量
        private string _id;
        private string _context;
        private int _height;
        private string _rotateFlip = "RotateNoneFlipNone";
        private int _x = 0;
        private int _y = 0;
        private byte _magnify = 1;
        private string _type = "Code128B";
        private string _textPosition = "NotShow";
        private Font _font;
        private string _mapping;
        private Color _foreColor = Color.Black;
        private Color _backColor = Color.White;

        #endregion

        #region 类构造器
        public FormBarcodeElement(string id)
        {
            InitializeComponent();
            this.BarcodeElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormBarcodeElement(BarcodeElementClass barcodeElement)
        {
            InitializeComponent();
            this.BarcodeElement = barcodeElement;
            // showBarcodeElement(barcodeElement);
            this.btnEdit.Enabled = true;
            this.btnNew.Enabled = false;
        }
        #endregion

        #region 类方法
        /// <summary>初始化条码类型Combo框
        /// 
        /// </summary>
        private void InitComboType()
        {
            this.cboType.Items.Add("Code128A");
            this.cboType.Items.Add("Code128B");
            this.cboType.Items.Add("Code128C");
            this.cboType.Items.Add("EAN128");

            this.cboType.SelectedIndex = 1;
        }
        /// <summary>初始化旋转和翻转类型Combo框
        /// 
        /// </summary>
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
        private void InitComboViewText()
        {
            this.cboViewText.Items.Add("NotShow");
            this.cboViewText.Items.Add("TopLeft");
            this.cboViewText.Items.Add("TopCenter");
            this.cboViewText.Items.Add("TopRight");
            this.cboViewText.Items.Add("BottomLeft");
            this.cboViewText.Items.Add("BottomCenter");
            this.cboViewText.Items.Add("BottomRight");

            this.cboViewText.SelectedIndex = 0;
        }
        /// <summary>设置BarcodeElement对象的值
        /// 
        /// </summary>
        private void SetBarcodeElement()
        {
            this.BarcodeElement.ID = this._id;
            this.BarcodeElement.Context = this._context;
            this.BarcodeElement.Height = this._height;
            this.BarcodeElement.RotateFlip = this._rotateFlip;
            this.BarcodeElement.X = this._x;
            this.BarcodeElement.Y = this._y;
            this.BarcodeElement.Magnify = this._magnify;
            this.BarcodeElement.Type = (Barcode.Type)Enum.Parse(typeof(Barcode.Type), this._type);
            this.BarcodeElement.TextPosition = (Barcode.TextPosition)Enum.Parse(typeof(Barcode.TextPosition), this._textPosition);
            this.BarcodeElement.ViewTextFont = this._font;
            this.BarcodeElement.Mapping = this._mapping;
            this.BarcodeElement.ForeColor = this._foreColor;
            this.BarcodeElement.BackColor = this._backColor;

            GetBitmap();
        }
        /// <summary>获取元素图像
        /// 
        /// </summary>
        private void GetBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetBarcode128(this.BarcodeElement);
            this.panelView.BackgroundImage = this.ElementImage;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }
        /// <summary>检测元素的最基本的参数的正确性
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ElementDataIsValid()
        {
            if (string.IsNullOrEmpty(_context)) return false;
            if (_height == 0) return false;
            return true;
        }
        #endregion

        #region 类控件事件
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;

            this.BarcodeElement = new BarcodeElementClass();
            SetBarcodeElement();
            this.DialogResult = DialogResult.OK;
        }
        private void TxtHeight_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtHeight.Text, out this._height);
        }

        private void FormBarcodeElement_Load(object sender, EventArgs e)
        {
            InitComboType();
            InitComboRotateFlip();
            InitComboViewText();
            if (this.BarcodeElement != null)
            {
                this._id = this.BarcodeElement.ID;
                this.lblID.Text = this.BarcodeElement.ID;
                this.txtContext.Text = this.BarcodeElement.Context;
                this.txtHeight.Text = this.BarcodeElement.Height.ToString();
                this.txtX.Text = this.BarcodeElement.X.ToString();
                this.txtY.Text = this.BarcodeElement.Y.ToString();
                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.BarcodeElement.RotateFlip);
                this.txtMagnify.Text = this.BarcodeElement.Magnify.ToString();
                this.cboType.SelectedIndex = this.cboType.Items.IndexOf(this.BarcodeElement.Type.ToString());
                this.cboViewText.SelectedIndex = this.cboViewText.Items.IndexOf(this.BarcodeElement.TextPosition.ToString());
                if (this.BarcodeElement.ViewTextFont != null)
                {
                    this._font = this.BarcodeElement.ViewTextFont;
                    this.lblFont.Text = this.BarcodeElement.ViewTextFont.ToString();
                }
                this._mapping = this.BarcodeElement.Mapping;
                this.TxtMapping.Text = this.BarcodeElement.Mapping;
                this.LblForeColor.BackColor = this.BarcodeElement.ForeColor;
                this.LblBackColor.BackColor = this.BarcodeElement.BackColor;
            }
            else
            {   //新建Barcode元素
                this.lblID.Text = this._id;
                this.txtMagnify.Text = "1";
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

        private void TxtMagnify_TextChanged(object sender, EventArgs e)
        {
            byte.TryParse(this.txtMagnify.Text, out this._magnify);
            if (this._magnify <= 0) this._magnify = 1;
        }

        private void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._type = this.cboType.Text;
        }

        private void CboViewText_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._textPosition = this.cboViewText.Text;
            this.btnFont.Enabled = this.cboViewText.SelectedIndex == 0 ? false : true;
            // this._font = this._font == null ? new Font("宋体", 9f) : this._font;
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetBarcodeElement();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            if (this.BarcodeElement == null) this.BarcodeElement = new BarcodeElementClass();
            SetBarcodeElement();
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
        #endregion
    }
}
