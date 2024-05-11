using LabelCommon;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace LabelMaker
{
    static class TaskAndStatus
    {
        /// <summary>通知Job状态已更新
        /// 
        /// </summary>
        public static Action ChangeStatus;

        /// <summary>通知Job的标签图像已更新
        /// 
        /// </summary>
        public static Action ChangeLabelImage;

        /// <summary别名
        /// 
        /// </summary>
        public static string Alias { get; set; }

        private static readonly BackgroundWorker worker = new BackgroundWorker() { WorkerReportsProgress = true };

        /// <summary>周期定时器
        /// 
        /// </summary>
        private static readonly System.Windows.Forms.Timer TaskTimer = new System.Windows.Forms.Timer()
        {
            Interval = 500,
            Enabled = false
        };

        public static void Start()
        {
            // if (!SqlHepler.SqlOpen()) return;//打开数据库
            TaskTimer.Tick += TaskTimer_Tick;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            TaskTimer.Start();
        }

        public static void Stop()
        {
            TaskTimer.Stop();
            TaskTimer.Tick -= TaskTimer_Tick;
            SqlHepler.SqlClose();
        }

        private static void TaskTimer_Tick(object sender, EventArgs e)
        {
            Say($"TaskTimer_Tick> >***************************************{NowString()}");
            //TaskTimer.Stop();
            if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Say($"Worker_DoWork> >Start worker{NowString()}");
            if (Global.InsidePrinterConn) GetPrintersStatus(Global.InsideLabelJob);
            if (Global.OutsidePrinterConn) GetPrintersStatus(Global.OutsideLabelJob);

            if (GetSqlConnStatus() == false)
            {
                DevicesStatus.InitDevicesStatus();
                e.Result = false;
                return;
            }
            StatusProcessing();

            if (Global.InsidePrinterConn) PrinterReqRes(Global.InsideLabelJob);
            if (Global.OutsidePrinterConn) PrinterReqRes(Global.OutsideLabelJob);

        }

        private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 60) ChangeLabelImage?.Invoke();
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeStatus?.Invoke();
            //TaskTimer.Start();
        }

        private static bool GetSqlConnStatus()
        {
            if (SqlHepler.IsOpening)
            {
                Say($"GetSqlConnStatus> >打开数据库中{NowString()}");
                return false;
            }
            if (SqlHepler.SqlConnOpenState == false)
            {
                Say($"GetSqlConnStatus> >开始连接数据库{NowString()}");
                SqlHepler.OpenAsync();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>处理打印的请求与响应相关标志
        /// 
        /// </summary>
        private static void PrinterReqRes(PrintJobClass job)
        {
            if (!job.DevicesNormal)
            {
                Say($"PrinterReqRes> >{job.Alias}<外围设备状态异常,无法执行>{NowString()}");
                return;
            }
            if (job.Task.Printer != DeviceStatus.Normal)
            {
                Say($"PrinterReqRes> >{job.Alias}<打印机Socket通讯异常>{NowString()}");
                return;
            }
            if (!job.Printer.Status.CanPrint)
            {
                Say($"PrinterReqRes> >{job.Alias}<打印机处于无法正常工作的状态>{NowString()}");
                return;
            }
            switch (job.Task.Req, job.Task.Res, job.Task.InPrintJob)
            {
                case (ReqStatus.Yes, ResStatus.Idle, false):
                    job.Task.InPrintJob = true;
                    PrintLabel(job);//标打印                  
                    break;
                case (ReqStatus.Yes, ResStatus.Ack, true) when job.Printer.Status.LabelIsWaiting == SignalStatus.Yes:
                    //已对打印机发出打印数据，打印机反馈标签已打印并处于剥离后等待贴标的位置。
                    SubmitPrintedResult(job);
                    job.Task.Res = ResStatus.Printed;
                    break;
                case (ReqStatus.No, _, _):
                    job.Task.InPrintJob = false;
                    job.Task.Res = ResStatus.Idle;
                    break;
            }
        }

        /// <summary>打印内标
        /// 
        /// </summary>
        private static void PrintLabel(PrintJobClass job)
        {
            if (job.Task.LabelDataTable.Rows.Count == 0)
            {
                Say($"PrintLabel> >{job.Alias}<数据表为空>{NowString()}");
                return;
            }
            //取得新标签
            FieldMappingClass.Mapping(job.Label, job.Task.LabelDataTable);
            //job.Label.GetLabelBitmap();
            Say($"PrintLabel> >{job.Alias}{NowString()}");
            worker.ReportProgress(60);
            //发送打印指令           
            job.Socket.SendData(job.Printer.GetPrintLabelCmd(job.Label));
            job.Task.Res = ResStatus.Ack;
        }

        /// <summary>取得打印机的状态
        /// 
        /// </summary>
        private static void GetPrintersStatus(PrintJobClass job)
        {
            Say($"GetPrintersStatus> >{job.Alias}<开始>");
            if (job.Socket.IsOpening == true) return;
            if (job.Socket.IsSending == true) return;
            if (job.Socket.IsReceiving == true) return;

            if (job.Socket.RemoteIsConnected == false)
            {
                job.Socket.Close();
                job.Task.Printer = DeviceStatus.Error;
                job.Socket.Bind();
                job.Socket.OpenAsync();
                //job.Socket.ConnWait();
                Say($"GetPrintersStatus> >{job.Alias}<重新连接！>{NowString()}");
                return;
            }
            job.Socket.SendData(job.Printer.GetStatusCmd());
            job.Socket.Receive();

            if (job.Socket.Response == null)
            {
                Say($"GetPrintersStatus> >{job.Alias}<Response = null>{NowString()}");
                job.Printer.Status.Parser(job.Socket.Response);
                return;
            }
            if (job.Socket.Response.Length > 0)
            {
                Say($"GetPrintersStatus> >{job.Alias}<Response = {job.Socket.Response.Length} Byte>{NowString()}");
                job.Printer.Status.Parser(job.Socket.Response);
                job.Task.Printer = DeviceStatus.Normal;
            }
            else
            {
                Say($"GetPrintersStatus> >{job.Alias}<Response = 0 byte>{NowString()}");
                job.Printer.Status.Parser(job.Socket.Response);
                job.Task.Printer = DeviceStatus.Error;
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void StatusProcessing()
        {
            Say($"StatusProcessing> >从数据库中取得状态和信息{NowString()}");
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@PC_Status", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = (int)DevicesStatus.PC };
            parameters[1] = new SqlParameter("@In_Printer_Status", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = (int)Global.InsideLabelJob.Task.Printer };
            parameters[2] = new SqlParameter("@Ex_Printer_Status", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = (int)Global.OutsideLabelJob.Task.Printer };
            parameters[3] = new SqlParameter("@In_Printer_Res", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = (int)Global.InsideLabelJob.Task.Res };
            parameters[4] = new SqlParameter("@Ex_Printer_Res", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = (int)Global.OutsideLabelJob.Task.Res };

            parameters[5] = new SqlParameter("@Fx5U_Status", SqlDbType.Int) { Direction = ParameterDirection.Output };
            parameters[6] = new SqlParameter("@RCPU_Status", SqlDbType.Int) { Direction = ParameterDirection.Output };
            parameters[7] = new SqlParameter("@In_Labeling_Status", SqlDbType.Int) { Direction = ParameterDirection.Output };
            parameters[8] = new SqlParameter("@Ex_Labeling_Status", SqlDbType.Int) { Direction = ParameterDirection.Output };
            parameters[9] = new SqlParameter("@In_Printer_Req", SqlDbType.Int) { Direction = ParameterDirection.Output };
            parameters[10] = new SqlParameter("@Ex_Printer_Req", SqlDbType.Int) { Direction = ParameterDirection.Output };

            DataSet ds = SqlHepler.StoredProcedureHasReturnDataSet("DY_PC_Use_Status", ref parameters);
            DevicesStatus.Fx5U_Status = DevicesStatus.GetDeviceStatus((int)parameters[5].Value);
            DevicesStatus.RCPU_Status = DevicesStatus.GetDeviceStatus((int)parameters[6].Value);
            DevicesStatus.InternalLabeling = DevicesStatus.GetDeviceStatus((int)parameters[7].Value);
            DevicesStatus.ExternalLabeling = DevicesStatus.GetDeviceStatus((int)parameters[8].Value);
            Global.InsideLabelJob.Task.Req = DevicesStatus.GetReqStatus((int)parameters[9].Value);
            Global.OutsideLabelJob.Task.Req = DevicesStatus.GetReqStatus((int)parameters[10].Value);
            Global.InsideLabelJob.Task.LabelDataTable = ds.Tables[0];
            Global.OutsideLabelJob.Task.LabelDataTable = ds.Tables[1];

            Global.InsideLabelJob.DevicesNormal = DevicesStatus.Fx5U_Status == DeviceStatus.Normal && DevicesStatus.RCPU_Status == DeviceStatus.Normal
                && DevicesStatus.InternalLabeling == DeviceStatus.Normal;
            Global.OutsideLabelJob.DevicesNormal = DevicesStatus.Fx5U_Status == DeviceStatus.Normal && DevicesStatus.RCPU_Status == DeviceStatus.Normal
               && DevicesStatus.ExternalLabeling == DeviceStatus.Normal;

            return;
            Say();
            Say($"StatusProcessing> >Show Device Status <Start>");
            Say($"StatusProcessing> >Fx5U_Status = { DevicesStatus.Fx5U_Status}");
            Say($"StatusProcessing> >RCPU_Status = { DevicesStatus.RCPU_Status}");
            Say($"StatusProcessing> >InternalLabeling = { DevicesStatus.InternalLabeling}");
            Say($"StatusProcessing> >ExternalLabeling = { DevicesStatus.ExternalLabeling}");
            Say($"StatusProcessing> >In_Printer_Req = {  Global.InsideLabelJob.Task.Req }");
            Say($"StatusProcessing> >Ex_Printer_Req = {  Global.OutsideLabelJob.Task.Req}");
            Say($"StatusProcessing> >PC_Status = { DevicesStatus.PC}");
            Say($"StatusProcessing> >In_Printer_Status = { Global.InsideLabelJob.Task.Printer }");
            Say($"StatusProcessing> >Ex_Printer_Status = { Global.OutsideLabelJob.Task.Printer }");
            Say($"StatusProcessing> >In_Printer_Res = { Global.InsideLabelJob.Task.Res}");
            Say($"StatusProcessing> >Ex_Printer_Res = {  Global.OutsideLabelJob.Task.Res}");
            Say($"StatusProcessing> >Show Device Status <End>");
        }

        /// <summary>执行DB的InternalLabelPrinted存储过程，
        /// 提交内标打印完成状态，并由存储过程进行后续处理。
        /// 
        /// </summary>
        private static void SubmitPrintedResult(PrintJobClass job)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("returnVal", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
            if (job == Global.InsideLabelJob)
            {
                SqlHepler.StoredProcedure("InternalLabelPrinted", ref parameters);
            }
            if (job == Global.OutsideLabelJob)
            {
                SqlHepler.StoredProcedure("ExternalLabelPrinted", ref parameters);
            }
            Say($"SubmitPrintedResult> >{job.Alias}<return = {parameters[0].Value}>");
        }

        private static string NowString() => $"<{DateTime.Now.ToString("HH:mm:ss.fff")}>";
        private static void Say(string msg = "") => Console.WriteLine($"{Alias ?? "TaskAndStatus"}> >{msg}");
    }
}
