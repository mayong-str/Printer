using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    /******************************************************************
    * 创 建 人： SamWang
    * 创建时间： 2012-5-10 16:06
    * 描 述：
    *    移动控件但不改变大小
    * 原 理：
    * 版 本： V1.0  
    * 环 境： VS2010
    ******************************************************************/
    public class MoveControl
    {
        #region Constructors
        public MoveControl(Control ctrl)
        {
            this.currentControl = ctrl;
            AddEvents();//挂载鼠标事件
        }
        #endregion

        #region Fields
        /// <summary>传入的控件
        /// 
        /// </summary>
        private readonly Control currentControl; //传入的控件
        /// <summary>上一鼠标坐标
        /// 
        /// </summary>
        private Point previousPosition; //上个鼠标坐标
        /// <summary>当前鼠标坐标
        /// 
        /// </summary>
        private Point currentPosition; //当前鼠标坐标
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// 挂载事件
        /// </summary>
        private void AddEvents()
        {
            this.currentControl.MouseDown += new MouseEventHandler(MouseDown);
            this.currentControl.MouseMove += new MouseEventHandler(MouseMove);
            this.currentControl.MouseUp += new MouseEventHandler(MouseUp);
        }
        /// <summary>
        /// 绘制拖拉时的黑色边框
        /// </summary>
        public static void DrawDragBound(Control ctrl)
        {
            ctrl.Refresh();
            Graphics g = ctrl.CreateGraphics();
            int width = ctrl.Width;
            int height = ctrl.Height;
            Point[] ps = new Point[5] { new Point(0, 0), new Point(width - 1, 0), new Point(width - 1, height - 1), new Point(0, height - 1), new Point(0, 0) };
            g.DrawLines(new Pen(Color.Black), ps);
        }
        #endregion

        #region Events
        /// <summary>
        /// 鼠标按下事件：记录当前鼠标相对窗体的坐标
        /// </summary>
        void MouseDown(object sender, MouseEventArgs e)
        {
            this.previousPosition = Cursor.Position;
        }
        /// <summary>
        /// 鼠标移动事件：让控件跟着鼠标移动
        /// </summary>
        void MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeAll; //当鼠标处于控件内部时，显示光标样式为SizeAll
            //当鼠标左键按下时才触发
            if (e.Button == MouseButtons.Left)
            {
                MoveControl.DrawDragBound(this.currentControl);
                this.currentPosition = Cursor.Position; //获得当前鼠标位置
                int x = this.currentPosition.X - this.previousPosition.X;
                int y = this.currentPosition.Y - this.previousPosition.Y;
                this.currentControl.Location = new Point(this.currentControl.Location.X + x, this.currentControl.Location.Y + y);
                this.previousPosition = this.currentPosition;
            }
        }
        /// <summary>
        /// 鼠标弹起事件：让自定义的边框出现
        /// </summary>
        void MouseUp(object sender, MouseEventArgs e)
        {
            this.currentControl.Refresh();
        }
        #endregion
    }
}
