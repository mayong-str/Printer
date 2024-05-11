using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace LabelCommon
{
    public class LabelClass
    {
        /// <summary>获取标签的基本信息
        /// 
        /// </summary>
        public LabelBasicInfoClass BasicInfo { get; private set; }

        /// <summary>获取或设置标签间隙，毫米。
        /// 
        /// </summary>
        public float VGap { get; set; }

        /// <summary>获取标签元素
        /// 
        /// </summary>
        public ArrayList Elements { get; private set; }

        /// <summary>获取标签的Bitmap
        /// 
        /// </summary>
        public Bitmap LabelBitmap => GetLabelBitmap();

        public LabelClass(LabelBasicInfoClass basicInfo, ArrayList elements) : this()
        {
            this.BasicInfo = basicInfo;
            this.Elements = elements;
        }

        public LabelClass()
        {

        }

        /// <summary>生成整个标签的Bitmap
        /// 
        /// </summary>
        private Bitmap GetLabelBitmap()
        {
            Bitmap bitmap = new(this.BasicInfo.LabelDotX, this.BasicInfo.LabelDotY, PixelFormat.Format24bppRgb);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);   //背景用白色填充，否则是黑色的
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            foreach (var item in this.Elements)
            {
                (Bitmap bm, Point p) = GetElementBitmap(item);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bm, p.X, p.Y);
            }
            return bitmap;
        }
        public Bitmap GetLabelBitmap1(LabelBasicInfoClass BasicInfo, ArrayList Elements)
        {
            Bitmap bitmap = new(BasicInfo.LabelDotX, BasicInfo.LabelDotY, PixelFormat.Format24bppRgb);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);   //背景用白色填充，否则是黑色的
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            foreach (var item in Elements)
            {
                (Bitmap bm, Point p) = GetElementBitmap(item);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bm, p.X, p.Y);
            }
            return bitmap;
        }
        /// <summary>生成标签单个元素的Bitmap
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private (Bitmap, Point) GetElementBitmap(object element)
        {
            Bitmap bm = null;
            Point p = new();
            if (element.GetType() == typeof(BarcodeElementClass))
            {
                BarcodeElementClass bec = (BarcodeElementClass)element;
                bm = LabelElementCreationHepler.GetBarcode128(bec);
                p = new Point(bec.X, bec.Y);
                return (bm, p);  
            }
            if (element.GetType() == typeof(TextElementClass))
            {
                TextElementClass tec = (TextElementClass)element;
                bm = LabelElementCreationHepler.GetText(tec);
                p = new Point(tec.X, tec.Y);
                return (bm, p);
            }
            if (element.GetType() == typeof(QrCodeElementClass))
            {
                QrCodeElementClass qcec = (QrCodeElementClass)element;
                bm = LabelElementCreationHepler.GetQrcodeGma(qcec);
                p = new Point(qcec.X, qcec.Y);
                return (bm, p);
            }
            if (element.GetType() == typeof(DataMatrixElementClass))
            {
                DataMatrixElementClass dmec = (DataMatrixElementClass)element;
                bm = LabelElementCreationHepler.GetDataMatrixZing(dmec);
                p = new Point(dmec.X, dmec.Y);
                return (bm, p);
            }
            if (element.GetType() == typeof(LineElementClass))
            {
                LineElementClass lec = (LineElementClass)element;
                bm = LabelElementCreationHepler.GetLine(lec);
                p = new Point(lec.X, lec.Y);
                return (bm, p);
            }
            if (element.GetType() == typeof(ImageElementClass))
            {
                ImageElementClass iec = (ImageElementClass)element;
                bm = LabelElementCreationHepler.GetImage(iec);
                p = new Point(iec.X, iec.Y);
                return (bm, p);
            }
            return (bm, p);
        }
    }
}
