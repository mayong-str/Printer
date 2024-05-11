
namespace LabelCommon
{
    /// <summary>Barcode的一些基本参数
    /// 
    /// </summary>
    public class Barcode
    {
        /// <summary>条码类别
        /// 
        /// </summary>
        public enum Type
        {
            Code128A,//仅包含数字和大写字母
            Code128B,//包含大小写字母和数字，最常用。
            Code128C,//仅包含从00-99的两位数数字，长度必须是偶数
            EAN128
        }
        /// <summary>显示文本的位置
        /// 
        /// </summary>
        public enum TextPosition
        {
            /// <summary>不显示
            /// 
            /// </summary>
            NotShow,
            /// <summary>顶部左侧
            /// 
            /// </summary>
            TopLeft,
            /// <summary>顶部居中
            /// 
            /// </summary>
            TopCenter,
            /// <summary>顶部右侧
            /// 
            /// </summary>
            TopRight,
            /// <summary>底部左侧
            /// 
            /// </summary>
            BottomLeft,
            /// <summary>底部居中
            /// 
            /// </summary>
            BottomCenter,
            /// <summary>底部右侧
            /// 
            /// </summary>
            BottomRight
        }
    }
}
