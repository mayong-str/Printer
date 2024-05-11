using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LabelCommon.Printer.EPSON
{
    public class EpsonPrinterUtil_ZPLII
    {
        /// <summary>类实例别名
        /// 
        /// </summary>
        public static string Alias { get; set; }

        /// <summary>设置或获取标签图像
        /// 
        /// </summary>
        public static Bitmap LabelBitmap
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value;
                LabelPixelX = _bitmap.Width;
                LabelPixelY = _bitmap.Height;
            }
        }

        //6 个点 = 1 毫米，      152.4 个点 = 1 英寸
        //8 个点 = 1 毫米，      203.2 个点 = 1 英寸
        //12 个点 = 1 毫米，     304.8 个点 = 1 英寸
        //24 个点 = 1 毫米，     609.6 个点 = 1 英寸

        /// <summary>获取标签宽度，像素点数
        /// 
        /// </summary>
        public static int LabelPixelX { get; private set; }

        /// <summary>获取标签高度，像素点数
        /// 
        /// </summary>
        public static int LabelPixelY { get; private set; }

        private static Bitmap _bitmap;

        /// <summary>生成标签打印指令，以传输PNG图像的方式，
        /// 打印分辨率为 300[dpi]
        /// </summary>
        public static byte[] BuildLabel_Png_300()
        {
            byte[] bytes = ImageAndBitmapHelper.Bitmap2Bytes_Png(_bitmap);

            List<byte> returnedList = new();
            returnedList.AddRange(Encoding.ASCII.GetBytes("^XA"));//定义开始
            returnedList.AddRange(Encoding.ASCII.GetBytes("^IDR*.*^FS"));//删除R:中的所有文件

            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,R,300"));//将渲染分辨率设置为 300[dpi]
            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,P,300"));//将当前打印分辨率设置为 300[dpi]
            //returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,Z,300"));//要替换的打印机的打印分辨率 300[dpi]

            returnedList.AddRange(Encoding.ASCII.GetBytes($"^S(CLS,P,{_bitmap.Width}"));//标签宽度
            returnedList.AddRange(Encoding.ASCII.GetBytes($"^S(CLS,L,{_bitmap.Height}"));//标签高度

            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CPC,Q,N"));//设置打印质量：普通
            returnedList.AddRange(Encoding.ASCII.GetBytes("^XZ"));//定义结束

            returnedList.AddRange(Encoding.ASCII.GetBytes($"~DYR:001.PNG,B,P,{bytes.Length},0,"));//下载标签图像
            returnedList.AddRange(bytes);

            returnedList.AddRange(Encoding.ASCII.GetBytes("^XA"));//定义开始
            returnedList.AddRange(Encoding.ASCII.GetBytes("^FO0,0^ILR:001.PNG^FS"));//打印标签
            returnedList.AddRange(Encoding.ASCII.GetBytes("^XZ"));//定义结束

            return returnedList.ToArray();
        }


    }
}
