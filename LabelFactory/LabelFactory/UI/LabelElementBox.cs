using LabelCommon;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LabelDesigner
{
    class LabelElementBox : PictureBox
    {
        /// <summary>获取根据标签元素数据生成的原始Bitmap
        /// 
        /// </summary>
        public Bitmap ElementBitmap { get; private set; }

        /// <summary>是否显示边框，处于编辑模式显示边框，预览模式不显示边框。
        /// /true:显示边框,false:不显示边框/
        /// </summary>
        public bool IsShowBox
        {
            get => this._isShowBox;
            set
            {
                this._isShowBox = value;
                ShowBitmap();
            }
        }

        /// <summary>获取或设置标签元素的激活状态
        /// /true:激活,false:未激活/
        /// </summary>
        public bool IsActive
        {
            get => this._isActive;
            set
            {
                this._isActive = value;
                ShowBitmap();
            }
        }

        /// <summary>标签元素ID号
        /// 
        /// </summary>
        public string ID { get; private set; }

        /// <summary>标签元素数据
        /// 
        /// </summary>
        public object ElementData
        {
            get => this._elementData;
            private set
            {
                this._elementData = value;
                GetBitmap();
                ShowBitmap();
            }
        }


        private bool _isActive;
        private object _elementData;
        private bool _isShowBox;

        public LabelElementBox(object element)
        {
            InitializeComponent();
            this.ElementData = element;

        }

        /// <summary>根据标签元素数据获取标签元素原始Bitmap
        /// 
        /// </summary>
        private void GetBitmap()
        {
            if (this.ElementData.GetType() == typeof(BarcodeElementClass))
            {
                BarcodeElementClass bec = (BarcodeElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetBarcode128(bec);
                this.Tag = this.ID = bec.ID;
                this.Location = new Point(bec.X, bec.Y);
            }
            else if (this.ElementData.GetType() == typeof(TextElementClass))
            {
                TextElementClass tec = (TextElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetText(tec);
                this.Tag = this.ID = tec.ID;
                this.Location = new Point(tec.X, tec.Y);
            }
            else if (this.ElementData.GetType() == typeof(QrCodeElementClass))
            {
                QrCodeElementClass qcec = (QrCodeElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetQrcodeGma(qcec);
                this.Tag = this.ID = qcec.ID;
                this.Location = new Point(qcec.X, qcec.Y);
            }
            else if (this.ElementData.GetType() == typeof(DataMatrixElementClass))
            {
                DataMatrixElementClass dmec = (DataMatrixElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetDataMatrixZing(dmec);
                this.Tag = this.ID = dmec.ID;
                this.Location = new Point(dmec.X, dmec.Y);
            }
            else if (this.ElementData.GetType() == typeof(LineElementClass))
            {
                LineElementClass lec = (LineElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetLine(lec);
                this.Tag = this.ID = lec.ID;
                this.Location = new Point(lec.X, lec.Y);
            }
            else if (this.ElementData.GetType() == typeof(ImageElementClass))
            {
                ImageElementClass iec = (ImageElementClass)this.ElementData;
                this.ElementBitmap = LabelElementCreationHepler.GetImage(iec);
                this.Tag = this.ID = iec.ID;
                this.Location = new Point(iec.X, iec.Y);
            }
        }

        /// <summary>显示标签元素Bitmap
        /// 
        /// </summary>
        private void ShowBitmap()
        {
            this.Height = this.ElementBitmap.Height;
            this.Width = this.ElementBitmap.Width;

            this.Image = this.ElementBitmap.Clone(new Rectangle(0, 0, this.ElementBitmap.Width, this.ElementBitmap.Height), PixelFormat.Format24bppRgb);

            if (this.IsShowBox == true) ShowBox();
            //graphics.Clear(Color.White);   //背景用白色填充，否则是黑色的
            //graphics.InterpolationMode = InterpolationMode.NearestNeighbor;     
        }

        /// <summary>显示标签元素Bitmap的边框
        /// 
        /// </summary>
        private void ShowBox()
        {
            Graphics graphics = Graphics.FromImage(this.Image);
            Rectangle destRect;
            if (this.Image.Height == 1 || this.Image.Width == 1)
            {
                destRect = new Rectangle(0, 0, this.ElementBitmap.Width, this.ElementBitmap.Height);
            }
            else
            {
                destRect = new Rectangle(0, 0, this.ElementBitmap.Width - 1, this.ElementBitmap.Height - 1);
            }

            if (this._isActive == true)
            {
                // graphics.DrawRectangle(new Pen(Color.LightGreen), destRect);
                graphics.DrawRectangle(new Pen(Color.Magenta), destRect);
                if (this.ElementData.GetType() != typeof(LineElementClass)) GetIdBitmap(graphics, destRect);
            }
            else
            {   //LineElementClass标签元素只有激活时才显示边框
                if (this.ElementData.GetType() != typeof(LineElementClass)) graphics.DrawRectangle(new Pen(Color.LightGray), destRect);
            }
        }

        private void GetIdBitmap(Graphics graphics, Rectangle destRect)
        {
            Bitmap bitmap = new(1, 1);//小图像
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new("Arial", 8, FontStyle.Regular);
            Size drawSize = g.MeasureString(this.ID, font).ToSize();//取得字符串图像的大小
            graphics.DrawString($"{this.Left},{this.Top}", font, new SolidBrush(Color.Magenta), 1, 1);
            graphics.DrawString(this.ID, font, new SolidBrush(Color.Magenta), 1, destRect.Height - drawSize.Height - 1);
        }

        public override string ToString() => $"ID:{this.ID}X:{this.Location.X},Y:{this.Location.Y},Width:{this.Width},Height:{this.Height}";


        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelElementBox
            // 
            this.DoubleClick += new EventHandler(this.LabelElementBox_DoubleClick);
            this.MouseDown += new MouseEventHandler(this.LabelElementBox_MouseDown);
            this.MouseMove += new MouseEventHandler(this.LabelElementBox_MouseMove);
            this.MouseUp += new MouseEventHandler(this.LabelElementBox_MouseUp);
            this.LocationChanged += LabelElementBox_LocationChanged;

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void LabelElementBox_LocationChanged(object sender, EventArgs e)
        {
            ShowBitmap();
        }

        #region 标签元素鼠标拖曳移动处理
        private Point pPoint; //上个鼠标坐标
        private Point currPoint;//当前鼠标坐标
        private void LabelElementBox_MouseDown(object sender, MouseEventArgs e)
        {
            pPoint = Cursor.Position;
        }

        private void LabelElementBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsActive == false) return;//不处于激活状态不响应事件
            Cursor.Current = Cursors.SizeAll; //当鼠标处于控件内部时，显示光标样式为SizeAll
            //当鼠标左键按下时才触发
            if (e.Button == MouseButtons.Left)
            {
                currPoint = Cursor.Position; //获得当前鼠标位置
                int x = currPoint.X - pPoint.X;
                int y = currPoint.Y - pPoint.Y;
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);
                pPoint = currPoint;
            }
        }

        private void LabelElementBox_MouseUp(object sender, MouseEventArgs e)
        {
            LabelElementCommonClass lbe = (LabelElementCommonClass)this.ElementData;
            lbe.X = this.Location.X;
            lbe.Y = this.Location.Y;
        }

        #endregion

        /// <summary>标签元素鼠标双击处理
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelElementBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsActive == false) return;//不处于激活状态不响应事件
            if (this.ElementData.GetType() == typeof(BarcodeElementClass))
            {
                FormBarcodeElement formBarcodeElement = new((BarcodeElementClass)this.ElementData);
                if (formBarcodeElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formBarcodeElement.BarcodeElement;
                }
            }
            else if (this.ElementData.GetType() == typeof(TextElementClass))
            {
                FormTextElement formTextElement = new((TextElementClass)this.ElementData);
                if (formTextElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formTextElement.TextElement;
                }
            }
            else if (this.ElementData.GetType() == typeof(QrCodeElementClass))
            {
                FormQrCodeElement formQrCodeElement = new((QrCodeElementClass)this.ElementData);
                if (formQrCodeElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formQrCodeElement.QrCodeElement;
                }
            }
            else if (this.ElementData.GetType() == typeof(DataMatrixElementClass))
            {
                FormDataMatrixElement formDataMatrixElement = new((DataMatrixElementClass)this.ElementData);
                if (formDataMatrixElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formDataMatrixElement.DataMatrixElement;
                }
            }
            else if (this.ElementData.GetType() == typeof(LineElementClass))
            {
                FormLineElement formLineElement = new((LineElementClass)this.ElementData);
                if (formLineElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formLineElement.LineElement;
                }
            }
            else if (this.ElementData.GetType() == typeof(ImageElementClass))
            {
                FormImageElement formImageElement = new((ImageElementClass)this.ElementData);
                if (formImageElement.ShowDialog() == DialogResult.OK)
                {
                    this.ElementData = formImageElement.ImageElement;
                }
            }
        }
    }
}
