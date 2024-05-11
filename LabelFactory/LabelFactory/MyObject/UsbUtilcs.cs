using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Diagnostics;

namespace LabelDesigner
{
    public class UsbUtilcs : IDisposable
    {
        /// <summary>设备VendorID，
        /// 默认值0x0a5f（斑马GT820打印机）。
        /// </summary>
        public int VendorID { get; private set; }
        /// <summary>设备ProductID，
        /// 默认值0x00c1（斑马GT820打印机）。
        /// </summary>
        public int ProductID { get; private set; }

        public UsbUtilcs()
            : this(0x0a5f, 0x00c1)
        {
        }

        public UsbUtilcs(int vid, int pid)
        {
            // MyUsbFinder = new UsbDeviceFinder(0x0a5f, 0x00c1);
            this.VendorID = vid;
            this.ProductID = pid;
            MyUsbFinder = new UsbDeviceFinder(this.VendorID, this.ProductID);

        }

        public bool Open()
        {
            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
            if (MyUsbDevice == null)
            {
                say("Device Not Found.");
                return false;
            }
            else
            {
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }
                say("Device is Found.<EndPoint 1>");
                say(MyUsbDevice.Info.ManufacturerString);
                say(MyUsbDevice.Info.ProductString);
                say(MyUsbDevice.Info.SerialString);
                return true;
            }
        }

        public void Close()
        {
            if (MyUsbDevice != null)
            {
                if (MyUsbDevice.IsOpen)
                {
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        wholeUsbDevice.ReleaseInterface(0);
                    }
                    MyUsbDevice.Close();
                }
            }
        }

        public ErrorCode Read()
        {
            ErrorCode ec = ErrorCode.None;
            reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
            byte[] readBuffer = new byte[1024];
            while (ec == ErrorCode.None)
            {
                int bytesRead;
                ec = reader.Read(readBuffer, 100, out bytesRead);
                if (bytesRead == 0) throw new Exception("No more bytes!");
            }
            return ec;
        }

        public ErrorCode Writer(byte[] buffer)
        {
            ErrorCode ec = ErrorCode.None;
            int bytesWritten;
            writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            ec = writer.Write(buffer, 2000, out bytesWritten);
            return ec;
        }     

        private void say(string msg)
        {
            Console.WriteLine("UsbUtilcs>>>>" + msg);
        }

        public void Dispose()
        {
            if (MyUsbDevice != null)
            {
                if (MyUsbDevice.IsOpen)
                {
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        wholeUsbDevice.ReleaseInterface(0);
                    }
                    MyUsbDevice.Close();
                }
                MyUsbDevice = null;
                UsbDevice.Exit();
            }
            GC.SuppressFinalize(this);
        }

        private UsbDevice MyUsbDevice;
        private UsbDeviceFinder MyUsbFinder;
        private UsbEndpointReader reader;
        private UsbEndpointWriter writer;
    }
}
