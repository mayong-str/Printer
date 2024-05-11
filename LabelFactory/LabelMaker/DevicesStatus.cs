namespace LabelMaker
{
    /// <summary>各设备状态
    /// 
    /// </summary>
    public static class DevicesStatus
    {
        /// <summary>服务器状态
        /// 
        /// </summary>
        public static DeviceStatus PC { get; set; }

        /// <summary>Fx5UCPU状态
        /// 
        /// </summary>
        public static DeviceStatus Fx5U_Status { get; set; }

        /// <summary>RCPU状态
        /// 
        /// </summary>
        public static DeviceStatus RCPU_Status { get; set; }

        /// <summary>内标贴标机状态
        /// 
        /// </summary>
        public static DeviceStatus InternalLabeling { get; set; }

        /// <summary>外标贴标机状态
        /// 
        /// </summary>
        public static DeviceStatus ExternalLabeling { get; set; }

        /// <summary>根据值取得设备状态
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DeviceStatus GetDeviceStatus(int val)
        {
            if (val < 0) return DeviceStatus.Error;
            if (val == 0) return DeviceStatus.Unknown;
            return DeviceStatus.Normal;
        }
        /// <summary>根据值取得打印请求状态
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ReqStatus GetReqStatus(int val)
        {
            if (val == 1) return ReqStatus.Yes;
            return ReqStatus.No;
        }


        public static void InitDevicesStatus()
        {
            PC = DeviceStatus.Unknown;
            Fx5U_Status = DeviceStatus.Unknown;
            RCPU_Status = DeviceStatus.Unknown;
            InternalLabeling = DeviceStatus.Unknown;
            ExternalLabeling = DeviceStatus.Unknown;
        }
    }

    /// <summary>设备的状态枚举
    /// 
    /// </summary>
    public enum DeviceStatus : int
    {
        /// <summary>出错
        /// 
        /// </summary>
        Error = -1,
        /// <summary>未知
        /// 
        /// </summary>
        Unknown = 0,
        /// <summary>正常
        /// 
        /// </summary>
        Normal = 1,
    }


}
