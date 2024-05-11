using System.Drawing;

namespace LabelCommon
{
    /// <summary>字符元素类，
    /// LabelElementCommonClass类的子类。
    /// </summary>
    public class TextElementClass : LabelElementCommonClass
    {
        /// <summary>元素的字符上下文
        /// 
        /// </summary>
        public string Context { get; set; }
        /// <summary>元素的总宽度，以点数为单位
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>元素的总高度，以点数为单位
        /// 
        /// </summary>
        public int Height { get; set; }
        /// <summary>旋转和翻转
        /// 
        /// </summary>
        public string RotateFlip { get; set; }
        /// <summary>文本字体
        /// 
        /// </summary>
        public Font TextFont { get; set; }
        /// <summary>文字反白
        /// 
        /// </summary>
        public bool Inversion { get; set; }
        /// <summary>文本对齐方式
        /// 
        /// </summary>
        public ContentAlignment TextAlign { get; set; }
        /// <summary>字段映射
        /// 
        /// </summary>
        public string Mapping { get; set; }
    }
}
