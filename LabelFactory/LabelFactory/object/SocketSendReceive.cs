using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LabelFactory
{
    class SocketSendReceive
    {
        public SocketSendReceive(IPEndPoint local, IPEndPoint remote)
        {
            this.local_IEP = local;
            this.remote_IEP = remote;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(local_IEP);
        }

        public void Open()
        {
            socket.Connect(this.remote_IEP);
        }

        public void SendData(byte[] data)
        {
            socket.Send(data);
            say("打印指令发送已完成");
        }

        public void Close()
        {
            if (socket != null) socket.Close();
        }

        private void say(string msg)
        {
            Console.WriteLine("SocketSendReceive>>>>" + msg);
        }

        private IPEndPoint local_IEP;

        private IPEndPoint remote_IEP;

        private Socket socket;
    }
}
