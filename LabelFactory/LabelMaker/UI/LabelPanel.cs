using LabelCommon;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabelMaker
{
    public partial class LabelPanel : UserControl
    {
        public LabelPanel()
        {
            InitializeComponent();
            TaskAndStatus.ChangeStatus += ShowStatus;
            TaskAndStatus.ChangeLabelImage += ShowLabelImage;
        }

        public LabelPanel(LabelClass lc, ZebraPrinterClass zebraPrinter, PrintTaskStatus pts) : this()
        {
            this.label = lc;
            this.printer = zebraPrinter;
            this.taskStatus = pts;
            this.PicLabel.Visible = false;
        }

        public LabelPanel(PrintJobClass job) : this(job.Label, job.Printer, job.Task) { }


        public void ShowLabel()
        {
            this.PicLabel.Width = this.label.LabelBitmap.Width;
            this.PicLabel.Height = this.label.LabelBitmap.Height;

            Size size = new Size();
            size.Width = Math.Max(this.PicLabel.Width, this.GrpStatus.Width);
            size.Height = this.PicLabel.Height + this.GrpStatus.Height + 10;
            this.ClientSize = size;

            int x = (this.ClientSize.Width - this.PicLabel.Width) / 2;
            int y = this.GrpStatus.Height + 5;
            this.PicLabel.Location = new Point(x, y);
            ShowLabelImage();
        }

        private void ShowStatus()
        {
            this.ChkPaper.BackColor = StatusAndColors.GetShowColor(this.printer.Status.PaperOut);
            this.ChkPause.BackColor = StatusAndColors.GetShowColor(this.printer.Status.IsPause);
            this.ChkRibbon.BackColor = StatusAndColors.GetShowColor(this.printer.Status.RibbonOut);
            this.ChkHeaderUp.BackColor = StatusAndColors.GetShowColor(this.printer.Status.HeadUp);

            this.ChkReq.BackColor = StatusAndColors.GetShowColor(this.taskStatus.Req);
            this.ChkRes.BackColor = StatusAndColors.GetShowColor(this.taskStatus.Res);
            this.ChkConnStatus.BackColor = StatusAndColors.GetShowColor(this.taskStatus.Printer);
        }

        private void ShowLabelImage()
        {
            this.PicLabel.Visible = false;;
            this.PicLabel.Image = this.label.LabelBitmap;
            this.PicLabel.Visible = true;
        }



        private readonly LabelClass label;
        private readonly ZebraPrinterClass printer;
        private readonly PrintTaskStatus taskStatus;

        private void Chk_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            chk.Checked = false;
        }
    }
}
