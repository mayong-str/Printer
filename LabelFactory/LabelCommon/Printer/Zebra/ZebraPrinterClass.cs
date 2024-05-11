namespace LabelCommon
{
    /// <summary>表示打印机的类
    /// 
    /// </summary>
    public class ZebraPrinterClass : ILabel, IPrinter
    {
        /// <summary>类实例别名
        /// 
        /// </summary>
        public string Alias
        {
            get { return _alias; }
            set
            {
                this._alias = value;
                this.Status.Alias = $"{this._alias}Status";
            }
        }

        /// <summary>每毫米的点数
        /// 
        /// </summary>
        public int DotPerMillimeter { get; set; } = 8;

        /// <summary>获取或设置标签打印速度，
        /// (1到5)默认值2英寸/秒。
        /// </summary>
        public int PrintingSpeed_inch { get; private set; } = 2;

        /// <summary>获取或设置标签打印浓度
        /// (0到30)，默认值25。
        /// </summary>
        public int PrintDarkness { get; private set; } = 25;

        /// <summary>获取或设置打印头宽度，
        /// 默认值25.4mm。
        /// </summary>
        public float PrintheadWidth { get; set; } = 25.4f;

        /// <summary>获取或设置打印头点数，
        /// 默认值203dot。
        /// </summary>
        public float PrintheadDot { get; set; } = 203f;

        public ZebraPrinterStatusClass Status;
        private readonly ZebraPrinterUtil_ZPLII Util;

        /// <summary>获取或设置标签宽度，毫米
        /// 默认值95.0毫米。
        /// </summary>
        public float LabelWidth_mm { get; private set; } = 95.0f;

        /// <summary>获取或设置标签高度，毫米
        /// 默认值50.0毫米。
        /// </summary>
        public float LabelHeight_mm { get; private set; } = 50.0f;

        /// <summary>获取或设置标签间隙，毫米
        /// 默认值2.0毫米。
        /// </summary>
        public float LabelGap { get; private set; } = 2.0f;

        /// <summary>获取标签宽度，像素点数
        /// 
        /// </summary>
        public int LabelWidth_Pixel { get; private set; }

        /// <summary>获取标签高度，像素点数
        /// 
        /// </summary>
        public int LabelHeight_Pixel { get; private set; }

        public ZebraPrinterClass()
        {
            this.Status = new ZebraPrinterStatusClass();
            this.Util = new ZebraPrinterUtil_ZPLII();
        }

        /// <summary>Zebra打印机，使用默认值，
        /// 标签宽度95mm,标签高度50mm。
        /// </summary>
        public ZebraPrinterClass(string alias) : this()
        {
            this.Alias = alias;
            this.Status.Alias = $"{this.Alias}Status";
        }

        private void initPrinter()
        {
            this.PrintheadWidth = 1.0f;
            this.PrintheadDot = 8.0f;
        }

        public void SetLabelSize(float width = 95f, float height = 50f, float gap = 2.0f)
        {
            this.LabelWidth_mm = width;
            this.LabelHeight_mm = height;
            this.LabelGap = gap;
        }

        public byte[] GetStatusCmd() => Util.PrinterStatusReturnCmd;
        public byte[] GetPrintLabelCmd(LabelClass lc)
        {
            this.Util.LabelBitmap = lc.LabelBitmap;
            return this.Util.LabelPrintCommand;
        }
        private string _alias;
    }
}
