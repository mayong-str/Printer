using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelFactory
{
    /// <summary>Cab条码打印机
    /// 
    /// </summary>
    public class CabPrinterClass
    {
        //*****************************************
        //将Bitmap转换成Cab打印机的打印指令的类，
        //Ver 1.0 。
        //对ASC II图像格式实现了每行的压缩算法，
        //没有实现 00 00 FF xx 、00 nn xx 
        //这两种压缩算法。
        //*****************************************

        #region 类属性
        /// <summary>获取或设置标签宽度，毫米
        /// 默认值95.0毫米。
        /// </summary>
        public float LabelWidth { get; set; }
        /// <summary>获取或设置标签高度，毫米
        /// 默认值50.0毫米。
        /// </summary>
        public float LabelHeight { get; set; }
        /// <summary>获取或设置标签间隙，毫米
        /// 默认值2.0毫米。
        /// </summary>
        public float LabelGap { get; set; }
        /// <summary>获取或设置标签打印速度，
        /// 默认值100毫米/秒。
        /// </summary>
        public int LabelSpeed { get; set; }
        /// <summary>获取或设置标签打印浓度
        /// (-10到+10)，默认值0。
        /// </summary>
        public int PrintDensity { get; set; }
        /// <summary>获取或设置打印头分辨率，
        /// 默认值300dpi。
        /// </summary>
        public int PrinterDpi { get; set; }
        /// <summary>获取标签宽度，像素点数
        /// 
        /// </summary>
        public int LabelPixelX { get; private set; }
        /// <summary>获取标签高度，像素点数
        /// 
        /// </summary>
        public int LabelPixelY { get; private set; }
        /// <summary>获取用Byte数组表示的Bitmap，
        /// 为Cab的ASC II图像格式,
        /// </summary>
        public byte[] BitmapBytes { get; private set; }
        /// <summary>获取Cab打印机打印指令
        /// 
        /// </summary>
        public byte[] LabelPrintCommand { get; private set; }
        #endregion

        #region 类构造器
        public CabPrinterClass()
            : this(95.0f, 50.0f, 2.0f)
        {

        }
        /// <summary>Cab打印机
        /// 
        /// </summary>
        /// <param name="width">标签宽度mm</param>
        /// <param name="height">标签高度mm</param>
        /// <param name="gap">标签间隙mm</param>
        /// <param name="dpi">打印头分辨率</param>
        public CabPrinterClass(float width, float height, float gap)
        {
            this.LabelWidth = width;
            this.LabelHeight = height;
            this.LabelGap = gap;
            initLabel();
        }
        #endregion

        #region 类方法
        /// <summary>初始化标签
        /// 
        /// </summary>
        private void initLabel()
        {
            this.LabelSpeed = 100;
            this.PrintDensity = 0;
            this.PrinterDpi = 300;
            float inch = 25.4f;
            float dpi = (float)this.PrinterDpi;
            this.LabelPixelX = (int)(this.LabelWidth * dpi / inch);
            this.LabelPixelY = (int)(this.LabelHeight * dpi / inch);

        }

        /// <summary>将Bitmap转换成Cab打印指令
        /// 
        /// </summary>
        /// <param name="bm">Bitmap</param>
        public void BuildLabel(Bitmap bm)
        {
            List<byte> lb = new List<byte>();

            byte[] b0 = Encoding.ASCII.GetBytes("d ASC;IMG0\r");            //下载文件到打印机，ASC II格式图片，文件名IMG0
            byte[] b1 = Encoding.ASCII.GetBytes("mm\r");                    //设定打印单位为毫米
            byte[] b2 = Encoding.ASCII.GetBytes("J\r");                     //JOB开始
            byte[] b3 = Encoding.ASCII.GetBytes("O D\r");                   //打印动作选项
            //byte[] b4 = Encoding.ASCII.GetBytes("H50,0\r");               //打印速度50毫米/秒，打印浓度0
            byte[] b4 = Encoding.ASCII.GetBytes(string.Format("H{0},{1}\r", this.LabelSpeed, this.PrintDensity));
            //byte[] b5 = Encoding.ASCII.GetBytes("Sl1;0,0,50,52,95\r");    //标签间隙传感器、x、y、标签高度、标签加间隙高度、标签宽度
            byte[] b5 = Encoding.ASCII.GetBytes(string.Format("Sl1;0,0,{0:F1},{1:F1},{2:F1}\r", this.LabelHeight, this.LabelHeight + this.LabelGap, this.LabelWidth));
            byte[] b6 = Encoding.ASCII.GetBytes("I 0,0,0;IMG0\r");          //打印图片指令，文件名IMG0
            byte[] b7 = Encoding.ASCII.GetBytes("A 1\r");                   //打印1张

            // byte[] ba = Encoding.ASCII.GetBytes("B 10,10,0,CODE128,20,0.3;1234567890\r");   //barcode code128

            // byte[] bi0 = Encoding.ASCII.GetBytes("011B 0002 \r");                           //图片大小283 x 2
            // byte[] bi1 = Encoding.ASCII.GetBytes("80017F A2 8001C0 \r80017F A2 8001C0 \r"); //图片内容

            lb.AddRange(b0);
            // lb.AddRange(new byte[] { 0x30, 0x34, 0x36, 0x32 }); //图片宽度，像素单位
            byte[] bw = Encoding.ASCII.GetBytes(string.Format("{0:X4}", this.LabelPixelX));
            // lb.AddRange(new byte[] { 0x30, 0x32, 0x34, 0x45 }); //图片高度，像素单位
            byte[] bh = Encoding.ASCII.GetBytes(string.Format("{0:X4}\r", this.LabelPixelY));
            lb.AddRange(bw);
            lb.AddRange(bh);
            Bitmap2ByteArray(bm);
            lb.AddRange(this.BitmapBytes);

            // lb.AddRange(new byte[] { 0x01, 0x1b, 0x00, 0x02, 0x20, 0x0d });
            // lb.AddRange(new byte[] { 0x80, 0x01, 0x7f, 0xa2, 0x80, 0x01, 0xc0 });
            // lb.AddRange(new byte[] { 0x80, 0x01, 0x7f, 0xa2, 0x80, 0x01, 0xc0 });
            // lb.Add(0x0d);

            // lb.AddRange(bi0);
            // lb.AddRange(bi1);

            lb.AddRange(b1);
            lb.AddRange(b2);
            lb.AddRange(b3);
            // lb.AddRange(ba);
            lb.AddRange(b4);
            lb.AddRange(b5);
            lb.AddRange(b6);
            lb.AddRange(b7);

            this.LabelPrintCommand = lb.ToArray();
        }
        /// <summary>将Bitmap转换成Byte数组表示
        /// 
        /// </summary>
        /// <param name="bm">Bitmap</param>
        private void Bitmap2ByteArray(Bitmap bm)
        {
            bool[][] b2D = Bitmap2PixelsXyArray(bm);
            this.BitmapBytes = PixelsXyArray2ByteArray_LinesCompressed(b2D);
        }

        /// <summary>将Bitmap转换成XY像素数组
        /// /true:着色的点,false:不着色的点/
        /// </summary>
        /// <param name="bm">Bitmap</param>
        /// <returns>(bool[][])像素数组</returns>
        public bool[][] Bitmap2PixelsXyArray(Bitmap bm)
        {
            bool[][] pixels = new bool[bm.Height][];
            for (int i = 0; i < bm.Height; i++)
            {
                pixels[i] = new bool[bm.Width];
            }

            Color c;
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    c = bm.GetPixel(x, y);
                    pixels[y][x] = c.GetBrightness() < 0.5f ? true : false;
                }
            }
            return pixels;
        }
        /// <summary>将XY像素数组转换成Byte数组， 
        /// 每行经过Cab的压缩算法，
        /// 并转换为ASC字符表示。
        /// </summary>
        /// <param name="PixelsXyArray">XY像素数组</param>
        /// <returns>Byte数组</returns>
        private byte[] PixelsXyArray2ByteArray_LinesCompressed(bool[][] PixelsXyArray)
        {
            List<byte[]> lba = new List<byte[]>();

            for (int y = 0; y < PixelsXyArray.Length; y++)
            {
                lba.Add(compressLine(BoolArrayToByteArray(PixelsXyArray[y])));
            }

            List<byte> lb = new List<byte>();
            foreach (var item in lba)
            {
                lb.AddRange(item);
            }
            return lb.ToArray();
        }

        /// <summary>将Bool数组转换为Byte数组，
        /// 如果输入数组长度不是8的倍数，补足数组长度到8的倍数。
        /// /true:为1,false:为0/
        /// </summary>
        /// <param name="boolArray">Bool数组</param>
        /// <returns>Byte数组</returns>
        public byte[] BoolArrayToByteArray(bool[] boolArray)
        {
            List<byte> lb = new List<byte>();

            bool[] boolArrayTemp = new bool[(int)(Math.Ceiling(boolArray.Length / 8.0d) * 8.0d)];    //长度不能被8整除的，补足数组长度到可被8整除
            boolArray.CopyTo(boolArrayTemp, 0);

            bool[] b = new bool[8];
            for (int i = 0; i < boolArrayTemp.Length; i += 8)
            {
                Array.Copy(boolArrayTemp, i, b, 0, 8);
                lb.Add(BoolArrayToByte(b));
            }
            return lb.ToArray();
        }

        /// <summary>将Bool数组转换为一个Byte数值，
        /// 如果输入数组长度大于8位，只取前8位。
        /// /true:为1,false:为0/
        /// </summary>
        /// <param name="boolArray">Bool数组</param>
        /// <returns>Byte数值</returns>
        public byte BoolArrayToByte(bool[] boolArray)
        {
            bool[] ba = new bool[8];
            if (boolArray.Length > 8)
            {   //输入数组长度大于8位，只取前8位
                Array.Copy(boolArray, ba, 8);
            }
            else
            {
                Array.Copy(boolArray, ba, boolArray.Length);
            }

            byte b = 0;
            foreach (var item in ba)
            {
                b <<= 1;
                if (item) b++;
            }
            return b;
        }

        /// <summary>将XY像素数组的一行转换成Byte数组，
        /// 每行先经过Cab的ASC II图像格式的算法压缩，
        /// 并将每字节的16进制数转换成2个ASC字符表示
        /// （如0x1F -> 0x31 0x46）。
        /// </summary>
        /// <param name="boolArray">XY像素数组行</param>
        /// <returns>Byte数组</returns>
        private byte[] compressLine(byte[] boolArray)
        {
            List<List<byte>> llb = new List<List<byte>>();

            foreach (byte item in boolArray)
            {
                switch (item)
                {
                    case 0x00:
                        add00Item(ref llb);
                        break;
                    case 0xff:
                        addFFItem(ref llb);
                        break;
                    default:
                        addItem(ref llb, item);
                        break;
                }
            }

            List<byte> lb = new List<byte>();
            foreach (List<byte> item in llb)
            {
                foreach (byte b in item)
                {
                    lb.AddRange(Encoding.ASCII.GetBytes(string.Format("{0:X2}", b)));   //将每字节的16进制数转换成2个ASC字符
                }
                // lb.Add(0x20);
            }
            lb.Add(0x0d);
            return lb.ToArray();
        }
        /// <summary>添加0x00字节,
        /// 每行压缩算法。
        /// </summary>
        /// <param name="llb"></param>
        private void add00Item(ref List<List<byte>> llb)
        {
            if (llb.Count == 0)
            {
                llb.Add(new List<byte> { 0x01 });
                return;
            }

            List<byte> last = llb.Last();
            if (last[0] < 0x7f)
            {   //00
                last[0]++;
            }
            else
            {   //80-FF
                llb.Add(new List<byte> { 0x01 });
            }
        }
        /// <summary>添加0xFF字节，
        /// 每行压缩算法。
        /// </summary>
        /// <param name="llb"></param>
        private void addFFItem(ref List<List<byte>> llb)
        {
            if (llb.Count == 0)
            {
                llb.Add(new List<byte> { 0x81 });
                return;
            }

            List<byte> last = llb.Last();
            if (last[0] > 0x80 && last[0] < 0xff)
            {   //FF
                last[0]++;
            }
            else
            {   //01-80
                llb.Add(new List<byte> { 0x81 });
            }
        }
        /// <summary>添加0x00和0xFF以外字节，
        /// 每行压缩算法。
        /// </summary>
        /// <param name="llb"></param>
        /// <param name="val"></param>
        private void addItem(ref List<List<byte>> llb, byte val)
        {
            if (llb.Count == 0)
            {   //空列表
                llb.Add(new List<byte> { 0x80, 0x01, val });
                return;
            }

            List<byte> last = llb.Last();   //取列表最后项
            if (last[0] == 0x80)
            {   //01-FE
                if (last[1] < 0x7f)
                {   //还有空间
                    last[1]++;
                    last.Add(val);
                }
                else
                {   //新空间
                    llb.Add(new List<byte> { 0x80, 0x01, val });
                }
            }
            else
            {   //00 OR FF
                llb.Add(new List<byte> { 0x80, 0x01, val });
            }
        }

        private void say(string msg)
        {
            Console.WriteLine("CabPrinterClass>>>>" + msg);
        }
        #endregion
    }
}
