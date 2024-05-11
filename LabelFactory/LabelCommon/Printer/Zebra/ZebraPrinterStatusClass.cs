using System;

namespace LabelCommon
{
    public class ZebraPrinterStatusClass
    {
        #region 类属性

        /// <summary>类实例别名
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>标签纸用尽，
        /// 必须更换新的标签纸卷。
        /// </summary>
        public SignalStatus PaperOut { get; private set; }

        /// <summary>打印暂停中
        /// 
        /// </summary>
        public SignalStatus IsPause { get; private set; }

        /// <summary>接收缓冲区已满
        /// 
        /// </summary>
        public SignalStatus BufferFull { get; private set; }

        /// <summary>RAM损坏，
        /// 配置数据丢失。
        /// </summary>
        public SignalStatus CorruptRAM { get; private set; }

        /// <summary>温度过低
        /// 
        /// </summary>
        public SignalStatus UnderTemperature { get; private set; }

        /// <summary>温度过高
        /// 
        /// </summary>
        public SignalStatus OverTemperature { get; private set; }

        /// <summary>打印头抬起，
        /// 打印头处于抬起状态，无法进行打印工作。
        /// </summary>
        public SignalStatus HeadUp { get; private set; }

        /// <summary>色带用尽，
        /// 必须更换新的色带卷。
        /// </summary>
        public SignalStatus RibbonOut { get; private set; }

        /// <summary>热转印模式
        /// 
        /// </summary>
        public SignalStatus ThermalTransferMode { get; private set; }

        /// <summary>打印机当前打印模式
        /// 
        /// </summary>
        public ZebraPrintMode PrintMode { get; private set; }

        /// <summary>标签已打印完成，处于等待位置（等待剥离），
        /// 在剥离模式中使用。
        /// </summary>
        public SignalStatus LabelIsWaiting { get; private set; }

        /// <summary>可以打印的状态
        /// 
        /// </summary>
        public bool CanPrint => this.PaperOut == SignalStatus.No && this.IsPause == SignalStatus.No && this.BufferFull == SignalStatus.No
            && this.CorruptRAM == SignalStatus.No && this.UnderTemperature == SignalStatus.No && this.OverTemperature == SignalStatus.No
            && this.HeadUp == SignalStatus.No && this.RibbonOut == SignalStatus.No;

        #endregion

        public ZebraPrinterStatusClass() { }

        public ZebraPrinterStatusClass(string alias) : this()
        {
            this.Alias = alias;
        }


