using LabelCommon;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class FormPrinterUsb : Form
    {
        public FormPrinterUsb()
        {
            InitializeComponent();
        }
        public FormPrinterUsb(Bitmap bmp, LabelBasicInfoClass lbic)
            : this()
        {
            this._bmp = bmp;
            this._lbic = lbic;
            InitPrinter();
        }

        private void InitPrinter()
        {
            this.zebraPrinter = new ZebraPrinterUtil_ZPLII()
            {
                // LabelPixelX = this._bmp.Width,
                // LabelPixelY = this._bmp.Height,
            };
            // this.zebraPrinter.SetLabelSize(this._lbic.Width, this._lbic.Height);
            this.zebraPrinter.LabelBitmap = this._bmp;
            this.uu = new();
            this.uu.Open();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.uu.Writer(this.zebraPrinter.LabelPrintCommand);
            
           
            //ssr.SendData(zp.LabelPrintCommand);
            //  ssr.SendData(new byte[2] { 0x30, 0x31 });
            // ssr.Close();

        }

        private Bitmap _bmp;
        private LabelBasicInfoClass _lbic;
        private ZebraPrinterUtil_ZPLII zebraPrinter;
        //private ZebraPrinterStatusClass zebraPrinterStatusClass;
        private UsbUtilcs uu;


        private void BtnConnClose_Click(object sender, EventArgs e)
        {
            if (this.uu == null) return;
            this.uu.Close();
        }

        private void BtnConnOpen_Click(object sender, EventArgs e)
        {
            if (this.uu == null) return;
            this.uu.Open();
        }

        private void BtnConnSend_Click(object sender, EventArgs e)
        {
            if (this.uu == null) return;
            //if (this.uu.RemoteIsConnected == false) return;
            //this.ssr.SendData(new byte[2] { 0x30, 0x31 });
            //this.uu.SendAndReceive(new byte[2] { 0x30, 0x31 });
        }


        public void Say(string msg = "")
        {
            Console.WriteLine($"FormPrinter>>>>{msg}<{DateTime.Now.ToString("HH:mm:ss.fff")}>");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
