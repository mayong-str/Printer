using LabelCommon;

namespace LabelMaker
{
    public class PrintJobClass
    {
        /// <summary>类实例别名
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>标签
        /// 
        /// </summary>
        public LabelClass Label;
        /// <summary>打印机
        /// 
        /// </summary>
        public ZebraPrinterClass Printer;
        /// <summary>打印机通讯
        /// 
        /// </summary>
        public SocketSendReceive Socket;
        /// <summary>打印任务状态
        /// 
        /// </summary>
        public PrintTaskStatus Task;
        /// <summary>获取相应设备状态是否正常
        /// /true:正常,false:异常/
        /// </summary>
        public bool DevicesNormal;

        public PrintJobClass() { }

        public PrintJobClass(string alias):this()
        {
            this.Alias = alias;
        }
    }
}
