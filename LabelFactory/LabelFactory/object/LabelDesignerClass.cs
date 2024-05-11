using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace LabelFactory
{
    class LabelDesignerClass
    {
        /// <summary>获取设计好的标签Bitmap
        /// 
        /// </summary>
        public Bitmap LabelBitmap { get; private set; }

        public LabelDesignerClass()
            : this(1122, 590)
        {

        }
        public LabelDesignerClass(int widthPixel, int heightPixel)
        {
            this.LabelBitmap = new Bitmap(widthPixel, heightPixel, PixelFormat.Format32bppRgb);
        }
        public LabelDesignerClass(Bitmap bitmap)
        {
            this.LabelBitmap = bitmap;
        }
        private void init()
        {
        }

        public void DesignLable()
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new System.Drawing.Font("Microsoft YaHei", 48f, FontStyle.Italic);
            Rectangle destRect;
            Bitmap bmp;

            Graphics g = Graphics.FromImage(this.LabelBitmap);
            g.Clear(Color.White);   //背景用白色填充，否则是黑色的
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            destRect = new Rectangle(20, 20, this.LabelBitmap.Width - 40, this.LabelBitmap.Height - 40);
            g.DrawRectangle(new Pen(Color.Black, 3), destRect);

            bmp = getBarcode128("1234567890ABC", 50);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);    //旋转90度
            destRect = new Rectangle(100, 100, bmp.Width * 2, bmp.Height * 3);
            g.DrawImage(bmp, destRect);

            bmp = getQrcode("HZHEHUA");
            destRect = new Rectangle(200, 100, bmp.Width * 8, bmp.Height * 8);
            g.DrawImage(bmp, destRect);

            g.DrawString("杭州和华电气", font, brush, 500, 50);

            bmp = new Bitmap(@"E:\MES\启步鞋业\远足\P932104063.bmp");
            destRect = new Rectangle(450, 150, bmp.Width, bmp.Height);
            g.DrawImage(bmp, destRect);

            say("生成标签完成！");
        }

        private Bitmap getBarcode128(string context, int height)
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Renderer = new ZXing.Rendering.BitmapRenderer { Background = Color.White, Foreground = Color.Black };
            bw.Format = ZXing.BarcodeFormat.CODE_128;
            bw.Options = new ZXing.Common.EncodingOptions()
            {
                GS1Format = false,
                // GS1Format = true ,
                Height = height,    //高度值太小会引发IndexOutOfRangeException
                Margin = 0,
                PureBarcode = true    //true:不显示字符，false:显示字符
            };
            return bw.Write(context);
        }

        private Bitmap getQrcode(string context)
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            bw.Options = new ZXing.QrCode.QrCodeEncodingOptions()
            {
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
            };
            return bw.Write(context);
        }

        private void say(string msg)
        {
            Console.WriteLine("LabelDesignerClass>>>>" + msg);
        }
    }
}
