using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ProdKeeper.VirtualFileSystem
{
    internal class StateObject
    {
        private TcpClient workSocket;
        private TcpListener sendSocket;
        private IVirtualFileSystemServer server;
        public const int BUFFER_SIZE = 1024;
        private byte[] sendBuffer;
        private byte[] receiveBuffer;
        private StringBuilder sb;

        public TcpClient WorkSocket { get => workSocket; set => workSocket = value; }
        public byte[] SendBuffer { get => sendBuffer; set => sendBuffer = value; }
        public byte[] ReceiveBuffer { get => receiveBuffer; set => receiveBuffer = value; }
        public StringBuilder Sb { get => sb; set => sb = value; }
        public TcpListener SendSocket { get => sendSocket; set => sendSocket = value; }
        public IVirtualFileSystemServer Server { get => server; set => server = value; }

        public StateObject()
        {
            WorkSocket = null;
            SendBuffer = new byte[BUFFER_SIZE];
            ReceiveBuffer = new byte[BUFFER_SIZE];
            Sb = new StringBuilder();
        }
    }
}
