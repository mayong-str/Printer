using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LabelCommon
{
    /// <summary>处理Image对象和Bitmap对象的助手类
    /// 
    /// </summary>
    public class ImageAndBitmapHelper
    {
        /// <summary>获得从Bitmap对象转换而来的图像Byte数组，
        /// 以PNG格式。
        /// </summary>
        /// <param name="bmp">Bitmap</param>
        /// <returns>Byte数组</returns>
        public static byte[] Bitmap2Bytes_Png(Bitmap bmp)
        {
            using MemoryStream sr = new();
            bmp.Save(sr, ImageFormat.Png);
            int len = (int)sr.Position;
            byte[] ret = new byte[sr.Position];
            sr.Seek(0, SeekOrigin.Begin);
            sr.Read(ret, 0, len);
            return ret;
        }

        /// <summary>获得从图像Byte数组转换而来的Image对象
        /// 
        /// </summary>
        /// <param name="bytes">图像Byte数组</param>
        /// <returns>Image对象</returns>
        public static Image Bytes2Imange(byte[] bytes)
        {
            return Image.FromStream(new MemoryStream(bytes));
        }
    }
}
