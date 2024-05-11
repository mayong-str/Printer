using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabelCommon;

namespace LabelDesigner
{
    public partial class FormImageElement : Form
    {
        #region 类属性
        public ImageElementClass ImageElement { get; private set; }
        public Bitmap ElementImage { get; private set; }
        #endregion

        #region 类私有成员变量
        private string _id;
        private string _fileFullPath = "";
        private string _rotateFlip = "RotateNoneFlipNone";
        private int _x = 0;
        private int _y = 0;

        #endregion

        #region 类构造器
        public FormImageElement(string id)
        {
            InitializeComponent();
            this.ImageElement = null;
            this.btnEdit.Enabled = false;
            this.btnNew.Enabled = true;
            this._id = id;
        }

        public FormImageElement(ImageElementClass ie)
        {
            InitializeComponent();
            this.ImageElement = ie;
            this.btnEdit.Enabled = true;
            this.btnNew.Enabled = false;
        }
        #endregion

        private void initComboRotateFlip()
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

        private bool elementDataIsValid()
        {
            if (string.IsNullOrEmpty(_fileFullPath)) return false;
            return true;
        }

        private void setElement()
        {
            this.ImageElement.ID = this._id;
            this.ImageElement.FileFullPath = this._fileFullPath;
            this.ImageElement.RotateFlip = this._rotateFlip;
            this.ImageElement.X = this._x;
            this.ImageElement.Y = this._y;

            getBitmap();
        }

        private void getBitmap()
        {
            this.ElementImage = LabelElementCreationHepler.GetImage(this.ImageElement);
            this.panelView.BackgroundImage = this.ElementImage;
            this.panelView.BackgroundImageLayout = ImageLayout.Center;
            this.lblSize.Text = string.Format("W {0}\rH {1}", this.ElementImage.Width, this.ElementImage.Height);
        }

        private void FormImagetElement_Load(object sender, EventArgs e)
        {
            initComboRotateFlip();

            if (this.ImageElement != null)
            {
                this._id = this.ImageElement.ID;
                this.lblID.Text = this.ImageElement.ID;

                this._fileFullPath = this.ImageElement.FileFullPath;
                this.lblFileFullPath.Text = this.ImageElement.FileFullPath;

                this.txtX.Text = this.ImageElement.X.ToString();
                this.txtY.Text = this.ImageElement.Y.ToString();

                this.cboRotateFlip.SelectedIndex = this.cboRotateFlip.Items.IndexOf(this.ImageElement.RotateFlip);
            }
            else
            {   //新建元素
                this.lblID.Text = this._id;
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
            if (this.ImageElement == null) this.ImageElement = new ImageElementClass();
            setElement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!elementDataIsValid()) return;
            this.ImageElement = new ImageElementClass();
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

        private void btnPath_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = "";
            // this.openFileDialog1.FileName = ;
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this._fileFullPath = this.openFileDialog1.FileName;
                this.lblFileFullPath.Text = this._fileFullPath;
            }
        }


    }
}
