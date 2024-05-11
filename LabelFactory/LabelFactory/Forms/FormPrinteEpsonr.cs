using LabelCommon;
using LabelCommon.Printer.EPSON;
using System;
using System.Net;
using System.Windows.Forms;

namespace LabelDesigner

{
    public partial class FormPrinteEpsonr : Form
    {
        public FormPrinteEpsonr()
        {
            InitializeComponent();
        }
        
        public static void PrinterTest()
        {
            bool re;
            SocketSendReceive ssr = new SocketSendReceive();
            ssr.SetIEP(new IPEndPoint(IPAddress.Any, 0), new IPEndPoint(IPAddress.Parse("192.168.122.144"), 9100));
            ssr.Bind();
            re = ssr.Open();
            
            //byte[] bytes = File.ReadAllBytes($@"E:\PC_Program\C#\LabelFactory\LabelFactory\bin\Debug\EPSON.png");//打开图片文件并获取字节数组
            EpsonPrinterUtil_ZPLII.LabelBitmap = Global.WorkLabel.LabelBitmap;
            byte[] bytes = EpsonPrinterUtil_ZPLII.BuildLabel_Png_300();
            
            ssr.SendData(bytes);
            ssr.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PrinterTest();
        }
    }
}
