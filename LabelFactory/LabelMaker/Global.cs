using LabelCommon;
using System.Configuration;

namespace LabelMaker
{
    public static class Global
    {
        /// <summary>内标打印任务
        /// 
        /// </summary>
        public static PrintJobClass InsideLabelJob;
        /// <summary>外标打印任务
        /// 
        /// </summary>
        public static PrintJobClass OutsideLabelJob;

        /// <summary>是否连接数据库
        /// 
        /// </summary>
        internal static bool DBconn = bool.Parse(ConfigurationManager.AppSettings["DBconn"]);
        /// <summary>是否连接内标打印机
        /// 
        /// </summary>
        internal static bool InsidePrinterConn = bool.Parse(ConfigurationManager.AppSettings["InsidePrinterConn"]);
        /// <summary>是否连接外标打印机
        /// 
        /// </summary>
        internal static bool OutsidePrinterConn = bool.Parse(ConfigurationManager.AppSettings["OutsidePrinterConn"]);

    }
}
