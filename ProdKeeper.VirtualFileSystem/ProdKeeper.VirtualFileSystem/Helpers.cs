using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ProdKeeper.VirtualFileSystem
{
    public static class Helpers
    {
        public static void SetKeepAlive(TcpClient listener, TimeSpan timeout)
        {
            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            listener.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime, (int)timeout.TotalSeconds);
            listener.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval, 1);
            listener.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveRetryCount, 10);
        }
       
    }
}
