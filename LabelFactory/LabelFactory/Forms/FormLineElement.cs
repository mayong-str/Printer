using LabelCommon;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class FormLineElement : Form
    {
        #region 类属性
        public LineElementClass LineElement { get; private set; }
        public Bitmap ElementImage { get; private set; }
        #endregion

        #region 类私有成员变量
        private string _id;
        private string _rotateFlip = "RotateNoneFlipNone";
        private int _x = 0;
        private int _y = 0;
        private uint _length = 1;
        private uint _thick = 1;
        private Color _foreColor = Color.Black;
        private Color _backColor = Color.White;

        #endregion

        #region 类构造器
        public FormLineElement(string id)
        {
            InitializeComponent();
            this.LineElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormLineElement(LineElementClass le)
        {
            InitializeComponent();
            this.LineElement = le;
            this.btnEdit.Enabled = true;
            this.btnNew.Enabled = false;
        }
        #endregion

        private void initComboRotateFlip()
        {
            this.cboRotateFlip.Items.Add("RotateNoneFlipNone");//0
            this.cboRotateFlip.Items.Add("Rotate90FlipNone");//1
            //this.cboRotateFlip.Items.Add("Rotate180FlipNone");//2
            //this.cboRotateFlip.Items.Add("Rotate270FlipNone");//3
            //this.cboRotateFlip.Items.Add("RotateNoneFlipX");//4
            //this.cboRotateFlip.Items.Add("Rotate90FlipX");//5
            //this.cboRotateFlip.Items.Add("RotateNoneFlipY");//6
            //this.cboRotateFlip.Items.Add("Rotate90FlipY");//7
            this.cboRotateFlip.SelectedIndex = 0;
        }

        private bool elementDataIsValid()
        {
            if (_length <= 0) return false;
            if (_thick <= 0) return false; ;
            return true;
        }

        private void setElement()
        {
            this.LineElement.ID = this._id;
            this.LineElement.RotateFlip = this._rotateFlip;
            this.LineElement.X = this._x;
            this.LineElement.Y = this._y;
            this.LineElement.Length = this._length;
            this.LineElement.Thickness = this._thick;
            this.LineElement.ForeColor = this._foreColor;
            this.LineElement.BackColor = this._backColor;

            getBitmap();
        }

        private void getBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetLine(this.LineElement);
            this.panelView.BackgroundImage = this.ElementImage;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }

        private void FormTextElement_Load(object sender, EventArgs e)
        {
            initComboRotateFlip();

            if (this.LineElement != null)
            {
                this._id = this.LineElement.ID;
                this.lblID.Text = this.LineElement.ID;
                this.txtX.Text = this.LineElement.X.ToString();
                this.txtY.Text = this.LineElement.Y.ToString();
                this.txtLength.Text = this.LineElement.Length.ToString();
                this.txtTickness.Text = this.LineElement.Thickness.ToString();
                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.LineElement.RotateFlip);
                this.LblForeColor.BackColor = this.LineElement.ForeColor;
                //this.LblBackColor.BackColor = this.BarcodeElement.BackColor;
            }
            else
            {   //新建Text元素
                this.lblID.Text = this._id;
                this.txtLength.Text = this._length.ToString();
                this.txtTickness.Text = this._thick.ToString();
                this.LblForeColor.BackColor = this._foreColor;
                //this.LblBackColor.BackColor = this._backColor;
            }
        }

        private void cboRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._rotateFlip = this.cboRotateFlip.Text;
        }


        private void txtX_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtX.Text, out this._x);
        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(this.txtY.Text, out this._y);
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (!elementDataIsValid()) return;
            if (this.LineElement == null) this.LineElement = new LineElementClass();
            setElement();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!elementDataIsValid()) return;
            this.LineElement = new LineElementClass();
            setElement();
            this.DialogResult = DialogResult.OK;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setElement();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            uint.TryParse(this.txtLength.Text, out this._length);
        }

        private void txtTickness_TextChanged(object sender, EventArgs e)
        {
            uint.TryParse(this.txtTickness.Text, out this._thick);
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
            }
            lbl.BackColor = cd.Color;
        }

        private void LblForeColor_BackColorChanged(object sender, EventArgs e)
        {
            this._foreColor = this.LblForeColor.BackColor;
        }
    }
}
