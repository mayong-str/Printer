using System;
using System.Runtime.InteropServices;

namespace LabelCommon
{
    public class TSC_DllUtil
    {
        [DllImport("TSCLIB.dll", EntryPoint = "about")]
        public static extern int about();

        [DllImport("TSCLIB.dll", EntryPoint = "openport")]
        public static extern int openport(string printername);

        [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
        public static extern int barcode(string x, string y, string type, string height, string readable, string rotation, string narrow, string wide, string code);

        [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
        public static extern int clearbuffer();

        [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
        public static extern int closeport();

        [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
        public static extern int downloadpcx(string filename, string image_name);

        [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
        public static extern int formfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
        public static extern int nobackfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
        public static extern int printerfont(string x, string y, string fonttype, string rotation, string xmul, string ymul, string text);

        [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
        public static extern int printlabel(string set, string copy);

        [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
        public static extern int sendcommand(string printercommand);

        [DllImport("TSCLIB.dll", EntryPoint = "setup")]
        public static extern int setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);

        [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
        public static extern int windowsfont(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, string content);

        private const float dot = 0.125f;   //  打印头分辨率8dot/mm(203dot/inch)

        public static String mm2dotString(float mm)
        {
            if (mm >= 0.0)
            {
                return string.Format("{0:D}", mm2dot(mm));
            }
            return "0";
        }
        public static String mm2dotString(string mm)
        {
            float f = float.Parse(mm);
            if (f >= 0.0)
            {
                return string.Format("{0:D}", mm2dot(f));
            }
            return "0";
        }
        public static int mm2dot(string mm)
        {
            float f = float.Parse(mm);
            if (f >= 0.0)
            {
                return mm2dot(f);
            }
            return 0;
        }
        public static int mm2dot(float mm)
        {
            if (mm >= 0.0)
            {
                return (int)(mm / dot);
            }
            return 0;
        }
        public static void Barcode128(string content, string x, string y, string height = "12.7", string narrow = "3")
        {
            barcode(mm2dotString(x), mm2dotString(y), "128", mm2dotString(height), "2", "0", narrow, narrow, content);  //Drawing barcode
        }
        public static void QRcode(string content, string x, string y)
        {
            string qr = "QRCODE " + mm2dotString(x) + "," + mm2dotString(y) + "," + "H,10,A,0,M2,S7," + "\"" + content + "\"";  // 打印二维码
            sendcommand(qr);
        }
        public static void WindowsFont(string content, string x, string y, string height, string szFaceName, int rotation = 0, int fontstyle = 0, int fontunderline = 0)
        {
            int code = windowsfont(mm2dot(x), mm2dot(y), mm2dot(height), rotation, fontstyle, fontunderline, szFaceName, content);
        }
        public static void WindowsFont(string content, float x, float y, float height, string szFaceName, int rotation = 0, int fontstyle = 0, int fontunderline = 0)
        {
            int code = windowsfont(mm2dot(x), mm2dot(y), mm2dot(height), rotation, fontstyle, fontunderline, szFaceName, content);
        }
        public static void Print(int copy, string set = "1")
        {
            printlabel(set, copy.ToString());
            //TSCLIB_DLL.about();                                                      //Show the DLL version
            //openport("TSC TTP-344M Plus");                                           //Open specified printer driver
            //openport("TSC TTP-244 Pro");
            //setup("100", "63.5", "4", "8", "0", "0", "0");                           //Setup the media size and sensor type info
            //clearbuffer();                                                           //Clear image buffer
            //barcode("100", "100", "128", "100", "1", "0", "2", "2", "Barcode Test"); //Drawing barcode
            //printerfont("100", "250", "3", "0", "1", "1", "Print Font Test");        //Drawing printer font
            //windowsfont(100, 300, 24, 0, 0, 0, "ARIAL", "Windows Arial Font Test");  //Draw windows font
            //downloadpcx("UL.PCX", "UL.PCX");                                         //Download PCX file into printer
            //sendcommand("PUTPCX 100,400,\"UL.PCX\"");                                //Drawing PCX graphic
            //printlabel("1", "1");                                                    //Print labels
            //closeport();
        }
    }
}
