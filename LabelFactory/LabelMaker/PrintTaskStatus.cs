using System.Data;

namespace LabelMaker
{
    /// <summary>打印任务状态
    /// 
    /// </summary>
    public class PrintTaskStatus
    {
        /// <summary>打印机状态
        /// 
        /// </summary>
        public DeviceStatus Printer { get; set; } = DeviceStatus.Unknown;
        /// <summary>打印请求
        /// 
        /// </summary>
        public ReqStatus Req { get; set; } = ReqStatus.No;
        /// <summary>打印响应
        /// 
        /// </summary>
        public ResStatus Res { get; set; } = ResStatus.Idle;

        /// <summary>在打印作业中
        /// 
        /// </summary>
        public bool InPrintJob { get; set; } = false;

        /// <summary>从数据库中取得的标签元素表
        /// 
        /// </summary>
        public DataTable LabelDataTable { get; set; }
    }
    /// <summary>打印请求状态枚举
    /// 
    /// </summary>
    public enum ReqStatus : int
    {
        /// <summary>无请求
        /// 
        /// </summary>
        No = 0,
        /// <summary>有请求
        /// 
        /// </summary>
        Yes = 1,
    }
    /// <summary>打印响应枚举
    /// 
    /// </summary>
    public enum ResStatus : int
    {
        /// <summary>出错
        /// 
        /// </summary>
        Error = -1,
        /// <summary>空闲
        /// 
        /// </summary>
        Idle = 0,
        /// <summary>响应请求
        /// 
        /// </summary>
        Ack = 1,
        /// <summary>打印完成
        /// 
        /// </summary>
        Printed = 2,
    }
}
