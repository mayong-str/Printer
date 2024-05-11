using LabelCommon;
using System;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;

namespace LabelMaker
{
    public partial class FormMain : Form
    {
        private LabelPanel In_LabelPanel;
        private LabelPanel Ex_LabelPanel;
        private DevicesStatusPanel dsp;
        private SplitContainer SplMain;

        public FormMain()
        {
            this.SuspendLayout();

            InitializeComponent();
            InitUI();
            InitSQL();

            InitPrinter();
            ReadLabelTemplate();
            InitDeviceStatus();

            this.ResumeLayout();
        }

        private void InitUI()
        {
            this.dsp = new DevicesStatusPanel
            {
                Dock = DockStyle.Top
            };
            this.SplMain = new SplitContainer()
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
            };
            this.SplMain.SizeChanged += SplMain_SizeChanged;
            this.SplMain.Panel1.SizeChanged += this.SplMain_Panel1_SizeChanged;
            this.SplMain.Panel2.SizeChanged += this.SplMain_Panel2_SizeChanged;

            this.Controls.Add(this.SplMain);
            this.Controls.Add(dsp);
        }

        private void InitSQL()
        {
            SqlHepler.ConnString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            // SqlHepler.SqlOpen();
        }
        
        private void InitPrinter()
        {
            string inPrinterConnString = ConfigurationManager.ConnectionStrings["InsideLabelPrinter"].ConnectionString;
            string outPrinterConnString = ConfigurationManager.ConnectionStrings["OutsideLabelPrinter"].ConnectionString;
            string localConnString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

            Global.InsideLabelJob = new PrintJobClass()
            {
                Alias = "内标",
                Printer = new ZebraPrinterClass() { Alias = "内标打印机" },
                Socket = new SocketSendReceive() { Alias = "内标打印机Socket" },
                Task = new PrintTaskStatus()
            };
            Global.InsideLabelJob.Socket.SetIEP(localConnString, inPrinterConnString);

            Global.OutsideLabelJob = new PrintJobClass()
            {
                Alias = "外标",
                Printer = new ZebraPrinterClass() { Alias = "外标打印机" },
                Socket = new SocketSendReceive() { Alias = "外标打印机Socket" },
                Task = new PrintTaskStatus()
            };
            Global.OutsideLabelJob.Socket.SetIEP(localConnString, outPrinterConnString);
        }

        private void ReadLabelTemplate()
        {
            string str = $"{ConfigurationManager.AppSettings["LabelStorehousePath"]}";
            LabelFormatAndXml.Xml2LabelFormat($"{ConfigurationManager.AppSettings["LabelStorehousePath"]}qse.xml", out LabelBasicInfoClass lbi0, out ArrayList al0);
            Global.InsideLabelJob.Label = new LabelClass(lbi0, al0);
            this.In_LabelPanel = new LabelPanel(Global.InsideLabelJob);
            this.In_LabelPanel.ShowLabel();
            this.SplMain.Panel1.Controls.Add(In_LabelPanel);

            //LabelFormatAndXml.Xml2LabelFormat($"{ConfigurationManager.AppSettings["LabelStorehousePath"]}OutLabel.xml", out LabelBasicInfoClass lbi, out ArrayList al);
            //Global.OutsideLabelJob.Label = new LabelClass(lbi, al);
            //this.Ex_LabelPanel = new LabelPanel(Global.OutsideLabelJob);
            //this.Ex_LabelPanel.ShowLabel();
            //this.SplMain.Panel2.Controls.Add(Ex_LabelPanel);
        }

        /// <summary>初始化各设备状态
        /// 
        /// </summary>
        private void InitDeviceStatus()
        {
            DevicesStatus.PC = DeviceStatus.Normal;
            Global.InsideLabelJob.Task.Printer = DeviceStatus.Unknown;
            Global.OutsideLabelJob.Task.Printer = DeviceStatus.Unknown;
            Global.InsideLabelJob.Task.Res = ResStatus.Idle;
            Global.OutsideLabelJob.Task.Res = ResStatus.Idle;
        }

        private void SplMain_SizeChanged(object sender, EventArgs e)
        {
            this.SplMain.SplitterDistance = (this.SplMain.Width - this.SplMain.SplitterWidth) / 2;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TaskAndStatus.Start();
        }

        private void SplMain_Panel2_SizeChanged(object sender, EventArgs e)
        {
            if (this.Ex_LabelPanel == null) return;
            int x = (this.SplMain.Panel2.Width - this.Ex_LabelPanel.Width) / 2;
            // int y = (this.SplMain.Panel2.Height - this.Ex_LabelPanel.Height) / 2;
            int y = (this.SplMain.Panel2.Top + 10);
            this.Ex_LabelPanel.Location = new System.Drawing.Point(x, y);
        }

        private void SplMain_Panel1_SizeChanged(object sender, EventArgs e)
        {
            if (this.In_LabelPanel == null) return;
            int x = (this.SplMain.Panel1.Width - this.In_LabelPanel.Width) / 2;
            //int y = (this.SplMain.Panel1.Height - this.In_LabelPanel.Height) / 2;
            int y = (this.SplMain.Panel1.Top + 10);
            this.In_LabelPanel.Location = new System.Drawing.Point(x, y);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaskAndStatus.Stop();
            Global.InsideLabelJob.Socket.Close();
            Global.OutsideLabelJob.Socket.Close();
        }
    }
}
