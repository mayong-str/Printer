using System;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;

namespace LabelDesigner
{
    class ComPortUtil
    {
        // PrintDocument
        SerialPort sp;
        public ComPortUtil(string portName, int baudRate)
        {   //19200,8E1
            int dataBits = 8;
            Parity parity = Parity.None;
            StopBits stopBits = StopBits.One;
            sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            sp.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
        }
        public void ComOpen()
        {
            sp.Open();
        }
        public void ComClose()
        {
            sp.Close();
        }

        public void ComWrite(byte[] buffer)
        {
            sp.Write(buffer, 0, buffer.Count());
        }

        public void ComWrite(string buffer)
        {
            sp.Write(buffer);
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] _data = new byte[sp.BytesToRead];
            sp.Read(_data, 0, _data.Length);
            if (_data.Length == 0)
            {
                return;
            }
            else
            {
                //string ss = System.Text.Encoding.ASCII.GetString(_data);
                //Console.WriteLine(string.Format ("0x{0:X}" ,System.Text.Encoding.ASCII.GetString(_data)));
                foreach (byte b in _data)
                {
                    Console.Write(string.Format("0x{0:X2} ", b));
                }
                Console.WriteLine("--");
            }
        }
    }

}
