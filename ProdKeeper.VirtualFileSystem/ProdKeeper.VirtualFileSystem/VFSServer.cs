using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ProdKeeper.VirtualFileSystem
{
    public class VFSServer
    {
        List<IVirtualFileSystemServer> _lstServer;
        List<Thread> _lstThread;

        public VFSServer()
        {
            _lstServer = new List<IVirtualFileSystemServer>();
            _lstThread = new List<Thread>();
        }
        public bool Start()
        {

            foreach(IVirtualFileSystemServer serv in _lstServer)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(StartServer));
                thread.Start(serv);
                _lstThread.Add(thread);
            }
            bool allThreadAlive=true;
            while (allThreadAlive)
            {
                allThreadAlive = (from t in _lstThread where t.IsAlive == true select t).Count() > 0;
                Thread.Sleep(200);
            }
            return true;
        }

        public bool AddServer(IVirtualFileSystemServer server)
        {
            bool alreadyAssign = (from s in _lstServer where s.Port == server.Port select s).FirstOrDefault() != null;
            if (alreadyAssign)
            {
                throw new VirtualFileSystemException();
            }  
            _lstServer.Add(server);
            return true;
        }

        private void StartServer(object server)
        {
            StateObject so = new StateObject();
            IVirtualFileSystemServer vfsServer = (IVirtualFileSystemServer)server;
            so.Server = vfsServer;
            IPAddress address = IPAddress.Parse("192.168.178.73");
            TcpListener m_listenerSocket = new TcpListener(address, vfsServer.Port);
            so.SendSocket = m_listenerSocket;
            m_listenerSocket.Start();
            m_listenerSocket.BeginAcceptTcpClient(ConnectRequestCallback, so);
            while (vfsServer.Listen)
            {
                if (vfsServer.KeepAlive != null)
                {
                    byte[] kaMsg = vfsServer.KeepAlive.Execute();
                    m_listenerSocket.Server.BeginSend(kaMsg,0 ,kaMsg.Length,SocketFlags.None,keepAliveCallBack,so);
                }
                    
                Thread.Sleep(200);
            }
        }

        private void keepAliveCallBack(IAsyncResult ar)
        {
            StateObject m_listenerSocket = (StateObject)ar.AsyncState;
        }

        private void ConnectRequestCallback(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;

            TcpListener listenerSocket = so.SendSocket;

            TcpClient clientListener;
            try
            {
                clientListener = listenerSocket.EndAcceptTcpClient(ar);
                so.WorkSocket = clientListener;
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (SocketException ex)
            {
                const int WSAECONNRESET = 10054; // The client may have closed the connection before we start to process the connection request.
                const int WSAETIMEDOUT = 10060; // The client did not properly respond after a period of time.
                // When we get WSAECONNRESET or WSAETIMEDOUT, we have to continue to accept other connection requests.
                // See http://stackoverflow.com/questions/7704417/socket-endaccept-error-10054
                if (ex.ErrorCode == WSAECONNRESET || ex.ErrorCode == WSAETIMEDOUT)
                {
                    listenerSocket.BeginAcceptTcpClient(ConnectRequestCallback, so);
                }
                return;
            }
            Helpers.SetKeepAlive(clientListener, TimeSpan.FromMinutes(2));
            IPEndPoint clientEndPoint = (IPEndPoint)clientListener.Client.RemoteEndPoint;
            //Thread senderThread = new Thread(delegate ()
            //{
            //    ProcessSendQueue(state);
            //});
            //senderThread.IsBackground = true;
            //senderThread.Start();
            try
            {
                // Direct TCP transport packet is actually an NBT Session Message Packet,
                // So in either case (NetBios over TCP or Direct TCP Transport) we will receive an NBT packet.
                clientListener.Client.BeginReceive(so.ReceiveBuffer, 0, StateObject.BUFFER_SIZE, 0, ReceiveCallback, so);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (SocketException)
            {
            }
            

            listenerSocket.BeginAcceptTcpClient(ConnectRequestCallback, listenerSocket);

        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;
            TcpClient s = so.WorkSocket;

            int read = s.Client.EndReceive(ar);

            if (read > 0)
            {
                so.Sb.Append(Encoding.ASCII.GetString(so.ReceiveBuffer, 0, read));
                s.Client.BeginReceive(so.ReceiveBuffer, 0, StateObject.BUFFER_SIZE, 0,
                                         new AsyncCallback(ReceiveCallback), so);
            }
            else
            {
                if (so.Sb.Length > 1)
                {
                    //All of the data has been read, so displays it to the console
                    string strContent;
                    strContent = so.Sb.ToString();
                    Console.WriteLine(String.Format("Read {0} byte from socket" +
                                     "data = {1} ", strContent.Length, strContent));
                }
                s.Close();
            }
        }
    }
}
