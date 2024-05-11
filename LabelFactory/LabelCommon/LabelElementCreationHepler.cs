using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace LabelCommon
{
    /// <summary>创建标签元素的类，标签中的所有元素都由此类创建。
    /// 
    /// </summary>
    public class LabelElementCreationHepler
    {


        /// <summary>获得直线元素图像
        /// 
        /// </summary>
        /// <param name="lec">LineElementClass</param>
        /// <returns>(Bitmap)直线元素图像</returns>
        public static Bitmap GetLine(LineElementClass lec)
        {
            Bitmap bitmap = new((int)lec.Length, (int)lec.Thickness);
            using Graphics graphics = Graphics.FromImage(bitmap);
            InitGraphics(graphics);
            for (int i = 0; i <= lec.Thickness; i++)
            {
                graphics.DrawLine(new Pen(lec.ForeColor, 1), 0, i, lec.Length, i);//只有前景色
            }

            BitmapRotateFlip(bitmap, lec.RotateFlip);//旋转及翻转
            return bitmap;
        }

        /// <summary>获得文字元素图像
        /// 
        /// </summary>
        /// <param name="tec">TextElementClass</param>
        /// <returns>(Bitmap)文字元素图像</returns>
        public static Bitmap GetText(TextElementClass tec)
        {
            Bitmap bitmap = new(1, 1);//小图像
            using Graphics g = Graphics.FromImage(bitmap);
            //InitGraphics(graphics);
            SizeF drawSize = g.MeasureString(tec.Context, tec.TextFont);//取得字符串图像的大小
            Rectangle rec = GetRectangle(tec.TextAlign, drawSize, tec.Width, tec.Height);
            bitmap = new Bitmap(rec.Width, rec.Height);

            using Graphics graphics = Graphics.FromImage(bitmap);
            if (tec.Inversion)
            {
                graphics.Clear(tec.ForeColor);
                graphics.DrawString(tec.Context, tec.TextFont, new SolidBrush(tec.BackColor), rec.X, rec.Y);
            }
            else
            {
                graphics.Clear(tec.BackColor);
                graphics.DrawString(tec.Context, tec.TextFont, new SolidBrush(tec.ForeColor), rec.X, rec.Y);
            }

            BitmapRotateFlip(bitmap, tec.RotateFlip);//旋转及翻转
            return bitmap;
        }

        /// <summary>获得图像元素图像
        /// 
        /// </summary>
        /// <param name="iec">ImageElementClass</param>  
        /// <returns>Bitmap)图像元素图像</returns>
        public static Bitmap GetImage(ImageElementClass iec)
        {
            using Image img = Image.FromFile(iec.FileFullPath);
            Bitmap bmp = new(img.Width, img.Height, PixelFormat.Format32bppArgb);
            using Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawImage(img, 0, 0);

            BitmapRotateFlip(bmp, iec.RotateFlip);
            //graphics.Dispose();
            return bmp;
        }

        /// <summary>获得Code128条码元素图像，
        /// 使用BarCode128Class
        /// </summary>
        /// <param name="bec">BarcodeElementClass</param>
        /// <returns>Code128条码元素图像</returns>
        public static Bitmap GetBarcode128(BarcodeElementClass bec)
        {
            BarCode128Class bar128 = new(bec.ForeColor, bec.BackColor);
            Bitmap bm = bar128.Build(bec.Context, bec.Height, bec.Magnify, bec.Type, bec.ViewTextFont, bec.TextPosition);
            // bm.RotateFlip((RotateFlipType)Enum.Parse(typeof(RotateFlipType), bec.RotateFlip));
            BitmapRotateFlip(bm, bec.RotateFlip);//旋转及翻转
            //graphics.Dispose();
            return bm;
        }

        /// <summary>生成Barcode128条码图形,
        /// 使用ZXing.dll
        /// 不推荐使用
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码总高度</param>
        /// <returns>(Bitmap)条码图形</returns>
        public static Bitmap GetBarcode128(string context, int height)
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter
            {
                Renderer = new ZXing.Rendering.BitmapRenderer { Background = Color.White, Foreground = Color.Black },
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions()
                {
                    GS1Format = false,
                    // GS1Format = true ,
                    Height = height,    //高度值太小会引发IndexOutOfRangeException
                    Margin = 0,
                    PureBarcode = false    //true:不显示字符，false:显示字符
                }
            };
            return bw.Write(context);
        }

        /// <summary>生成Barcode128条码图形
        /// 使用ZXing.dll
        /// 不推荐使用
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码总高度</param>
        /// <param name="gs1">GS1Format</param>
        /// <param name="pure">PureBarcode</param>
        /// <returns>(Bitmap)条码图形</returns>
        public static Bitmap GetBarcode128(string context, int height, bool gs1, bool pure)
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Renderer = new ZXing.Rendering.BitmapRenderer { Background = Color.White, Foreground = Color.Black };
            bw.Format = ZXing.BarcodeFormat.CODE_128;
            bw.Options = new ZXing.Common.EncodingOptions()
            {
                GS1Format = gs1,
                // GS1Format = true ,
                Height = height,    //高度值太小会引发IndexOutOfRangeException
                Margin = 0,
                PureBarcode = pure  //true:不显示字符，false:显示字符
            };
            return bw.Write(context);
        }

        /// <summary>获得QrCode二维码元素图像，
        /// 使用Gma.QrCodeNet库
        /// </summary>
        /// <param name="qcec">QrCodeElementClass</param>
        /// <returns>QrCode二维码元素图像</returns>
        public static Bitmap GetQrcodeGma(QrCodeElementClass qcec)
        {
            ErrorCorrectionLevel ecl = (ErrorCorrectionLevel)Enum.Parse(typeof(ErrorCorrectionLevel), qcec.ErrorCorrectionLevel);
            QrEncoder qr = new Gma.QrCodeNet.Encoding.QrEncoder(ecl);
            QrCode code = qr.Encode(qcec.Context);
            
            GraphicsRenderer gr = new(new FixedModuleSize(qcec.Magnify, QuietZoneModules.Zero), new SolidBrush(qcec.ForeColor ), new SolidBrush(qcec.BackColor));
            DrawingSize dSize = gr.SizeCalculator.GetSize(code.Matrix.Width);
            Bitmap bm = new(dSize.CodeWidth, dSize.CodeWidth);
            using Graphics graphics = Graphics.FromImage(bm);

            gr.Draw(graphics, code.Matrix);
            BitmapRotateFlip(bm, qcec.RotateFlip);


            return bm;
        }

        /// <summary>获得DataMatrix二维码元素图像，
        /// 使用ZXing.dll
        /// </summary>
        /// <param name="dmec">DataMatrixElementClass</param>
        /// <returns>DM二维码元素图像</returns>
        public static Bitmap GetDataMatrixZing(DataMatrixElementClass dmec)
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Format = ZXing.BarcodeFormat.DATA_MATRIX;
            bw.Options = new ZXing.Datamatrix.DatamatrixEncodingOptions()
            {
                Margin = 0,
                //Width = 72,
                //Height = 72,

                DefaultEncodation = ZXing.Datamatrix.Encoder.Encodation.ASCII,
                SymbolShape = ZXing.Datamatrix.Encoder.SymbolShapeHint.FORCE_SQUARE,
            };
            Bitmap bm = bw.Write(dmec.Context);
            BitmapRotateFlip(bm, dmec.RotateFlip);//旋转及翻转
            //graphics.Dispose();
            return bm;
        }


        private static Bitmap GetQrcodeZxing(QrCodeElementClass qcec)//不推荐使用
        {
            ZXing.BarcodeWriter bw = new()
            {
                Format = ZXing.BarcodeFormat.QR_CODE,

                Options = new ZXing.QrCode.QrCodeEncodingOptions()
                {
                    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
                    // DisableECI = false,
                    Margin = 0,

                }
            };
            Bitmap bm0 = bw.Write(qcec.Context);
            BitmapRotateFlip(bm0, qcec.RotateFlip);

            int w = bm0.Width * qcec.Magnify;
            int h = bm0.Height * qcec.Magnify;
            Bitmap bm = new(w + 8, h + 8);
            using (Graphics graphics = Graphics.FromImage(bm))
            {
                InitGraphics(graphics);
                Rectangle destRect = new(0, 0, w, h);
                graphics.DrawImage(bm0, destRect);
            }
            return bm;
        }

        private static Bitmap GetQrcode(string context)//不推荐使用
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            bw.Options = new ZXing.QrCode.QrCodeEncodingOptions()
            {
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
            };
            return bw.Write(context);
        }

        private static Bitmap GetDataMetrix(string context)//不推荐使用
        {
            ZXing.BarcodeWriter bw = new ZXing.BarcodeWriter();
            bw.Format = ZXing.BarcodeFormat.DATA_MATRIX;
            bw.Options = new ZXing.Datamatrix.DatamatrixEncodingOptions()
            {
                DefaultEncodation = ZXing.Datamatrix.Encoder.Encodation.ASCII,
                SymbolShape = ZXing.Datamatrix.Encoder.SymbolShapeHint.FORCE_SQUARE,

            };
            return bw.Write(context);
        }

        /// <summary>初始化Graphics对象
        /// 
        /// </summary>
        /// <param name="graphics">Graphics</param>
        private static void InitGraphics(Graphics graphics)
        {
            graphics.Clear(Color.White);   //背景用白色填充，否则是黑色的
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        }

        /// <summary>添加文字托盘
        /// 
        /// </summary>
        /// <param name="ca">文字对齐方式</param>
        /// <param name="sizeF">文字所占用的矩形框大小</param>
        /// <param name="width">托盘宽度</param>
        /// <param name="height">托盘高度</param>
        /// <returns></returns>
        private static Rectangle GetRectangle(ContentAlignment ca, SizeF sizeF, int width, int height)
        {
            int src_w = (int)Math.Ceiling(sizeF.Width);
            int src_h = (int)Math.Ceiling(sizeF.Height);
            int x = 0, y = 0;
            int w = Math.Max(src_w, width);
            int h = Math.Max(src_h, height);
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                    x = y = 0;
                    break;
                case ContentAlignment.TopCenter:
                    y = 0;
                    x = (w - src_w) / 2;
                    break;
                case ContentAlignment.TopRight:
                    y = 0;
                    x = w - src_w;
                    break;
                case ContentAlignment.MiddleLeft:
                    x = 0;
                    y = (h - src_h) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    x = (w - src_w) / 2;
                    y = (h - src_h) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    x = w - src_w;
                    y = (h - src_h) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    x = 0;
                    y = h - src_h;
                    break;
                case ContentAlignment.BottomCenter:
                    x = (w - src_w) / 2;
                    y = h - src_h;
                    break;
                case ContentAlignment.BottomRight:
                    x = w - src_w;
                    y = h - src_h;
                    break;
            }
            return new Rectangle(x, y, w, h);
        }

        /// <summary>对图像对象进行旋转及翻转
        /// 
        /// </summary>
        /// <param name="bm">图像对象</param>
        /// <param name="rotateFlip">旋转及翻转类型</param>
        private static void BitmapRotateFlip(Bitmap bm, string rotateFlip)
        {
            bm.RotateFlip((RotateFlipType)Enum.Parse(typeof(RotateFlipType), rotateFlip));
        }

        private void Say(string msg = "") => Console.WriteLine($"LabelDesignerClass>>>>{msg}<{DateTime.Now.ToLongTimeString()}>");

    }
}
