
namespace LabelCommon
{
    /// <summary>QrCode元素类，
    /// LabelElementCommonClass类的子类。
    /// </summary>
    public class QrCodeElementClass : LabelElementCommonClass
    {
        /// <summary>二维码的内容
        /// 
        /// </summary>
        public string Context { get; set; }
        /// <summary>QrCode纠错等级
        /// 
        /// </summary>
        public string ErrorCorrectionLevel { get; set; }

        /// <summary>旋转和翻转
        /// 
        /// </summary>
        public string RotateFlip { get; set; }

        /// <summary>放大倍率
        /// 
        /// </summary>
        public byte Magnify { get; set; }

        /// <summary>反白
        /// 
        /// </summary>
        // public bool Inversion { get; set; }

        /// <summary>字段映射
        /// 
        /// </summary>
        public string Mapping { get; set; }
    }
}
