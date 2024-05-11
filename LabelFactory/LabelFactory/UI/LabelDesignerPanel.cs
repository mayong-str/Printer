using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class LabelDesignerPanel : UserControl
    {
        #region 类属性

        /// <summary>获取或设置编辑模式，
        /// /true:编辑模式,false:预览模式/
        /// </summary>
        public bool EditMode
        {
            get => this._editMode;
            set
            {
                this._editMode = value;
                ElementsInactive();
                this.BackColor = this._editMode ? Color.LightYellow : Color.White;
            }
        }

        /// <summary>获取标签中的元素集合
        /// 
        /// </summary>
        public ArrayList LabelElements
        {
            get
            {
                ArrayList al = new();
                foreach (var item in this.Controls)
                {
                    if (item.GetType() == typeof(LabelElementBox))
                    {
                        LabelElementBox li = (LabelElementBox)item;
                        al.Add(li.ElementData);
                    }
                }
                return al;
            }
        }

        public int Grid { get; set; } = 4;

        public bool DisplayGrid
        {
            get { return _displayGrid; }
            set
            {
                _displayGrid = value;
                DrawGrid();
            }
        }

        #endregion

        #region 类构造器
        public LabelDesignerPanel()
        {
            InitializeComponent();
            InitThisPanel();
        }


        #endregion

        private void InitThisPanel()
        {
            int x = Global.WorkLabel.BasicInfo.LabelDotX;
            int y = Global.WorkLabel.BasicInfo.LabelDotY;
            this.ClientSize = new Size(x, y);
            ShowElements();
        }

        /// <summary>显示所有的标签元素
        /// 
        /// </summary>
        public void ShowElements()
        {
            foreach (var item in Global.WorkLabel.Elements)
            {
                ShowElement(item);
            }
        }


        public void ShowElement(object element)
        {
            LabelElementBox leb = new(element);
            leb.MouseClick += new MouseEventHandler(ElementMouseClick);
            leb.IsShowBox = this.EditMode;
            this.Controls.Add(leb);
        }


        #region 创建标签元素

        /// <summary>生成标签中新元素的ID
        /// 
        /// </summary>
        /// <param name="str">元素类名</param>
        /// <returns></returns>
        private string GetId(string str)
        {
            int num = 0;
            while (IdExists(str + num.ToString()))
            {
                num += 1;
            }
            return str + num.ToString();
        }

        /// <summary>检查ID是否已存在，
        /// /true:已存在,false:不存在/
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>(bool)</returns>
        private bool IdExists(string id)
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelElementBox))
                {
                    if ((string)item.Tag == id) return true;
                }
            }
            return false;
        }

        /// <summary>添加Barcode标签元素
        /// 
        /// </summary>
        /// <param name="bec"></param>
        public void CreateNewBarcodeElement()
        {
            string id = GetId("Barcode");
            FormBarcodeElement formBarcodeElement = new(id);
            if (formBarcodeElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formBarcodeElement.BarcodeElement);
            }
        }
        public void CreateNewTextElement()
        {
            string id = GetId("Text");
            FormTextElement formTextElement = new(id);
            if (formTextElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formTextElement.TextElement);
            }
        }
        public void CreateNewQrCodeElement()
        {
            string id = GetId("QrCode");
            FormQrCodeElement formQrCodeElement = new(id);
            if (formQrCodeElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formQrCodeElement.QrCodeElement);
            }
        }
        public void CreateNewDataMatrixElement()
        {
            string id = GetId("DataMatrix");
            FormDataMatrixElement formDataMatrixElement = new(id);
            if (formDataMatrixElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formDataMatrixElement.DataMatrixElement);
            }
        }
        public void CreateNewLineElement()
        {
            string id = GetId("Line");
            FormLineElement formLineElement = new(id);
            if (formLineElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formLineElement.LineElement);
            }
        }

        public void CreateNewImageElement()
        {
            string id = GetId("Image");
            FormImageElement formImageElement = new(id);
            if (formImageElement.ShowDialog() == DialogResult.OK)
            {
                ShowElement(formImageElement.ImageElement);
            }
        }
        #endregion 

        private void DrawGrid()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < this.Width; i += this.Grid)
            {
                for (int j = 0; j < this.Height; j += this.Grid)
                {
                    g.FillRectangle(Brushes.Red, i, j, 2, 2);
                }
            }
        }

        private void ElementMouseClick(object sender, MouseEventArgs e)
        {
            if (this.EditMode == false) return;
            LabelElementBox leb = sender as LabelElementBox;
            SetElementActive(leb);
            Say("Element_Click");
        }


        /// <summary>激活选中的标签元素
        /// 
        /// </summary>
        /// <param name="leb">选中的标签元素</param>
        private void SetElementActive(LabelElementBox leb)
        {
            if (leb.IsActive)
            {
                leb.IsActive = false;
                return;
            }
            ElementsInactive();
            leb.IsActive = true;
        }

        /// <summary>使所有标签元素不激活
        /// 
        /// </summary>
        public void ElementsInactive()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(LabelElementBox))
                {
                    LabelElementBox li = (LabelElementBox)item;
                    li.IsShowBox = this.EditMode;
                    li.IsActive = false;
                }
            }
        }

        /// <summary>检查是否有激活的标签元素，
        /// 如有则将其返回，如无则返回null。
        /// </summary>
        /// <returns></returns>
        private LabelElementBox CheckElementActive()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(LabelElementBox))
                {
                    LabelElementBox li = (LabelElementBox)item;
                    if (li.IsActive == true) return li;
                }
            }
            return null;
        }

        private void LabelDesignerPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.EditMode == false) return;
            LabelElementBox leb = CheckElementActive();
            if (null == leb) return;
            Point p = leb.Location;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (DialogResult.Yes == MessageBox.Show($"确定要删除 {leb.ID} 元素吗？", "删除标签元素", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {   //删除元素
                        this.Controls.Remove(leb);
                        Say("Remove>>" + leb.ID);
                    }
                    break;
                case Keys.Up:
                    leb.Location = new Point(p.X, p.Y - 1);//元素向上移动
                    break;
                case Keys.Down:
                    leb.Location = new Point(p.X, p.Y + 1);//元素向下移动
                    break;
                case Keys.Left:
                    leb.Location = new Point(p.X - 1, p.Y);//元素向左移动
                    break;
                case Keys.Right:
                    leb.Location = new Point(p.X + 1, p.Y);//元素向右移动
                    break;
            }

        }

        private void Say(string msg) => Console.WriteLine("LabelDesignerPanel>>>>" + msg);

        private bool _editMode;
        private bool _displayGrid = true;

        private void LabelDesignerPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
