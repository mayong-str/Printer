using System.Drawing;

namespace LabelCommon
{
    /// <summary>Barcode元素类，存放Barcode元素参数，
    /// LabelElementCommonClass类的子类。
    /// </summary>
    public class BarcodeElementClass : LabelElementCommonClass
    {
        /// <summary>条码的内容
        /// 
        /// </summary>
        public string Context { get; set; }
        /// <summary>元素的总高度，以点数为单位
        /// 
        /// </summary>
        public int Height { get; set; }
 
        /// <summary>旋转和翻转
        /// 
        /// </summary>
        public string RotateFlip { get; set; }
        /// <summary>条码宽度系数
        /// 
        /// </summary>
        public byte Magnify { get; set; }
        /// <summary>条码类型
        /// 
        /// </summary>
        public Barcode.Type Type { get; set; }
        /// <summary>条码是否显示文本、及文本的位置
        /// 
        /// </summary>
        public Barcode.TextPosition TextPosition { get; set; }
        /// <summary>条码显示文本的字体
        /// 
        /// </summary>
        public Font ViewTextFont { get; set; }

        /// <summary>字段映射
        /// 
        /// </summary>
        public string Mapping { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
