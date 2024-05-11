using System;
using System.Threading;
using System.Windows.Forms;

namespace LabelMaker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }

    /*
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FormMain());

            Thread th = new Thread(new ThreadStart(method));
            th.Start();
            Console.WriteLine("start.." + DateTime.Now.ToString("mm:ss fff"));
            bool isback = a1.WaitOne(1000);
            Console.WriteLine($"end  ..{DateTime.Now.ToString("mm:ss fff")}<{isback}>");
            Console.Read();
        }
        static void method()
        {
            Thread.Sleep(4000); //超时返回
            Console.WriteLine("Async.." + DateTime.Now.ToString("mm:ss fff"));
            a1.Set();
        }
        static ManualResetEvent a1 = new ManualResetEvent(false);
    } */
}
