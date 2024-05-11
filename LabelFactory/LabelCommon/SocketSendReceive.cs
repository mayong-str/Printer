using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace LabelCommon
{
    public class SocketSendReceive
    {
        #region 类属性

        /// <summary>类实例别名
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>获取本地节点信息
        /// 
        /// </summary>
        public IPEndPoint Local_IEP { get; private set; }

        /// <summary>获取远程节点信息
        /// 
        /// </summary>
        public IPEndPoint Remote_IEP { get; private set; }

        /// <summary>是否已经绑定到指定的本地IP和端口
        /// 
        /// </summary>
        public bool IsBound => this.socket == null ? false : this.socket.IsBound;

        /// <summary>指示Socket进行打开操作中
        /// 
        /// </summary>
        public bool IsOpening { get; private set; } = false;

        /// <summary>指示Socket进行发送操作中
        /// 
        /// </summary>
        public bool IsSending { get; private set; } = false;

        /// <summary>指示Socket进行接收操作中
        /// 
        /// </summary>
        public bool IsReceiving { get; private set; } = false;

        /// <summary>获取上一次Send或Receive操作时，与远程节点的通讯状态。
        /// /true:正常操作,false:操作出错/
        /// </summary>
        public bool RemoteIsConnected => this.socket == null ? false : this.socket.Connected;

        public byte[] Response { get; private set; }

        #endregion

        #region 类构造器
        public SocketSendReceive()
        {
        }

        #endregion

        #region 类公共方法

        /// <summary>设置本地IPEndPoint和远程IPEndPoint，通过提供连接字符串的方式。
        /// 
        /// </summary>
        /// <param name="localConnString">本地节点连接字符串</param>
        /// <param name="remoteConnString">远程节点连接字符串</param>
        public void SetIEP(string localConnString, string remoteConnString)
        {
            this.Remote_IEP = ConnStringToIEP(remoteConnString);
            this.Local_IEP = ConnStringToIEP(localConnString); ;
        }

        /// <summary>设置本地IPEndPoint和远程IPEndPoint，通过提供IPEndPoint的方式。
        /// 
        /// </summary>
        /// <param name="local">本地节点IPEndPoint</param>
        /// <param name="remote">远程节点IPEndPoint</param>
        public void SetIEP(IPEndPoint local, IPEndPoint remote)
        {
            this.Remote_IEP = remote;
            this.Local_IEP = local;
        }

        /// <summary>从连接字符串取得IPEndPoint
        /// 
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>IPEndPoint</returns>
        public IPEndPoint ConnStringToIEP(string connString)
        {
            string[] str = connString.Split(':');
            return new IPEndPoint(IPAddress.Parse(str[0]), int.Parse(str[1]));
        }

        /// <summary>Socket绑定到本地节点的指定端口,
        /// 返回true绑定成功，返回false绑定失败。
        /// </summary>
        /// <returns>bool</returns>
        public bool Bind()
        {
            InitSocket_Tcp();
            try
            {
                this.socket.Bind(Local_IEP);
                Say($"SocketBind> >Binding succeeded.<{Local_IEP}>{NowString()}");
            }
            catch (Exception ex)
            {
                Say($"SocketBind> >Bind Error<{ex.Message}>{NowString()}");
            }
            return this.socket.IsBound;
        }

        /// <summary>与远程节点建立连接，
        /// 返回true连接成功，返回false连接失败。
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            this.IsOpening = true;
            try
            {
                this.socket.Connect(this.Remote_IEP);//建立连接
                //this.CheckConnStatus();//验证连接
                Say($"SocketOpen> >{this.Remote_IEP}>Connected!{NowString()}");
            }
            catch (Exception ex)
            {
                Say($"SocketOpen> >Open Error<{ex.Message}>{NowString()}");
                this.IsOpening = false;
            }
            this.IsOpening = false;
            return this.socket.Connected;
        }

        /// <summary>异步打开，不阻塞调用线程。
        /// 
        /// </summary>
        public async void OpenAsync()
        {
            bool b = await Task.Run<bool>(() =>
              {
                  return Open();
              });
        }

        /// <summary>异步发送，不阻塞调用线程。
        /// 
        /// </summary>
        /// <param name="data"></param>
        public async void SendAsync(byte[] data)
        {
            (bool b, int i) = await Task.Run<(bool, int)>(() =>
            {
                return SendData(data);
            });
        }

        public byte[] DialogueCommunication(byte[] data)
        {
            return null;
        }

        public (bool, int) Send(byte[] data)
        {
            if (data.Length > 1400)
            {
                List<byte> bytes = new List<byte>(data);
                List<byte[]> ba = new List<byte[]>();
                do
                {
                    ba.Add(bytes.Take(1400).ToArray());
                    bytes.RemoveRange(0, 1400);
                } while (bytes.Count >= 1400);
                ba.Add(bytes.ToArray());
                foreach (var item in ba)
                {
                    SendData(item);
                    Thread.Sleep(20);
                }
                return (true, data.Length);
            }
            else
            {
                return SendData(data);
            }
        }

        /// <summary>对远程节点进行发送操作，阻塞调用线程。
        /// 
        /// </summary>
        /// <param name="data">(byte[])发送的数据</param>
        /// <returns>(bool,int)发送状态，完成发送字节数</returns>
        ///    
        public (bool, int) SendData(byte[] data)
        {
            this.IsSending = true;
            this.Response = null;
            int i = -1;
            if (this.RemoteIsConnected == false) return (false, i);//远程节点连接异常
            try
            {
                i = this.socket.Send(data, data.Length, SocketFlags.None);
                Say($"SendData> >{this.Remote_IEP}>发送<{i}>字节。{NowString()}");
            }
            catch (Exception ex)
            {
                Say($"SendData> >Send Error<{ex.Message}>{NowString()}");
                this.IsSending = false;
                return (false, i);
            }
            this.IsSending = false;
            return (true, i);
        }

        /// <summary>对远程节点进行发送后再接收操作。
        /// 
        /// </summary>
        /// <param name="sendData">(byte[])发送的数据</param>
        /// <returns>(byte[])接收到的数据</returns>
        public byte[] SendAndReceive(byte[] sendData)
        {
            if (this.RemoteIsConnected == false) return null;//远程节点连接异常
            byte[] receiveBytes = new byte[1024];
            byte[] resultBytes;
            try
            {
                (_, int i) = this.SendData(sendData);
                Say($"SendAndReceive> >发送<{i}>字节。{NowString()}");
                Thread.Sleep(200);//如不加延时会无法接收，延时时间应根据网速和远程节点的响应时间为依据。
                // Get reply from the server.
                i = this.socket.Receive(receiveBytes, 0, socket.Available, SocketFlags.None);
                //resultBytes = new byte[i];
                resultBytes = receiveBytes.Take(i).ToArray();
                Say($"SendAndReceive> >接收<{i}>字节<{BitConverter.ToString(receiveBytes, 0, i)}>");
            }
            catch (SocketException e)
            {
                Say($"SendAndReceive> >{e.Message} Error code: {e.ErrorCode}.");
                return null;
            }
            return resultBytes;
        }

        /// <summary>检测与远程节点的连接状态，
        /// 返回true连接正常，返回false连接异常。
        /// </summary>
        /// <returns>(bool)</returns>
        public bool CheckConnStatus()
        {
            // This is how you can determine whether a socket is still connected.
            bool blockingState = this.socket.Blocking;
            try
            {
                this.socket.Blocking = false;
                this.socket.Send(checkBytes, 0, SocketFlags.None);//进行一次零字节的发送操作，将会更新Socket的Connected属性
                Say($"CheckConnStatus>>Connected!");
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK
                if (e.NativeErrorCode.Equals(10035))
                {
                    Say($"CheckConnStatus>>Still Connected, but the Send would block");
                }
                else
                {
                    Say($"CheckConnStatus>>Disconnected: error code <{e.NativeErrorCode}>!");
                }
            }
            finally
            {
                this.socket.Blocking = blockingState;
                //this.socket.Blocking = false; ;
            }
            Say($"CheckConnStatus>>Connected: <{this.socket.Connected}>");
            return this.socket.Connected;
        }

        public void Close()
        {
            // Release the socket.  
            if (this.socket != null && this.socket.Connected)
            {
                this.socket?.Shutdown(SocketShutdown.Both);
            }
            this.socket?.Close();
        }

        #region 使用ManualResetEvent.WaitOne()
        public bool ConnWait()
        {
            connectDone.Reset();
            this.socket.BeginConnect(this.Remote_IEP, new AsyncCallback(ConnectCallback), this.socket);
            this.IsOpening = true;
            if (connectDone.WaitOne(5000, false))
            {
                this.IsOpening = false;
                return true;
            }
            else
            {
                this.IsOpening = false;
                this.socket.Close();
                return false;
            }
        }

        public bool SendWait(byte[] data)
        {
            Send(this.socket, data);
            this.IsSending = true;
            bool isback = sendDone.WaitOne(100);
            this.IsSending = false;
            return isback;
        }

        /// <summary>等待接收，并阻塞线程到超时。
        /// 默认100ms超时时长。
        /// </summary>
        /// <param name="timeout">超时时长</param>
        /// <returns>超时标志</returns>
        public bool ReceiveWait(int size, int timeout = 100)
        {
            BeginReceive(this.socket, size);
            this.IsReceiving = true;
            bool isback = receiveDone.WaitOne(timeout);
            this.IsReceiving = false;
            return isback;
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            Socket client = null;
            try
            {
                // Retrieve the socket from the state object.  
                client = (Socket)ar.AsyncState;
                // Complete the connection.  
                client.EndConnect(ar);
                if (client.Connected == true)
                {
                    Say($"Socket connected to {client.RemoteEndPoint}");
                }
            }
            catch (Exception e)
            {
                Say($"ConnectCallback error! {e.Message}{NowString()}");
            }
            finally
            {
                // Signal that the connection has been made.  
                connectDone.Set();
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        public void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] resByte = new byte[8192];
                    int resInt = this.socket.Receive(resByte);
                    if (resInt > 0)
                    {
                        this.Response = CutOut(resByte, 0, resInt);
                        break;
                    }
                }
            }
            catch (SocketException sex)
            {
                if (sex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Say($"Receive> >服务端断开！");
                }
                Say($"Receive> >Socket error!<{sex.Message}>");
            }
            catch (Exception ex)
            {
                Say($"Receive> >程序出现异常<{ex.Message}>");
            }
        }

        private void BeginReceive(Socket client, int size)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject
                {
                    workSocket = client
                };

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, size, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    this.Response = CutOut(state.buffer, 0, bytesRead);
                }
                else
                {
                    this.Response = null;
                }
                receiveDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Send(Socket client, byte[] data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            //byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Say($"Sent {bytesSent} bytes to server.");

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #endregion

        #region 类私有方法

        private void InitSocket_Udp()
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                ReceiveBufferSize = 8192,//接收缓冲区大小
                ReceiveTimeout = 6000,//接收超时，毫秒
                SendBufferSize = 8192,//发送缓冲区大小
                SendTimeout = 6000,//发送超时，毫秒
                Ttl = 64,//默认值为32
            };
        }

        private void InitSocket_Tcp()
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ReceiveBufferSize = 8192,//接收缓冲区大小
                ReceiveTimeout = 6000,//接收超时，毫秒
                SendBufferSize = 8192,//发送缓冲区大小
                SendTimeout = 6000,//发送超时，毫秒
                Ttl = 64,//默认值为32
            };
        }

        /// <summary>截取byte数组
        /// 
        /// </summary>
        /// <param name="srcArray">byte数组</param>
        /// <param name="index">起点</param>
        /// <param name="size">元素个数</param>
        /// <returns>子Int16数组</returns>
        public byte[] CutOut(byte[] srcArray, int index, int size)
        {
            byte[] res = new byte[size];
            Array.Copy(srcArray, index, res, 0, size);
            return res;
        }

        private string NowString() => $"<{DateTime.Now.ToString("HH:mm:ss.fff")}>";

        private void Say(string msg = "") => Console.WriteLine($"{this.Alias ?? "SocketSendReceive"}> >{msg}");
        #endregion

        #region 类私有成员变量

        private Socket socket;
        /// <summary>测试连接状态用的空Byte数组,
        /// 避免在CheckConnStatus()方法中频繁的初始化空Byte数组。
        /// </summary>
        private readonly byte[] checkBytes = new byte[1];

        private readonly ManualResetEvent connectDone = new ManualResetEvent(false);
        private readonly ManualResetEvent sendDone = new ManualResetEvent(false);
        private readonly ManualResetEvent receiveDone = new ManualResetEvent(false);



        #endregion
    }

    /// <summary>用于从远程设备接收数据的状态对象，
    /// 用于异步Socket通讯中。
    /// </summary>
    class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];

    }
}
