using System;
using System.Drawing;
using System.Windows.Forms;
using LabelCommon;

namespace LabelDesigner
{
    public partial class FormDataMatrixElement : Form
    {
        #region 类属性
        public DataMatrixElementClass DataMatrixElement { get; private set; }
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
        #endregion

        #region 类构造器
        public FormDataMatrixElement(string id)
        {
            InitializeComponent();
            this.DataMatrixElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormDataMatrixElement(DataMatrixElementClass dmec)
        {
            InitializeComponent();
            this.DataMatrixElement = dmec;
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
            this.DataMatrixElement.ID = this._id;
            this.DataMatrixElement.Context = this._context;
            this.DataMatrixElement.RotateFlip = this._rotateFlip;
            this.DataMatrixElement.X = this._x;
            this.DataMatrixElement.Y = this._y;
            this.DataMatrixElement.ErrorCorrectionLevel = this._errorCorrectionLevel;
            this.DataMatrixElement.Magnify = this._magnify;
            this.DataMatrixElement.Mapping = this._mapping;
            GetBitmap();
        }

        private void GetBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetDataMatrixZing(this.DataMatrixElement);

            this.panelView.BackgroundImage = this.ElementImage;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }

        private void FormTextElement_Load(object sender, EventArgs e)
        {
            InitComboErrorCorrectionLevel();
            InitComboRotateFlip();

            if (this.DataMatrixElement != null)
            {
                this._id = this.DataMatrixElement.ID;
                this.lblID.Text = this.DataMatrixElement.ID;
                this.txtContext.Text = this.DataMatrixElement.Context;
                this.txtX.Text = this.DataMatrixElement.X.ToString();
                this.txtY.Text = this.DataMatrixElement.Y.ToString();
                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.DataMatrixElement.RotateFlip);
                this.cboErrorCorrectionLevel.SelectedIndex = this.cboErrorCorrectionLevel.Items.IndexOf(this.DataMatrixElement.ErrorCorrectionLevel);
                this.txtMagnify.Text = this.DataMatrixElement.Magnify.ToString();
                this._mapping = this.DataMatrixElement.Mapping;
                this.TxtMapping.Text = this.DataMatrixElement.Mapping;
            }
            else
            {   //新建元素
                this.lblID.Text = this._id;
                this.txtMagnify.Text = this._magnify.ToString();
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
            if (this.DataMatrixElement == null) this.DataMatrixElement = new DataMatrixElementClass();
            SetElement();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (!ElementDataIsValid()) return;
            this.DataMatrixElement = new DataMatrixElementClass();
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
    }
}