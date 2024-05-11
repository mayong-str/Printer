using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace LabelCommon
{
    /// <summary>将Bitmap转换成Zebra打印机的打印指令(ZPL II)的工具类
    /// 
    /// </summary>
    public class ZebraPrinterUtil_ZPLII
    {
        //*****************************************
        //将Bitmap转换成Zebra打印机的打印指令(ZPL II)的类，
        //Ver 1.1 。
        //对ASCII十六进制串图像格式实现了LZ77压缩算法。
        //*****************************************

        #region 类属性

        /// <summary>类实例别名
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>设置或获取标签图像
        /// 
        /// </summary>
        public Bitmap LabelBitmap
        {
            get { return this._bitmap; }
            set
            {
                this._bitmap = value;
                this.LabelPixelX = this._bitmap.Width;
                this.LabelPixelY = this._bitmap.Height;
                //this._bitmap.Save($@"R:\001.bmp", ImageFormat.Bmp);
                //BuildLabel_Colored();
                //BuildLabel_WhiteBlack();
            }
        }

        //6 个点 = 1 毫米，      152.4 个点 = 1 英寸
        //8 个点 = 1 毫米，      203.2 个点 = 1 英寸
        //12 个点 = 1 毫米，     304.8 个点 = 1 英寸
        //24 个点 = 1 毫米，     609.6 个点 = 1 英寸

        /// <summary>获取标签宽度，像素点数
        /// 
        /// </summary>
        public int LabelPixelX { get; private set; }

        /// <summary>获取标签高度，像素点数
        /// 
        /// </summary>
        public int LabelPixelY { get; private set; }

        /// <summary>获取Zebra打印机打印指令，byte[]格式。
        /// 
        /// </summary>
        public byte[] LabelPrintCommand { get; private set; }

        /// <summary>获取Zebra打印机打印指令，string格式。
        /// 
        /// </summary>
        public string LabelPrintCommandString { get; private set; }

        /// <summary>取得打印机状态的指令(~HS)
        /// 
        /// </summary>
        public byte[] PrinterStatusReturnCmd => Encoding.ASCII.GetBytes("~HS");//~HS指令,返回打印机状态

        public byte[] PrinterClearBufferCmd => Encoding.ASCII.GetBytes($"~JA");//取消缓冲区中所有格式命令,同时取消正在打印的任何批处理作业。

        #endregion

        #region 类构造器

        public ZebraPrinterUtil_ZPLII()
        {
            this.compressionContext = new SortedList<int, char>(39);
            InitCompressionContext();
        }
        #endregion

        #region 类方法

        /// <summary>初始化LZ77图像字节流压缩上下文
        /// 
        /// </summary>
        private void InitCompressionContext()
        {
            this.compressionContext.Add(1, 'G');
            this.compressionContext.Add(2, 'H');
            this.compressionContext.Add(3, 'I');
            this.compressionContext.Add(4, 'J');
            this.compressionContext.Add(5, 'K');
            this.compressionContext.Add(6, 'L');
            this.compressionContext.Add(7, 'M');
            this.compressionContext.Add(8, 'N');
            this.compressionContext.Add(9, 'O');
            this.compressionContext.Add(10, 'P');
            this.compressionContext.Add(11, 'Q');
            this.compressionContext.Add(12, 'R');
            this.compressionContext.Add(13, 'S');
            this.compressionContext.Add(14, 'T');
            this.compressionContext.Add(15, 'U');
            this.compressionContext.Add(16, 'V');
            this.compressionContext.Add(17, 'W');
            this.compressionContext.Add(18, 'X');
            this.compressionContext.Add(19, 'Y');
            this.compressionContext.Add(20, 'g');
            this.compressionContext.Add(40, 'h');
            this.compressionContext.Add(60, 'i');
            this.compressionContext.Add(80, 'j');
            this.compressionContext.Add(100, 'k');
            this.compressionContext.Add(120, 'l');
            this.compressionContext.Add(140, 'm');
            this.compressionContext.Add(160, 'n');
            this.compressionContext.Add(180, 'o');
            this.compressionContext.Add(200, 'p');
            this.compressionContext.Add(220, 'q');
            this.compressionContext.Add(240, 'r');
            this.compressionContext.Add(260, 's');
            this.compressionContext.Add(280, 't');
            this.compressionContext.Add(300, 'u');
            this.compressionContext.Add(320, 'v');
            this.compressionContext.Add(340, 'w');
            this.compressionContext.Add(360, 'x');
            this.compressionContext.Add(380, 'y');
            this.compressionContext.Add(400, 'z');
        }

        public byte[] PrintDensityCmd(int darkness = 25) => Encoding.ASCII.GetBytes($"~SD{darkness}");//打印浓度（绝对值）

        public byte[] PrintingSpeedCmd(int speed = 2) => Encoding.ASCII.GetBytes($"^PR{speed}");//打印速度，英寸/秒

        public byte[] SetLabelHomePositionCmd(UInt16 x, UInt16 y) => Encoding.ASCII.GetBytes($"^LH{x},{y}");//设置标签的打印起始位置，以点数为单位。

        public byte[] Img2ZplII()
        {
            byte[] bytes = Bitmap2ByteArray(this._bitmap);
            return bytes;
        }
        public byte[] BuildGrfImgCmd(byte[] bytes)
        {
            byte[] bDG = Encoding.ASCII.GetBytes($"~DGR:001.GRF,{bytes.Length},{this.bytesPesLine},");//下载图片到打印机，贮存目标DRAM，文件名001.GRF,
            //List<byte> returnedList = new();
            //returnedList.AddRange(bDG);
            //returnedList.AddRange(bytes);
            //return returnedList.ToArray();
            return bDG;
        }

        public byte[] SendPrintGrfImgCmd => Encoding.ASCII.GetBytes($"^XA^PW{this.LabelPixelX}^LL{this.LabelPixelY}^FO0,0^XGR:001.GRF,1,1^FS^XZ");


        /// <summary>生成标签打印指令，只针对只有黑色和白色的二值化标签。
        /// 
        /// </summary>
        public void BuildLabel_WhiteBlack()
        {
            byte[] bytes = Bitmap2ByteArray(this._bitmap);

            byte[] bStart = Encoding.ASCII.GetBytes("^XA");//定义开始
            byte[] bML = Encoding.ASCII.GetBytes("^ML3600");//贮存当前设置
            byte[] b001 = Encoding.ASCII.GetBytes("^JUS");//贮存当前设置
            // byte[] b02 = Encoding.ASCII.GetBytes("^PR2");//打印速度2英寸/秒
            // byte[] b002 = Encoding.ASCII.GetBytes(string.Format("^PR{0}", this.PrintingSpeed));//打印速度，英寸/秒
            // byte[] b03 = Encoding.ASCII.GetBytes("~SD20");//打印浓度20
            // byte[] b003 = Encoding.ASCII.GetBytes(string.Format("~SD{0}", this.PrintDensity));//打印浓度
            // byte[] b04 = Encoding.ASCII.GetBytes("^PW320^LL240");//标签高度、标签宽度
            byte[] bXY = Encoding.ASCII.GetBytes($"^PW{this.LabelPixelX}^LL{this.LabelPixelY}");//标签宽度、标签高度
            byte[] bEnd = Encoding.ASCII.GetBytes("^XZ");//定义结束
            // byte[] b006 = Encoding.ASCII.GetBytes("~DGR:000.GRF,1024,128");//下载图片到打印机，贮存目标DRAM，文件名000.GRF,图象总的字节数1024,每行字节数128
            byte[] bDG = Encoding.ASCII.GetBytes($"~DGR:001.GRF,{bytes.Length},{this.bytesPesLine},");//下载图片到打印机，贮存目标DRAM，文件名000.GRF,
            byte[] b007 = Encoding.ASCII.GetBytes("^LH0,0");//指定的标签原点
            byte[] bFO = Encoding.ASCII.GetBytes("^FO0,0");//设置字段打印的位置，相对于由^LH命令指定的标签原点。＾FO命令设置字段的左上角的位置。
            byte[] b009 = Encoding.ASCII.GetBytes("^XGR:001.GRF,1,1");//调用图象000.GRF,X方向缩放1，Y方向缩放1。
            byte[] b010 = Encoding.ASCII.GetBytes("^FS");//字段定义结束
            byte[] b011 = Encoding.ASCII.GetBytes("^CI0");//国际字符设置为0
            byte[] b012 = Encoding.ASCII.GetBytes("^PQ1");//打印数量为1
            //byte[] b012 = Encoding.ASCII.GetBytes("^PQ5");//打印数量为5
            byte[] b013 = Encoding.ASCII.GetBytes("^MMR");//回卷
            // byte[] b07 = Encoding.ASCII.GetBytes("^XA^LH0,0^FO0,0^XG000.GRF,1,1^FS^CI0^PQ1^XZ");//打印1张
            byte[] bJL = Encoding.ASCII.GetBytes($"~JL{this.LabelPixelY}");//设定标签高度
            byte[] bID = Encoding.ASCII.GetBytes($"^IDR:001.GRF");//删除图片
            byte[] bPO = Encoding.ASCII.GetBytes($"^POI");//反转标签180度打印

            List<byte> returnedList = new();
            returnedList.AddRange(bStart);
            //returnedList.AddRange(bID);
            returnedList.AddRange(bML);
            returnedList.AddRange(b001);
            //returnedList.AddRange(b002);
            // returnedList.AddRange(b003);
            //returnedList.AddRange(bXY);
            returnedList.AddRange(bEnd);

            returnedList.AddRange(bDG);
            returnedList.AddRange(bytes);
            //returnedList.AddRange(bJL);

            returnedList.AddRange(bStart);
            returnedList.AddRange(bPO);
            returnedList.AddRange(bXY);
            returnedList.AddRange(bFO);
            returnedList.AddRange(b009);
            // returnedList.AddRange(b010);
            // returnedList.AddRange(b011);
            returnedList.AddRange(b012);
            returnedList.AddRange(bEnd);

            this.LabelPrintCommand = returnedList.ToArray();
            this.LabelPrintCommandString = Encoding.ASCII.GetString(this.LabelPrintCommand);
        }

        /// <summary>生成标签打印指令，可支持彩色标签。
        /// 未能实现功能！
        /// </summary>
        private void BuildLabel_Colored()
        {
            byte[] bytes;
            using (MemoryStream ms = new())
            {
                this._bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                bytes = ms.ToArray();
            }

            byte[] bStart = Encoding.ASCII.GetBytes("^XA");//定义开始
            byte[] b001 = Encoding.ASCII.GetBytes("^JUS");//贮存当前设置
            byte[] bXY = Encoding.ASCII.GetBytes($"^PW{this.LabelPixelX}^LL{this.LabelPixelY}");//标签宽度、标签高度
            byte[] bEnd = Encoding.ASCII.GetBytes("^XZ");//定义结束
            byte[] bDY = Encoding.ASCII.GetBytes($"~DYR:000.PNG,P,P,{bytes.Length},,");//下载图片到打印机，贮存目标DRAM，文件名000,
            byte[] bFO = Encoding.ASCII.GetBytes("^FO0,0");//设置字段打印的位置，相对于由^LH命令指定的标签原点。＾FO命令设置字段的左上角的位置。
            byte[] b009 = Encoding.ASCII.GetBytes("^IMR:000.PNG");//调用图象000
            byte[] b012 = Encoding.ASCII.GetBytes("^PQ1");//打印数量为1
            byte[] bClearBuffer = Encoding.ASCII.GetBytes("~JA");//取消缓冲区中所有格式命令,同时取消正在打印的任何批处理作业。

            List<byte> returnedList = new();
            returnedList.AddRange(bStart);
            returnedList.AddRange(b001);
            returnedList.AddRange(bXY);
            returnedList.AddRange(bEnd);
            returnedList.AddRange(bDY);
            returnedList.AddRange(bytes);
            returnedList.AddRange(bStart);
            returnedList.AddRange(bFO);
            returnedList.AddRange(b009);
            returnedList.AddRange(b012);
            returnedList.AddRange(bEnd);

            this.LabelPrintCommand = returnedList.ToArray();
            this.LabelPrintCommandString = Encoding.ASCII.GetString(this.LabelPrintCommand);
        }

        /// <summary>将Bitmap转换成Byte数组表示,
        /// 经LZ77压缩的ASCII十六进制串。
        /// </summary>
        /// <param name="bitmapSource">源Bitmap</param>
        private byte[] Bitmap2ByteArray(Bitmap bitmapSource)
        {
            bool[][] boolArray2D = Bitmap2PixelsXyArray(bitmapSource);

            List<byte[]> lines = PixelsXyArray2LinesByteArray(boolArray2D);
            this.bytesPesLine = lines.First().Count() / 2;
            this.totalOfBytes = lines.Count() * this.bytesPesLine;

            List<byte> returnedList = new();
            foreach (var item in lines)
            {
                returnedList.AddRange(item);
            }
            // say(returnedList.Max().ToString());
            //return returnedList.ToArray();
            return BytesCompression(returnedList.ToArray());

        }

        /// <summary>将Bitmap转换成XY像素数组
        /// /true:着色的点,false:不着色的点/
        /// </summary>
        /// <param name="bitmapSource">Bitmap</param>
        /// <returns>(bool[][])像素数组</returns>
        private bool[][] Bitmap2PixelsXyArray(Bitmap bitmapSource)
        {
            Say($"Bitmap2PixelsXyArray>start init array<{NowString()}>");
            bool[][] pixels = new bool[bitmapSource.Height][];
            for (int i = 0; i < bitmapSource.Height; i++)
            {
                pixels[i] = new bool[bitmapSource.Width];
            }

            Say($"Bitmap2PixelsXyArray>start<{NowString()}>");
            Color c;
            for (int x = 0; x < bitmapSource.Width; x++)
            {
                for (int y = 0; y < bitmapSource.Height; y++)
                {
                    c = bitmapSource.GetPixel(x, y);
                    pixels[y][x] = c.GetBrightness() < 0.5f ? true : false;
                }
            }
            Say($"Bitmap2PixelsXyArray>end<{NowString()}>");
            return pixels;
        }

        /// <summary>将XY像素数组转换成行Byte数组列表， 
        /// 
        /// </summary>
        /// <param name="PixelsXyArray">XY像素数组</param>
        /// <returns>Byte数组</returns>
        private List<byte[]> PixelsXyArray2LinesByteArray(bool[][] PixelsXyArray)
        {
            List<byte[]> resultList = new();
            for (int y = 0; y < PixelsXyArray.Length; y++)
            {
                byte[] line = BoolArrayPer4ToByteArray(PixelsXyArray[y]);
                resultList.Add(line);
            }

            return resultList;
        }

        /// <summary>将Bool数组每每4元素转换为Byte数组，
        /// 如果输入数组长度不是8的倍数，补足数组长度到8的倍数。
        /// /true:为1,false:为0/
        /// </summary>
        /// <param name="boolArraySource">源Bool数组</param>
        /// <returns>Byte数组</returns>
        private byte[] BoolArrayPer4ToByteArray(bool[] boolArraySource)
        {
            List<byte> resultList = new();

            bool[] temporaryArray = new bool[(int)(Math.Ceiling(boolArraySource.Length / 8.0d) * 8.0d)];    //长度不能被8整除的，补足数组长度到可被8整除
            boolArraySource.CopyTo(temporaryArray, 0);

            bool[] boolArray8 = new bool[8];
            for (int i = 0; i < temporaryArray.Length; i += 4)
            {
                Array.Copy(temporaryArray, i, boolArray8, 4, 4);
                resultList.Add(BoolArrayToByte(boolArray8));
            }
            return resultList.ToArray();
        }

        /// <summary>将Bool数组转换为一个Byte数值，
        /// 如果输入数组长度大于8位，只取前8位。
        /// /true:为1,false:为0/
        /// </summary>
        /// <param name="boolArraySource">Bool数组</param>
        /// <returns>Byte数值</returns>
        private byte BoolArrayToByte(bool[] boolArraySource)
        {
            bool[] boolArray8 = new bool[8];
            if (boolArraySource.Length > 8)
            {   //输入数组元素大于8个，只取前8个
                Array.Copy(boolArraySource, boolArray8, 8);
            }
            else
            {
                Array.Copy(boolArraySource, boolArray8, boolArraySource.Length);
            }

            byte returnedValue = 0;
            foreach (var item in boolArray8)
            {
                returnedValue <<= 1;
                if (item) returnedValue++;
            }
            return returnedValue;
        }

        /// <summary>将整个Byte数组进行LZ77压缩
        /// 
        /// </summary>
        /// <param name="byteArraySource">源Byte数组</param>
        /// <returns>压缩后的Byte数组</returns>
        private byte[] BytesCompression(byte[] byteArraySource)
        {
            byte? lastByte = null;//上次Byte
            int lastByteRepeatTimes = 0;//重复次数
            string resultString = "";

            foreach (byte item in byteArraySource)
            {
                if (item == lastByte)
                {//当前Byte与上次Byte相同
                    lastByteRepeatTimes += 1;//次数加1
                }
                else
                {//当前Byte与上次Byte不相同
                    if (lastByte != null)
                    {
                        resultString += CompressLZ77(lastByte, lastByteRepeatTimes);//对上次Byte进行压缩
                    }
                    lastByte = item;
                    lastByteRepeatTimes = 1;
                }
            }
            resultString += CompressLZ77(lastByte, lastByteRepeatTimes);
            return Encoding.ASCII.GetBytes(resultString);
        }

        /// <summary>斑马ZPL II指令集LZ77图像字节流压缩方法。
        /// 如1024个0压缩为zzqJ0
        /// </summary>
        /// <param name="lastbByte">待压缩Byte</param>
        /// <param name="lastByteRepeatTimes">Byte重复次数</param>
        /// <returns>压缩结果</returns>
        private string CompressLZ77(byte? lastbByte, int lastByteRepeatTimes)
        {
            string resultString = "";
            if (lastByteRepeatTimes > 1)
            {
                int i = lastByteRepeatTimes;
                while (i > 0)
                {
                    foreach (var item in compressionContext.Reverse())
                    {
                        if (item.Key <= i)
                        {
                            resultString += item.Value;
                            i -= item.Key;
                            break;
                        }
                    }
                }
            }
            resultString += string.Format("{0:X1}", lastbByte);
            return resultString;
        }

        private string NowString() => $"<{DateTime.Now.ToString("HH:mm:ss.fff")}>";
        private void Say(string msg = "") => Console.WriteLine($"{Alias ?? "ZebraPrinterUtil"}> >{msg}");

        #endregion

        #region 类私有变量
        /// <summary>LZ77图像字节流压缩上下文
        /// 
        /// </summary>
        private readonly SortedList<int, char> compressionContext;

        /// <summary>ASCII十六进制图象总的字节数
        /// 
        /// </summary>
        private int totalOfBytes;

        /// <summary>ASCII十六进制串图象每行字节数
        /// 
        /// </summary>
        private int bytesPesLine;

        private Bitmap _bitmap;//储存标签Bitmap

        #endregion
    }

}
