using System;
using System.Windows.Forms;

namespace LabelMaker
{
    public partial class DevicesStatusPanel : UserControl
    {
        public DevicesStatusPanel()
        {
            InitializeComponent();
            TaskAndStatus.ChangeStatus += ShowStatus;      
        }

        private void DevicesStatusPanel_Resize(object sender, EventArgs e)
        {
            this.GrpDevicesStatus.Top = (this.Height - this.GrpDevicesStatus.Height) / 2;
            this.GrpDevicesStatus.Left = (this.Width - this.GrpDevicesStatus.Width) / 2;
        }

        private void ShowStatus()
        {
            this.ChkFxStatus.BackColor = StatusAndColors.GetShowColor(DevicesStatus.Fx5U_Status);
            this.ChkR04CpuStatus.BackColor = StatusAndColors.GetShowColor(DevicesStatus.RCPU_Status);
            this.ChkInsideLabelingStatus.BackColor = StatusAndColors.GetShowColor(DevicesStatus.InternalLabeling);
            this.ChkOutsideLabelingStatus.BackColor = StatusAndColors.GetShowColor(DevicesStatus.ExternalLabeling);
            this.ChkSqlStatus.BackColor = StatusAndColors.GetShowColor(SqlHepler.SqlConnOpenState);
        }
    }
}
