using LabelCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Myprinter();
            PrinterTest();
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Myprinter()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument_PrintA4Page);

            pd.DefaultPageSettings.PrinterSettings.PrinterName = "EPSON CW-C6030P";//打印机名称
            //pd.DefaultPageSettings.Landscape = true;  //设置横向打印，不设置默认是纵向的
            pd.PrintController = new System.Drawing.Printing.StandardPrintController();
            pd.Print();
        }

        private void printDocument_PrintA4Page(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("黑体", 11, System.Drawing.FontStyle.Bold);//标题字体           
            Font fntTxt = new Font("宋体", 10, System.Drawing.FontStyle.Regular);//正文文字         
            Font fntTxt1 = new Font("宋体", 8, System.Drawing.FontStyle.Regular);//正文文字           
            System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Black);//画刷           
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);           //线条颜色         
            try
            {
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                e.Graphics.DrawString("标题name", titleFont, brush, new System.Drawing.Point(20, 10));
                Point[] points111 = { new Point(20, 28), new Point(230, 28) };
                e.Graphics.DrawLines(pen, points111);
                e.Graphics.DrawString("资产编号：", fntTxt, brush, new System.Drawing.Point(20, 31));
                e.Graphics.DrawString("123456789123465", fntTxt, brush, new System.Drawing.Point(80, 31));
                e.Graphics.DrawString("资产序号：", fntTxt, brush, new System.Drawing.Point(20, 46));
                e.Graphics.DrawString("123456789131321", fntTxt, brush, new System.Drawing.Point(80, 46));
                e.Graphics.DrawString("底部name", fntTxt1, brush, new System.Drawing.Point(100, 62));
                //Bitmap bitmap = CreateQRCode("此处为二维码数据");
                //e.Graphics.DrawImage(bitmap, new System.Drawing.Point(240, 10));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void PrinterTest()
        {
            byte[] bytes = File.ReadAllBytes($@"E:\PC_Program\C#\LabelFactory\LabelFactory\bin\Debug\EPSON.png");//100x150-300bpi.bmp
            Image img = Bitmap.FromFile($@"E:\PC_Program\C#\LabelFactory\LabelFactory\bin\Debug\100x150-300bpi.bmp");
            



            bool re;
            SocketSendReceive ssr = new SocketSendReceive();
            ssr.SetIEP(new IPEndPoint(IPAddress.Any, 0), new IPEndPoint(IPAddress.Parse("192.168.122.94"), 9100));
            ssr.Bind();
            re = ssr.Open();


            List<byte> returnedList = new();
            returnedList.AddRange(Encoding.ASCII.GetBytes("^XA"));//定义开始
            returnedList.AddRange(Encoding.ASCII.GetBytes("^IDR*.*^FS"));

            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,R,300"));
            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,P,300"));
            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLR,Z,300"));

            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLS,P,1654"));
            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CLS,L,500"));

            returnedList.AddRange(Encoding.ASCII.GetBytes("^S(CPC,Q,N"));

            returnedList.AddRange(Encoding.ASCII.GetBytes("^XZ"));//定义END

            returnedList.AddRange(Encoding.ASCII.GetBytes($"~DYR:001.PNG,B,P,{bytes.Length},0,"));

            //byte[] bytes0 = GetHexAsc(bytes);
            returnedList.AddRange(bytes);

            returnedList.AddRange(Encoding.ASCII.GetBytes("^XA"));//定义开始
            returnedList.AddRange(Encoding.ASCII.GetBytes("^FO0,0^ILR:001.PNG^FS"));//
            returnedList.AddRange(Encoding.ASCII.GetBytes("^XZ"));//定义END

            ssr.SendData(returnedList.ToArray());
            ssr.Close();
        }

        private byte[] GetHexAsc(byte[] bytes)
        {
            StringBuilder sb = new();

            foreach (var item in bytes)
            {
                sb.Append(string.Format("{0:X1}", item));
            }
            return Encoding.ASCII.GetBytes(sb.ToString());
        }
    }
}
