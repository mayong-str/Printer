using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelCommon
{
    /// <summary>Cab条码打印机
    /// 
    /// </summary>
    public class CabPrinterClass
    {
        //*****************************************
        //将Bitmap转换成Cab打印机的打印指令的类，
        //Ver 1.2 。
        //对ASC II图像格式实现了每行的压缩算法，
        //没有实现00 nn xx 
        //这种压缩算法。
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
        /// <summary>获取或设置打印头宽度，
        /// 默认值106mm。
        /// </summary>
        public int PrintheadWidth { get; set; }
        /// <summary>获取或设置打印头点数，
        /// 默认值1248dot。
        /// </summary>
        public int PrintheadDot { get; set; }
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

        public OutputSignalsClass OutputSignals { get; set; }

        #endregion

        #region 类构造器
        /// <summary>Cab打印机，使用默认值，
        /// 标签宽度95mm、标签高度50mm、标签间隙2mm。
        /// </summary>
        public CabPrinterClass()
            : this(95.0f, 50.0f, 2.0f)
        {
        }
        /// <summary>Cab打印机，
        /// 指定标签宽度mm、标签高度mm、标签间隙mm。
        /// </summary>
        /// <param name="width">标签宽度mm</param>
        /// <param name="height">标签高度mm</param>
        /// <param name="gap">标签间隙mm</param>
        public CabPrinterClass(float width, float height, float gap)
        {
            this.OutputSignals = new OutputSignalsClass();
            this.LabelWidth = width;
            this.LabelHeight = height;
            this.LabelGap = gap;
            InitLabel();
        }
        #endregion

        #region 类方法
        /// <summary>初始化标签
        /// 
        /// </summary>
        private void InitLabel()
        {
            this.LabelSpeed = 100;
            this.PrintDensity = 0;

            this.PrintheadWidth = 106;
            this.PrintheadDot = 1248;

            // float inch = 25.4f;
            // float dpi = (float)this.PrintheadWidth;
            // this.LabelPixelX = (int)(this.LabelWidth * dpi / inch);
            // this.LabelPixelY = (int)(this.LabelHeight * dpi / inch);

            float headWidth = (float)this.PrintheadWidth;
            float dot = (float)this.PrintheadDot;
            this.LabelPixelX = (int)(this.LabelWidth * dot / headWidth);
            this.LabelPixelY = (int)(this.LabelHeight * dot / headWidth);
        }

        /// <summary>生成读取打印机输出信号的指令
        /// 
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] BuildReadOutputSignalsCmd()
        {
            List<byte> result = new List<byte>(6);
            result.Add((byte)0x1b);
            result.AddRange(Encoding.ASCII.GetBytes("xout\r"));
            return result.ToArray();
        }

        #region 打印机 I/O InputSignal
        /// <summary>生成FSTLBL指令的Bytes，
        /// 打印第一张标签。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_FSTLBL_Cmd() => GetInputSignalBytes("FSTLBL");
        /// <summary>生成START指令的Bytes，
        /// 开始打印标签。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_START_Cmd() => GetInputSignalBytes("START");
        /// <summary>生成STOP指令的Bytes，
        /// 停止打印标签。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_STOP_Cmd() => GetInputSignalBytes("STOP");
        /// <summary>生成REPRINT指令的Bytes，
        /// 重新打印最近的标签。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_REPRINT_Cmd() => GetInputSignalBytes("REPRINT");
        /// <summary>生成RSTERR指令的Bytes，
        /// 打印机的错误状态被复位。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_RSTERR_Cmd() => GetInputSignalBytes("RSTERR");
        /// <summary>生成LBLREM指令的Bytes，
        /// 标签已移除。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_LBLREM_Cmd() => GetInputSignalBytes("LBLREM");
        /// <summary>生成JOBDEL指令的Bytes，
        /// 放弃打印作业，并从打印机缓存中移去。
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] Build_JOBDEL_Cmd() => GetInputSignalBytes("JOBDEL");

        /// <summary>根据送入的指令字符串生成Bytes
        /// 
        /// </summary>
        /// <param name="cmd">指令字符串</param>
        /// <returns>byte[]</returns>
        private byte[] GetInputSignalBytes(string cmd)
        {
            List<byte> result = new List<byte>
            {
                (byte)0x1b//ESC
            };
            result.AddRange(Encoding.ASCII.GetBytes("xin"));
            result.Add((byte)0x20);//空格
            result.AddRange(Encoding.ASCII.GetBytes(cmd));
            result.Add((byte)0x3b);//分号
            return result.ToArray();
        }
        #endregion

        /// <summary>将Bitmap转换成Cab打印指令
        /// 
        /// </summary>
        /// <param name="bitmapSource">源Bitmap</param>
        public void BuildLabel(Bitmap bitmapSource)
        {
            List<byte> resultList = new List<byte>();

            //cab打印机可以接受所有类型的行尾标识符（<CR>或<LF>或<CRLF>）
            byte[] b0 = Encoding.ASCII.GetBytes("d ASC;IMG0\r");            //下载文件到打印机，ASC II格式图片，文件名IMG0
            byte[] b1 = Encoding.ASCII.GetBytes("m m\r");                    //设定打印单位为毫米
            byte[] b2 = Encoding.ASCII.GetBytes("J\r");                     //JOB开始
            byte[] b3 = Encoding.ASCII.GetBytes("O D\r");                   //打印动作选项
            //byte[] b4 = Encoding.ASCII.GetBytes("H 50,0\r");               //打印速度50毫米/秒，打印浓度0。打印速度{30,40,50,75,100,125,150,175,200,225,250,275,300}
            byte[] b4 = Encoding.ASCII.GetBytes(string.Format("H {0},{1}\r", this.LabelSpeed, this.PrintDensity));
            //byte[] b5 = Encoding.ASCII.GetBytes("S l1;0,0,50,52,95\r");    //标签间隙传感器、x、y、标签高度、标签加间隙高度、标签宽度
            byte[] b5 = Encoding.ASCII.GetBytes(string.Format("S l1;0,0,{0:F1},{1:F1},{2:F1}\r", this.LabelHeight, this.LabelHeight + this.LabelGap, this.LabelWidth));
            byte[] b6 = Encoding.ASCII.GetBytes("I 0,0,0;IMG0\r");          //打印图片指令，文件名IMG0
            byte[] b7 = Encoding.ASCII.GetBytes("A 1\r");                   //打印1张
            byte[] b8 = Encoding.ASCII.GetBytes("P\r");                     //标签剥离模式

            byte[] ba0 = Encoding.ASCII.GetBytes("B 10,5,0,CODE128,8,0.3;P931204125-1*30\r");   //barcode code128
            byte[] ba1 = Encoding.ASCII.GetBytes("B 10,15,0,CODE128,8,0.2;P931204125-1*30\r");   //barcode code128
            byte[] ba2 = Encoding.ASCII.GetBytes("B 90,5,270,CODE128,8,0.2;P931204125-1*30\r");   //barcode code128
            // byte[] bi0 = Encoding.ASCII.GetBytes("011B 0002 \r");                           //图片大小283 x 2
            // byte[] bi1 = Encoding.ASCII.GetBytes("80017F A2 8001C0 \r80017F A2 8001C0 \r"); //图片内容

            resultList.AddRange(b0);
            // resultList.AddRange(new byte[] { 0x30, 0x34, 0x36, 0x32 }); //图片宽度，像素单位
            byte[] byteArrayWidth = Encoding.ASCII.GetBytes(string.Format("{0:X4}", this.LabelPixelX));
            // resultList.AddRange(new byte[] { 0x30, 0x32, 0x34, 0x45 }); //图片高度，像素单位
            byte[] byteArrayHeight = Encoding.ASCII.GetBytes(string.Format("{0:X4}\r", this.LabelPixelY));
            resultList.AddRange(byteArrayWidth);
            resultList.AddRange(byteArrayHeight);
            Bitmap2ByteArray(bitmapSource);
            resultList.AddRange(this.BitmapBytes);

            // resultList.AddRange(new byte[] { 0x01, 0x1b, 0x00, 0x02, 0x20, 0x0d });
            // resultList.AddRange(new byte[] { 0x80, 0x01, 0x7f, 0xa2, 0x80, 0x01, 0xc0 });
            // resultList.AddRange(new byte[] { 0x80, 0x01, 0x7f, 0xa2, 0x80, 0x01, 0xc0 });
            // resultList.Add(0x0d);

            // resultList.AddRange(bi0);
            // resultList.AddRange(bi1);

            resultList.AddRange(b1);
            resultList.AddRange(b2);
            resultList.AddRange(b3);
            resultList.AddRange(b4);
            resultList.AddRange(b5);
            resultList.AddRange(b8);
            // resultList.AddRange(ba0);
            // resultList.AddRange(ba1);

            resultList.AddRange(b6);

            // resultList.AddRange(ba0);
            // resultList.AddRange(ba1);
            // resultList.AddRange(ba2);
            resultList.AddRange(b7);

            this.LabelPrintCommand = resultList.ToArray();
        }

        #region 将Bitmap转换为Bytes
        /// <summary>将Bitmap转换成Byte数组表示
        /// 
        /// </summary>
        /// <param name="bitmapSource">源Bitmap</param>
        private void Bitmap2ByteArray(Bitmap bitmapSource)
        {
            bool[][] boolArray2D = Bitmap2PixelsXyArray(bitmapSource);
            this.BitmapBytes = PixelsXyArray2ByteArray_LinesCompressed(boolArray2D);
        }

        /// <summary>将Bitmap转换成XY像素数组
        /// /true:着色的点,false:不着色的点/
        /// </summary>
        /// <param name="bitmapSource">Bitmap</param>
        /// <returns>(bool[][])像素数组</returns>
        private bool[][] Bitmap2PixelsXyArray(Bitmap bitmapSource)
        {
            bool[][] pixels = new bool[bitmapSource.Height][];
            for (int i = 0; i < bitmapSource.Height; i++)
            {
                pixels[i] = new bool[bitmapSource.Width];
            }

            Color c;
            for (int x = 0; x < bitmapSource.Width; x++)
            {
                for (int y = 0; y < bitmapSource.Height; y++)
                {
                    c = bitmapSource.GetPixel(x, y);
                    pixels[y][x] = c.GetBrightness() < 0.5f;
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
            List<byte[]> temporaryList = new List<byte[]>();
            for (int y = 0; y < PixelsXyArray.Length; y++)
            {
                byte[] line = compressLine(BoolArrayToByteArray(PixelsXyArray[y]));
                temporaryList.Add(line);
            }
            temporaryList = compressLines(temporaryList);

            List<byte> returnedList = new List<byte>();
            foreach (var item in temporaryList)
            {
                returnedList.AddRange(item);
            }
            return returnedList.ToArray();
        }
        /// <summary>对所有行列表进行00 00 FF xx
        /// 方式压缩。
        /// </summary>
        /// <param name="byteListSource">源所有行的列表</param>
        /// <returns>压缩后行列表</returns>
        private List<byte[]> compressLines(List<byte[]> byteListSource)
        {
            List<object> compressedList = new List<object>();
            foreach (byte[] lineSource in byteListSource)
            {
                if (compressedList.Count() == 0)
                {   //第一行
                    compressedList.Add(new KeyValuePair<byte[], byte>(lineSource, 1));
                    continue;
                }

                int lastItemIndex = compressedList.Count - 1;   //结果列表最后item的index
                KeyValuePair<byte[], byte> lastItem = (KeyValuePair<byte[], byte>)compressedList[lastItemIndex];
                byte[] lastItemKey = lastItem.Key;  //结果列表最后item的key
                byte lastItemValue = lastItem.Value;    //结果列表最后item的value
                if (Enumerable.SequenceEqual(lineSource, lastItemKey) && (lastItemValue < 0xff))
                {   //两行相等，value加1
                    compressedList.RemoveAt(lastItemIndex);
                    lastItemValue += 1;
                    compressedList.Add(new KeyValuePair<byte[], byte>(lastItemKey, lastItemValue));
                }
                else
                {   //两行不相等或容量已满，添加新行
                    compressedList.Add(new KeyValuePair<byte[], byte>(lineSource, 1));
                }
            }

            List<byte[]> returnedList = new List<byte[]>();
            foreach (KeyValuePair<byte[], byte> item in compressedList)
            {
                List<byte> temporaryList = new List<byte>();
                if (item.Value > 1)
                {   //相等的多行
                    temporaryList.AddRange(new byte[] { 0x30, 0x30, 0x30, 0x30, 0x46, 0x46 });  //00 00 FF
                    temporaryList.AddRange(Encoding.ASCII.GetBytes(string.Format("{0:X2}", item.Value)));   //xx
                    temporaryList.AddRange(item.Key);
                    returnedList.Add(temporaryList.ToArray());
                }
                else if (item.Value == 1)
                {   //单独的行
                    returnedList.Add(item.Key);
                }
            }
            return returnedList;
        }

        /// <summary>将Bool数组转换为Byte数组，
        /// 如果输入数组长度不是8的倍数，补足数组长度到8的倍数。
        /// /true:为1,false:为0/
        /// </summary>
        /// <param name="boolArraySource">源Bool数组</param>
        /// <returns>Byte数组</returns>
        private byte[] BoolArrayToByteArray(bool[] boolArraySource)
        {
            List<byte> returnedList = new List<byte>();

            bool[] temporaryArray = new bool[(int)(Math.Ceiling(boolArraySource.Length / 8.0d) * 8.0d)];    //长度不能被8整除的，补足数组长度到可被8整除
            boolArraySource.CopyTo(temporaryArray, 0);

            bool[] boolArray8 = new bool[8];
            for (int i = 0; i < temporaryArray.Length; i += 8)
            {
                Array.Copy(temporaryArray, i, boolArray8, 0, 8);
                returnedList.Add(BoolArrayToByte(boolArray8));
            }
            return returnedList.ToArray();
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
            {   //输入数组长度大于8位，只取前8位
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
        #endregion

        #region 压缩算法
        /// <summary>将XY像素数组的一行转换成Byte数组，
        /// 每行先经过Cab的ASC II图像格式的算法压缩，
        /// 并将每字节的16进制数转换成2个ASC字符表示
        /// （如0x1F -> 0x31 0x46）。
        /// </summary>
        /// <param name="boolArraySource">XY像素数组行</param>
        /// <returns>Byte数组</returns>
        private byte[] compressLine(byte[] boolArraySource)
        {
            List<List<byte>> temporaryArray = new();
            foreach (byte item in boolArraySource)
            {
                switch (item)
                {
                    case 0x00:
                        add00Item(ref temporaryArray);
                        break;
                    case 0xff:
                        addFFItem(ref temporaryArray);
                        break;
                    default:
                        addItem(ref temporaryArray, item);
                        break;
                }
            }

            List<byte> returnedList = new();
            foreach (List<byte> item in temporaryArray)
            {
                foreach (byte byteValue in item)
                {
                    returnedList.AddRange(Encoding.ASCII.GetBytes(string.Format("{0:X2}", byteValue)));   //将每字节的16进制数转换成2个ASC字符
                }
                // lb.Add(0x20);
            }
            returnedList.Add(0x0d);
            return returnedList.ToArray();
        }
        /// <summary>添加0x00字节,
        /// 每行压缩算法。
        /// </summary>
        /// <param name="byteListListSource"></param>
        private void add00Item(ref List<List<byte>> byteListListSource)
        {
            if (byteListListSource.Count == 0)
            {
                byteListListSource.Add(new List<byte> { 0x01 });
                return;
            }

            List<byte> lastItem = byteListListSource.Last();
            if (lastItem[0] < 0x7f)
            {   //00
                lastItem[0]++;
            }
            else
            {   //80-FF
                byteListListSource.Add(new List<byte> { 0x01 });
            }
        }
        /// <summary>添加0xFF字节，
        /// 每行压缩算法。
        /// </summary>
        /// <param name="byteListListSource"></param>
        private void addFFItem(ref List<List<byte>> byteListListSource)
        {
            if (byteListListSource.Count == 0)
            {
                byteListListSource.Add(new List<byte> { 0x81 });
                return;
            }

            List<byte> lastItem = byteListListSource.Last();
            if (lastItem[0] > 0x80 && lastItem[0] < 0xff)
            {   //FF
                lastItem[0]++;
            }
            else
            {   //01-80
                byteListListSource.Add(new List<byte> { 0x81 });
            }
        }
        /// <summary>添加0x00和0xFF以外字节，
        /// 每行压缩算法。
        /// </summary>
        /// <param name="byteListListSource"></param>
        /// <param name="value"></param>
        private void addItem(ref List<List<byte>> byteListListSource, byte value)
        {
            if (byteListListSource.Count == 0)
            {   //空列表
                byteListListSource.Add(new List<byte> { 0x80, 0x01, value });
                return;
            }

            List<byte> lastItem = byteListListSource.Last();   //取列表最后项
            if (lastItem[0] == 0x80)
            {   //01-FE
                if (lastItem[1] < 0x7f)
                {   //还有空间
                    lastItem[1]++;
                    lastItem.Add(value);
                }
                else
                {   //新空间
                    byteListListSource.Add(new List<byte> { 0x80, 0x01, value });
                }
            }
            else
            {   //00 OR FF
                byteListListSource.Add(new List<byte> { 0x80, 0x01, value });
            }
        }
        #endregion

        private void Say(string msg) => Console.WriteLine("CabPrinterClass>>>>" + msg);
        #endregion
    }

    /// <summary>管理输出信号的类
    /// 
    /// </summary>
    public class OutputSignalsClass
    {
        #region 类属性
        /// <summary>打印机就绪信号
        /// 
        /// </summary>
        public SignalStatus READY { get; private set; }
        /// <summary>打印作业就绪
        /// 
        /// </summary>
        public SignalStatus JOBRDY { get; private set; }
        /// <summary>标签介质开始卷动
        /// 
        /// </summary>
        public SignalStatus FEEDON { get; private set; }
        /// <summary>通用错误发生
        /// 
        /// </summary>
        public SignalStatus ERROR { get; private set; }
        /// <summary>碳带末尾警告
        /// 
        /// </summary>
        public SignalStatus RIBWARN { get; private set; }
        /// <summary>标签在剥离位置
        /// 
        /// </summary>
        public SignalStatus PEELPOS { get; private set; }
        /// <summary>贴标机位于打印机标签出口处，贴标手臂原点。
        /// 
        /// </summary>
        public SignalStatus HOMEPOS { get; private set; }
        /// <summary>贴标机位于将标签转移到产品上的位置，贴标手臂伸出到远端。
        /// 
        /// </summary>
        public SignalStatus ENDPOS { get; private set; }
        #endregion

        public OutputSignalsClass()
        {
            SetAllSignalsToUnknown();
        }

        /// <summary>根据响应Bytes来分析每个Output Signal的状态
        /// 
        /// </summary>
        /// <param name="resBytes">响应Bytes</param>
        public void Parser(byte[] resBytes)
        {
            if (resBytes.Length < 8 || (char)resBytes[0] == 'E')//出错或不足8位
            {
                SetAllSignalsToUnknown();
                return;
            }
            this.READY = JudgingSignalValue(resBytes[0]);
            this.JOBRDY = JudgingSignalValue(resBytes[1]);
            this.FEEDON = JudgingSignalValue(resBytes[2]);
            this.ERROR = JudgingSignalValue(resBytes[3]);
            this.RIBWARN = JudgingSignalValue(resBytes[4]);
            this.PEELPOS = JudgingSignalValue(resBytes[5]);
            this.HOMEPOS = JudgingSignalValue(resBytes[6]);
            this.ENDPOS = JudgingSignalValue(resBytes[7]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"READY = {this.READY },");
            sb.Append($"JOBRDY = {this.JOBRDY },");
            sb.Append($"FEEDON = {this.FEEDON },");
            sb.Append($"ERROR = {this.ERROR },");
            sb.Append($"RIBWARN = {this.RIBWARN },");
            sb.Append($"PEELPOS = {this.PEELPOS },");
            sb.Append($"HOMEPOS = {this.HOMEPOS },");
            sb.Append($"ENDPOS = {this.ENDPOS }");
            return sb.ToString();
        }
        /// <summary>根据传入的byte判断输出信号的状态
        /// 
        /// </summary>
        /// <param name="b">传入的byte</param>
        /// <returns>SignalStatusEnum</returns>
        private SignalStatus JudgingSignalValue(byte b) => b switch
        {
            (byte)'Y' => SignalStatus.Yes,
            (byte)'N' => SignalStatus.No,
            _ => SignalStatus.Unknown,
        };

        /// <summary>将所有的输出信号置成Unknown
        /// 
        /// </summary>
        private void SetAllSignalsToUnknown()
        {
            this.READY = SignalStatus.Unknown;
            this.JOBRDY = SignalStatus.Unknown;
            this.FEEDON = SignalStatus.Unknown;
            this.ERROR = SignalStatus.Unknown;
            this.RIBWARN = SignalStatus.Unknown;
            this.PEELPOS = SignalStatus.Unknown;
            this.HOMEPOS = SignalStatus.Unknown;
            this.ENDPOS = SignalStatus.Unknown;
        }

        /// <summary>代表信号的状态的Enum
        /// 
        /// </summary>
 
    }
}
