using LabelCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Graphics;
using Zebra.Sdk.Printer;

namespace LabelDesigner
{
    public partial class FormPrinter : Form
    {
        public FormPrinter()
        {
            InitializeComponent();
        }
        public FormPrinter(LabelClass lc)
            : this()
        {
            this._bmp = lc.LabelBitmap;
            InitPrinter();
        }

        private void InitPrinter()
        {

        }

        private Bitmap _bmp;

        public void Say(string msg = "")
        {
            Console.WriteLine($"FormPrinter>>>>{msg}<{DateTime.Now.ToString("HH:mm:ss.fff")}>");
        }

        private void FormPrinter_Load(object sender, EventArgs e)
        {

        }

        private void BtnClearBuffer_Click(object sender, EventArgs e)
        {
            Zebra.Sdk.Printer.PrinterUtil.SendContents("192.168.3.161", $"~JA");
        }

        private void BtnTcpPrint_Click(object sender, EventArgs e)
        {
            Zebra.Sdk.Graphics.ZebraImageI zebraImageI = Zebra.Sdk.Graphics.ZebraImageFactory.GetImage(this._bmp);
            Zebra.Sdk.Comm.Connection conn = new Zebra.Sdk.Comm.TcpConnection("192.168.122.143", Zebra.Sdk.Comm.TcpConnection.DEFAULT_ZPL_TCP_PORT);
            try
            {
                conn.Open();
                ZebraPrinter zebraPrinter = ZebraPrinterFactory.GetInstance(conn);
                //zebraPrinter.PrintImage($@"E:\PC_Program\C#\LabelFactory\LabelFactory\bin\Debug\100x150-300bpi.png", 0, 0);
                zebraPrinter.PrintImage(zebraImageI, 0, 0, zebraImageI.Width, zebraImageI.Height, false);
                Zebra.Sdk.Printer.PrinterStatus printerStatus = zebraPrinter.GetCurrentStatus();
            }
            catch (ConnectionException ce)
            {
                Say(ce.ToString());
            }
            catch (ZebraPrinterLanguageUnknownException zplue)
            {
                Say(zplue.ToString());
            }
            catch (IOException ioe)
            {
                Say(ioe.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>打印储存在Link-OS打印机存储器中的ZPL脚本，同时输入变量的值。
        /// 
        /// </summary>
        /// ^XA
        /// ^DFE:FORMAT2.ZPL
        /// ^FS
        /// ^FT26,243^A0N,56,55^FH\^FN12"First Name"^FS
        /// ^FT26,296^A0N,56,55^FH\^FN11"Last Name"^FS
        /// ^FT258,73^A0N,39,38^FH\^FDVisitor^FS
        /// ^FO100,100^XG^FN13,1,1^FS
        /// ^FO5,17^GB601,379,8^FS
        /// ^XZ
        private void LinkOsPrinter()
        {
            //string pathToImageFileOnHost = $@"E:\PC_Program\C#\LabelFactory\LabelFactory\bin\Debug\100x150-300bpi.png";
            Zebra.Sdk.Comm.Connection conn = new Zebra.Sdk.Comm.TcpConnection("192.168.3.161", Zebra.Sdk.Comm.TcpConnection.DEFAULT_ZPL_TCP_PORT);
            try
            {
                // Zebra.Sdk.Graphics.ZebraImageI zebraImageI = Zebra.Sdk.Graphics.ZebraImageFactory.GetImage(pathToImageFileOnHost);
                Zebra.Sdk.Graphics.ZebraImageI zebraImageI = Zebra.Sdk.Graphics.ZebraImageFactory.GetImage(this._bmp);
                Dictionary<int, string> vars = new()
                {
                    {12,"John" },
                    {11,"Smith" },
                };
                Dictionary<int, ZebraImageI> imgVars = new()
                {
                    {13,zebraImageI},
                };

                conn.Open();
                ZebraPrinter zebraPrinter = ZebraPrinterFactory.GetInstance(conn);
                ZebraPrinterLinkOs zebraPrinterLinkOs = ZebraPrinterFactory.CreateLinkOsPrinter(zebraPrinter);
                if (zebraPrinterLinkOs != null)
                {
                    zebraPrinterLinkOs.PrintStoredFormatWithVarGraphics("E:FORMAT2.ZPL", imgVars, vars);
                }
            }
            catch (ConnectionException ce)
            {
                Say(ce.ToString());
            }
            catch (ZebraPrinterLanguageUnknownException zplue)
            {
                Say(zplue.ToString());
            }
            catch (IOException ioe)
            {
                Say(ioe.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
