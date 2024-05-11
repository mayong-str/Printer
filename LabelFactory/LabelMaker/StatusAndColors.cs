using LabelCommon;
using System.Drawing;

namespace LabelMaker
{
    public class StatusAndColors
    {
        /// <summary>根据输入的状态，
        /// 获取对应的颜色。
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns>颜色</returns>
        public static Color GetShowColor(object status)
        {
            if (status.GetType() == typeof(ReqStatus))
            {
                switch ((ReqStatus)status)
                {
                    case ReqStatus.No:
                        return SystemColors.Control;
                    case ReqStatus.Yes:
                        return SystemColors.Highlight;
                }
            }

            if (status.GetType() == typeof(ResStatus))
            {
                switch ((ResStatus)status)
                {
                    case ResStatus.Idle:
                        return SystemColors.Control;
                    case ResStatus.Ack:
                        return Color.Green;
                    case ResStatus.Printed:
                        return Color.Blue;
                    case ResStatus.Error:
                        return Color.Red;
                }
            }

            if (status.GetType() == typeof(SignalStatus))
            {
                switch ((SignalStatus)status)
                {
                    case SignalStatus.Unknown:
                        return SystemColors.Control;
                    case SignalStatus.No:
                        return SystemColors.Control;
                    case SignalStatus.Yes:
                        return Color.Red;
                }
            }

            if (status.GetType() == typeof(DeviceStatus))
            {
                switch ((DeviceStatus)status)
                {
                    case DeviceStatus.Unknown:
                        return SystemColors.Control;
                    case DeviceStatus.Normal:
                        return SystemColors.Highlight;
                    case DeviceStatus.Error:
                        return Color.Red;
                }
            }

            if (status.GetType() == typeof(bool))
            {
                switch ((bool)status)
                {
                    case false:
                        return SystemColors.Control;
                    case true :
                        return SystemColors.Highlight;
                }
            }
            return SystemColors.Control;
        }
    }
}
