using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace LabelCommon
{
    /// <summary>生成Code128类型条码图像的类
    /// 
    /// </summary>
    public class BarCode128Class
    {
        #region 类私有变量
        private DataTable m_Code128 = new DataTable();
        private int _height = 40;
        private Font _textFont = null;
        private byte _magnify = 1;

        #endregion

        #region 类属性
        /// <summary>获取或设置条码图形高度，单位为像素点
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }

        /// <summary>获取或设置条码图形上附加文本的字体
        /// 
        /// </summary>
        public Font TextFont
        {
            get
            {
                return this._textFont;

            }
            set
            {
                this._textFont = value;
            }
        }

        /// <summary>获取或设置条码图形的宽度放大系数   
        /// 1/2/3/4
        /// </summary>
        public byte Magnify
        {
            get
            {
                return this._magnify;
            }
            set
            {
                this._magnify = value;
                if (this._magnify > 4) this._magnify = 4;
                if (this._magnify < 1) this._magnify = 1;

            }
        }

        /// <summary>前景颜色，
        /// 默认：纯黑色/Color.Black/。
        /// </summary>
        public Color ForeColor { get; set; } = Color.Black;

        /// <summary>背景颜色，
        /// 默认：纯白色/Color.White/。
        /// </summary>
        public Color BackColor { get; set; } = Color.White;

        #endregion

        #region 类构造器
        /// <summary>构造BarCode128Class对象
        /// 
        /// </summary>
        public BarCode128Class()
        {
            m_Code128.Columns.Add("ID");
            m_Code128.Columns.Add("Code128A");
            m_Code128.Columns.Add("Code128B");
            m_Code128.Columns.Add("Code128C");
            m_Code128.Columns.Add("BandCode");
            m_Code128.CaseSensitive = true;
            #region 数据表
            m_Code128.Rows.Add("0", " ", " ", "00", "212222");
            m_Code128.Rows.Add("1", "!", "!", "01", "222122");
            m_Code128.Rows.Add("2", "\"", "\"", "02", "222221");
            m_Code128.Rows.Add("3", "#", "#", "03", "121223");
            m_Code128.Rows.Add("4", "$", "$", "04", "121322");
            m_Code128.Rows.Add("5", "%", "%", "05", "131222");
            m_Code128.Rows.Add("6", "&", "&", "06", "122213");
            m_Code128.Rows.Add("7", "'", "'", "07", "122312");
            m_Code128.Rows.Add("8", "(", "(", "08", "132212");
            m_Code128.Rows.Add("9", ")", ")", "09", "221213");
            m_Code128.Rows.Add("10", "*", "*", "10", "221312");
            m_Code128.Rows.Add("11", "+", "+", "11", "231212");
            m_Code128.Rows.Add("12", ",", ",", "12", "112232");
            m_Code128.Rows.Add("13", "-", "-", "13", "122132");
            m_Code128.Rows.Add("14", ".", ".", "14", "122231");
            m_Code128.Rows.Add("15", "/", "/", "15", "113222");
            m_Code128.Rows.Add("16", "0", "0", "16", "123122");
            m_Code128.Rows.Add("17", "1", "1", "17", "123221");
            m_Code128.Rows.Add("18", "2", "2", "18", "223211");
            m_Code128.Rows.Add("19", "3", "3", "19", "221132");
            m_Code128.Rows.Add("20", "4", "4", "20", "221231");
            m_Code128.Rows.Add("21", "5", "5", "21", "213212");
            m_Code128.Rows.Add("22", "6", "6", "22", "223112");
            m_Code128.Rows.Add("23", "7", "7", "23", "312131");
            m_Code128.Rows.Add("24", "8", "8", "24", "311222");
            m_Code128.Rows.Add("25", "9", "9", "25", "321122");
            m_Code128.Rows.Add("26", ":", ":", "26", "321221");
            m_Code128.Rows.Add("27", ";", ";", "27", "312212");
            m_Code128.Rows.Add("28", "<", "<", "28", "322112");
            m_Code128.Rows.Add("29", "=", "=", "29", "322211");
            m_Code128.Rows.Add("30", ">", ">", "30", "212123");
            m_Code128.Rows.Add("31", "?", "?", "31", "212321");
            m_Code128.Rows.Add("32", "@", "@", "32", "232121");
            m_Code128.Rows.Add("33", "A", "A", "33", "111323");
            m_Code128.Rows.Add("34", "B", "B", "34", "131123");
            m_Code128.Rows.Add("35", "C", "C", "35", "131321");
            m_Code128.Rows.Add("36", "D", "D", "36", "112313");
            m_Code128.Rows.Add("37", "E", "E", "37", "132113");
            m_Code128.Rows.Add("38", "F", "F", "38", "132311");
            m_Code128.Rows.Add("39", "G", "G", "39", "211313");
            m_Code128.Rows.Add("40", "H", "H", "40", "231113");
            m_Code128.Rows.Add("41", "I", "I", "41", "231311");
            m_Code128.Rows.Add("42", "J", "J", "42", "112133");
            m_Code128.Rows.Add("43", "K", "K", "43", "112331");
            m_Code128.Rows.Add("44", "L", "L", "44", "132131");
            m_Code128.Rows.Add("45", "M", "M", "45", "113123");
            m_Code128.Rows.Add("46", "N", "N", "46", "113321");
            m_Code128.Rows.Add("47", "O", "O", "47", "133121");
            m_Code128.Rows.Add("48", "P", "P", "48", "313121");
            m_Code128.Rows.Add("49", "Q", "Q", "49", "211331");
            m_Code128.Rows.Add("50", "R", "R", "50", "231131");
            m_Code128.Rows.Add("51", "S", "S", "51", "213113");
            m_Code128.Rows.Add("52", "T", "T", "52", "213311");
            m_Code128.Rows.Add("53", "U", "U", "53", "213131");
            m_Code128.Rows.Add("54", "V", "V", "54", "311123");
            m_Code128.Rows.Add("55", "W", "W", "55", "311321");
            m_Code128.Rows.Add("56", "X", "X", "56", "331121");
            m_Code128.Rows.Add("57", "Y", "Y", "57", "312113");
            m_Code128.Rows.Add("58", "Z", "Z", "58", "312311");
            m_Code128.Rows.Add("59", "[", "[", "59", "332111");
            m_Code128.Rows.Add("60", "\\", "\\", "60", "314111");
            m_Code128.Rows.Add("61", "]", "]", "61", "221411");
            m_Code128.Rows.Add("62", "^", "^", "62", "431111");
            m_Code128.Rows.Add("63", "_", "_", "63", "111224");
            m_Code128.Rows.Add("64", "NUL", "`", "64", "111422");
            m_Code128.Rows.Add("65", "SOH", "a", "65", "121124");
            m_Code128.Rows.Add("66", "STX", "b", "66", "121421");
            m_Code128.Rows.Add("67", "ETX", "c", "67", "141122");
            m_Code128.Rows.Add("68", "EOT", "d", "68", "141221");
            m_Code128.Rows.Add("69", "ENQ", "e", "69", "112214");
            m_Code128.Rows.Add("70", "ACK", "f", "70", "112412");
            m_Code128.Rows.Add("71", "BEL", "g", "71", "122114");
            m_Code128.Rows.Add("72", "BS", "h", "72", "122411");
            m_Code128.Rows.Add("73", "HT", "i", "73", "142112");
            m_Code128.Rows.Add("74", "LF", "j", "74", "142211");
            m_Code128.Rows.Add("75", "VT", "k", "75", "241211");
            m_Code128.Rows.Add("76", "FF", "I", "76", "221114");
            m_Code128.Rows.Add("77", "CR", "m", "77", "413111");
            m_Code128.Rows.Add("78", "SO", "n", "78", "241112");
            m_Code128.Rows.Add("79", "SI", "o", "79", "134111");
            m_Code128.Rows.Add("80", "DLE", "p", "80", "111242");
            m_Code128.Rows.Add("81", "DC1", "q", "81", "121142");
            m_Code128.Rows.Add("82", "DC2", "r", "82", "121241");
            m_Code128.Rows.Add("83", "DC3", "s", "83", "114212");
            m_Code128.Rows.Add("84", "DC4", "t", "84", "124112");
            m_Code128.Rows.Add("85", "NAK", "u", "85", "124211");
            m_Code128.Rows.Add("86", "SYN", "v", "86", "411212");
            m_Code128.Rows.Add("87", "ETB", "w", "87", "421112");
            m_Code128.Rows.Add("88", "CAN", "x", "88", "421211");
            m_Code128.Rows.Add("89", "EM", "y", "89", "212141");
            m_Code128.Rows.Add("90", "SUB", "z", "90", "214121");
            m_Code128.Rows.Add("91", "ESC", "{", "91", "412121");
            m_Code128.Rows.Add("92", "FS", "|", "92", "111143");
            m_Code128.Rows.Add("93", "GS", "}", "93", "111341");
            m_Code128.Rows.Add("94", "RS", "~", "94", "131141");
            m_Code128.Rows.Add("95", "US", "DEL", "95", "114113");
            m_Code128.Rows.Add("96", "FNC3", "FNC3", "96", "114311");
            m_Code128.Rows.Add("97", "FNC2", "FNC2", "97", "411113");
            m_Code128.Rows.Add("98", "SHIFT", "SHIFT", "98", "411311");
            m_Code128.Rows.Add("99", "CODEC", "CODEC", "99", "113141");
            m_Code128.Rows.Add("100", "CODEB", "FNC4", "CODEB", "114131");
            m_Code128.Rows.Add("101", "FNC4", "CODEA", "CODEA", "311141");
            m_Code128.Rows.Add("102", "FNC1", "FNC1", "FNC1", "411131");
            m_Code128.Rows.Add("103", "StartA", "StartA", "StartA", "211412");
            m_Code128.Rows.Add("104", "StartB", "StartB", "StartB", "211214");
            m_Code128.Rows.Add("105", "StartC", "StartC", "StartC", "211232");
            m_Code128.Rows.Add("106", "Stop", "Stop", "Stop", "2331112");
            #endregion
        }

        /// <summary>构造BarCode128Class对象，
        /// 带颜色参数。
        /// </summary>
        /// <param name="foreColor">前景色</param>
        /// <param name="backColor">背景色</param>
        public BarCode128Class(Color foreColor, Color backColor)
            : this()
        {
            this.ForeColor = foreColor == null ? Color.Black : foreColor;
            this.BackColor = backColor == null ? Color.White : backColor;
        }
        #endregion

        #region 生成Barcode128条码图形(原始条纹图形)

        /// <summary>获取Barcode128图形
        /// 
        /// </summary>
        /// <param name="inText">文字</param>
        /// <param name="codeType">编码</param>      
        /// <returns>图形</returns>
        public Bitmap GetCodeImage(string inText, Barcode.Type codeType = Barcode.Type.Code128B)
        {
            // string _ViewText = inText;
            string _Text = "";
            IList<int> _TextNumb = new List<int>();
            int _Examine;  //首位
            switch (codeType)
            {
                case Barcode.Type.Code128C:
                    {
                        _Examine = 105;
                        if (!((inText.Length & 1) == 0)) throw new Exception("128C长度必须是偶数");
                        while (inText.Length != 0)
                        {
                            int temp = 0;
                            try
                            {
                                int _CodeNumb128 = Int32.Parse(inText.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            _Text += GetValue(codeType, inText.Substring(0, 2), ref temp);
                            _TextNumb.Add(temp);
                            inText = inText.Remove(0, 2);
                        }
                        break;
                    }
                case Barcode.Type.EAN128:
                    {
                        _Examine = 105;
                        if (!((inText.Length & 1) == 0)) throw new Exception("EAN128长度必须是偶数");
                        _TextNumb.Add(102);
                        _Text += "411131";
                        while (inText.Length != 0)
                        {
                            int _Temp = 0;
                            try
                            {
                                int _CodeNumb128 = Int32.Parse(inText.Substring(0, 2));
                            }
                            catch
                            {
                                throw new Exception("128C必须是数字！");
                            }
                            _Text += GetValue(Barcode.Type.Code128C, inText.Substring(0, 2), ref _Temp);
                            _TextNumb.Add(_Temp);
                            inText = inText.Remove(0, 2);
                        }
                        break;
                    }
                default:
                    _Examine = codeType == Barcode.Type.Code128A ? 103 : 104;
                    while (inText.Length != 0)
                    {
                        int _Temp = 0;
                        string _ValueCode = GetValue(codeType, inText.Substring(0, 1), ref _Temp);
                        if (_ValueCode.Length == 0) throw new Exception("无效的字符集!" + inText.Substring(0, 1).ToString());
                        _Text += _ValueCode;
                        _TextNumb.Add(_Temp);
                        inText = inText.Remove(0, 1);
                    }
                    break;
            }
            if (_TextNumb.Count == 0) throw new Exception("错误的编码,无数据");
            _Text = _Text.Insert(0, GetValue(_Examine)); //获取开始位

            for (int i = 0; i != _TextNumb.Count; i++)
            {
                _Examine += _TextNumb[i] * (i + 1);
            }
            _Examine %= 103;           //获得严效位
            _Text += GetValue(_Examine);  //获取严效位
            _Text += "2331112"; //结束位
            Bitmap _CodeImage = GetImage(_Text);
            //GetViewText(_CodeImage, _ViewText);
            return _CodeImage;
        }

        /// <summary>获取目标对应的数据
        /// 
        /// </summary>
        /// <param name="p_Code">编码</param>
        /// <param name="p_Value">数值 A b  30</param>
        /// <param name="p_SetID">返回编号</param>
        /// <returns>编码</returns>
        private string GetValue(Barcode.Type p_Code, string p_Value, ref int p_SetID)
        {
            if (m_Code128 == null) return "";
            DataRow[] _Row = m_Code128.Select(p_Code.ToString() + "='" + p_Value + "'");
            if (_Row.Length != 1) throw new Exception("错误的编码" + p_Value.ToString());
            p_SetID = Int32.Parse(_Row[0]["ID"].ToString());
            return _Row[0]["BandCode"].ToString();
        }

        /// <summary>根据编号获得条纹
        /// 
        /// </summary>
        /// <param name="p_CodeId"></param>
        /// <returns></returns>
        private string GetValue(int p_CodeId)
        {
            DataRow[] _Row = m_Code128.Select("ID='" + p_CodeId.ToString() + "'");
            if (_Row.Length != 1) throw new Exception("验效位的编码错误" + p_CodeId.ToString());
            return _Row[0]["BandCode"].ToString();
        }

        /// <summary>获得条码图形
        /// 
        /// </summary>
        /// <param name="context">文字</param>
        /// <returns>图形</returns>
        private Bitmap GetImage(string context)
        {
            char[] charArray = context.ToCharArray();
            int width = 0;
            //Magnify = 370 / 134;
            for (int i = 0; i != charArray.Length; i++)
            {
                width += Int32.Parse(charArray[i].ToString()) * (this._magnify);
            }
            Bitmap codeImage = new(width, this._height);
            using Graphics garphics = Graphics.FromImage(codeImage);
            //Pen _Pen;
            int lenEx = 0;
            for (int i = 0; i != charArray.Length; i++)
            {
                int valueNumb = Int32.Parse(charArray[i].ToString()) * (this._magnify);  //获取宽和放大系数
                if (!((i & 1) == 0))
                {
                    //底色条
                    //_Pen = new Pen(Brushes.White, valueNumb);
                    garphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(lenEx, 0, valueNumb, this._height));
                }
                else
                {
                    //着色条
                    //_Pen = new Pen(Brushes.Black, valueNumb);
                    garphics.FillRectangle(new SolidBrush(this.ForeColor), new Rectangle(lenEx, 0, valueNumb, this._height));
                }
                //garphics.(_Pen, new Point(_LenEx, 0), new Point(_LenEx, m_Height));
                lenEx += valueNumb;
            }
            // garphics.Dispose();
            return codeImage;
        }

        /// <summary>添加可见条码文字,
        /// 如果文字超出条码尺寸，将不添加。
        /// </summary>
        /// <param name="bitmap">图形</param>           
        private void GetViewText(Bitmap bitmap, string viewText, Barcode.TextPosition txtPos)
        {
            if (this._textFont == null) return;
            if (txtPos == Barcode.TextPosition.NotShow) return;

            Graphics graphics = Graphics.FromImage(bitmap);
            SizeF drawSize = graphics.MeasureString(viewText, this._textFont);
            if (drawSize.Height > bitmap.Height - 10 || drawSize.Width > bitmap.Width)
            {
                graphics.Dispose();
                return;
            }

            int startX = 0, startY = 0;
            switch (txtPos)
            {
                case Barcode.TextPosition.BottomCenter:
                    startX = (bitmap.Width - (int)drawSize.Width) / 2;
                    startY = bitmap.Height - (int)drawSize.Height;
                    break;
                case Barcode.TextPosition.BottomLeft:
                    startX = 0;
                    startY = bitmap.Height - (int)drawSize.Height;
                    break;
                case Barcode.TextPosition.BottomRight:
                    startX = bitmap.Width - (int)drawSize.Width;
                    startY = bitmap.Height - (int)drawSize.Height;
                    break;
                case Barcode.TextPosition.TopCenter:
                    startX = (bitmap.Width - (int)drawSize.Width) / 2;
                    startY = 0;
                    break;
                case Barcode.TextPosition.TopLeft:
                    startX = 0;
                    startY = 0;
                    break;
                case Barcode.TextPosition.TopRight:
                    startX = bitmap.Width - (int)drawSize.Width;
                    startY = 0;
                    break;
            }
            graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, startY, bitmap.Width, (int)drawSize.Height));
            graphics.DrawString(viewText, this._textFont, new SolidBrush(this.ForeColor), startX, startY);
        }

        #endregion

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码高度</param>
        /// <param name="magnify">条码宽度比例</param>
        /// <param name="codeType">条码类型</param>
        /// <param name="textFont">显示文字字体</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context, int height, byte magnify, Barcode.Type codeType, Font textFont, Barcode.TextPosition textPos)
        {
            this._height = height > 0 ? height : 40;
            this._textFont = textFont;
            this._magnify = magnify > (byte)0 ? magnify : (byte)1;
            Bitmap bitmap = GetCodeImage(context, codeType);//取得条码图形
            GetViewText(bitmap, context, textPos);//在条码图形上添加文本
            return bitmap;
        }

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context) => Build(context, 40, 1, Barcode.Type.Code128B, null, Barcode.TextPosition.NotShow);

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码高度</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context, int height) => Build(context, height, 1, Barcode.Type.Code128B, null, Barcode.TextPosition.NotShow);

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码高度</param>
        /// <param name="magnify">条码宽度比例</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context, int height, byte magnify) => Build(context, height, magnify, Barcode.Type.Code128B, null, Barcode.TextPosition.NotShow);

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码高度</param>
        /// <param name="codeType">条码类型</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context, int height, Barcode.Type codeType) => Build(context, height, 1, codeType, null, Barcode.TextPosition.NotShow);

        /// <summary>生成Code128条码图形
        /// 
        /// </summary>
        /// <param name="context">条码内容</param>
        /// <param name="height">条码高度</param>
        /// <param name="magnify">条码宽度比例</param>
        /// <param name="font">显示文字字体</param>
        /// <returns>(Bitmap)条码图像</returns>
        public Bitmap Build(string context, int height, byte magnify, Font font) => Build(context, height, magnify, Barcode.Type.Code128B, font, Barcode.TextPosition.NotShow);

    }
}