        /// <summary>解析~HS指令的响应字符串（解析打印机主机状态）
        /// 
        /// </summary>
        /// <param name="bytes">响应字符串</param>
        public void Parser(byte[] bytes)
        {
            //02-30-33-30-2C-30-2C-30-2C-30-31-38-37-2C-30-30-30-2C-30-2C-30-2C-30-2C-30-30-30-2C-30-2C-30-2C-30-03-0D-0A
            //02-30-30-31-2C-30-2C-30-2C-30-2C-31-2C-31-2C-34-2C-30-2C-30-30-30-30-30-30-30-30-2C-31-2C-30-30-31-03-0D-0A
            //02-31-32-33-34-2C-30-03-0D-0A

            bool isNull = bytes == null;
            if (isNull)
            {
                Say($"Parser>>bytes is null!{NowString()}");
                return;
            }
            else if (bytes.Length != 82)
            {
                Say($"Parser>>bytes.Length != 82{NowString()}");
                return;
            }
            else
            {
                Say($"Parser>>{BitConverter.ToString(bytes)}{NowString()}");
            }

            this.PaperOut = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[5]);
            this.IsPause = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[7]);
            this.BufferFull = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[18]);
            this.CorruptRAM = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[28]);
            this.UnderTemperature = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[30]);
            this.OverTemperature = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[32]);
            this.HeadUp = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[43]);
            this.RibbonOut = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[45]);
            this.ThermalTransferMode = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[47]);
            this.PrintMode = isNull ? ZebraPrintMode.Unknown : JudgingPrintMode(bytes[49]);
            this.LabelIsWaiting = isNull ? SignalStatus.Unknown : JudgingSignalValue(bytes[53]);

            if (!isNull)
            {
                Say($"PaperOut = {this.PaperOut}");
                Say($"IsPause = {this.IsPause}");
                Say($"BufferFull = {this.BufferFull}");
                Say($"CorruptRAM = {this.CorruptRAM}");
                Say($"UnderTemperature = {this.UnderTemperature}");
                Say($"OverTemperature = {this.OverTemperature}");
                Say($"HeadUp = {this.HeadUp}");
                Say($"RibbonOut = {this.RibbonOut}");
                Say($"ThermalTransferMode = {this.ThermalTransferMode}");
                Say($"PrintMode = {this.PrintMode}");
                Say($"LabelIsWaiting = {this.LabelIsWaiting}");
            }
        }

        /// <summary>根据字节值判断信号状态
        /// 
        /// </summary>
        /// <param name="b">字节值</param>
        /// <returns>信号状态</returns>
        private SignalStatus JudgingSignalValue(byte b) => b switch
        {
            0x31 => SignalStatus.Yes,
            0x30 => SignalStatus.No,
            _ => SignalStatus.Unknown
        };

        /// <summary>根据字节值判断打印模式
        /// 
        /// </summary>
        /// <param name="b">字节值</param>
        /// <returns>打印模式</returns>
        private ZebraPrintMode JudgingPrintMode(byte b) => b switch
        {
            0x30 => ZebraPrintMode.Rewind, //0
            0x31 => ZebraPrintMode.Peel_Off, //1
            0x32 => ZebraPrintMode.Tear_Off, //2
            0x33 => ZebraPrintMode.Cutter, //3
            0x34 => ZebraPrintMode.Applicator, //4
            0x35 => ZebraPrintMode.DelayedCut, //5
            0x36 => ZebraPrintMode.LinerlessPeel, //6
            0x37 => ZebraPrintMode.LinerlessRewind, //7
            0x38 => ZebraPrintMode.PartialCutter, //8
            0x39 => ZebraPrintMode.RFID, //9
            0x4b => ZebraPrintMode.Kiosk, //K
            0x53 => ZebraPrintMode.KioskCutStream, //S
            0x41 => ZebraPrintMode.KioskCutStream, //A
            _ => ZebraPrintMode.Unknown
        };

        private string NowString() => $"<{DateTime.Now.ToString("HH:mm:ss.fff")}>";
        private void Say(string msg = "") => System.Console.WriteLine($"{this.Alias ?? "ZebraPrinterStatusClass"}>  >{msg}");
    }

    /// <summary>Zebra打印模式
    /// 
    /// </summary>
    public enum ZebraPrintMode
    {
        /// <summary>未知
        /// 
        /// </summary>
        Unknown = -1,
        /// <summary>回卷
        /// 
        /// </summary>
        Rewind,
        /// <summary>剥离
        /// 
        /// </summary>
        Peel_Off,
        /// <summary>撕纸
        /// 
        /// </summary>
        Tear_Off,
        /// <summary>切纸
        /// 
        /// </summary>
        Cutter,
        /// <summary>贴标机
        /// 
        /// </summary>
        Applicator,
        /// <summary>延迟切纸
        /// 
        /// </summary>
        DelayedCut,
        /// <summary>无衬纸剥离
        /// 
        /// </summary>
        LinerlessPeel,
        /// <summary>无衬纸回卷
        /// 
        /// </summary>
        LinerlessRewind,
        /// <summary>
        /// 
        /// </summary>
        PartialCutter,
        /// <summary>RFID
        /// 
        /// </summary>
        RFID,
        /// <summary>
        /// 
        /// </summary>
        Kiosk,
        /// <summary>
        /// 
        /// </summary>
        KioskCutStream,
    }
}
