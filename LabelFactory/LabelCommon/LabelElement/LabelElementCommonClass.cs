
using System.Drawing;

namespace LabelCommon
{
    /// <summary>标签元素共通类，
    /// 所有标签元素的父类。
    /// </summary>
    public class LabelElementCommonClass
    {
        /// <summary>标签元素的ID名
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>标签元素的X位置
        /// 
        /// </summary>
        public int X { get; set; }
        /// <summary>标签元素的Y位置
        /// 
        /// </summary>
        public int Y { get; set; }
        /// <summary>标签元素的前景颜色，
        /// 默认：纯黑色/Color.Black/。
        /// </summary>
        public Color ForeColor { get; set; } = Color.Black;
        /// <summary>标签元素的背景颜色，
        /// 默认：纯白色/Color.White/。
        /// </summary>
        public Color BackColor { get; set; } = Color.White;

        public override string ToString()
        {
            return this.ID;
        }
    }
}
