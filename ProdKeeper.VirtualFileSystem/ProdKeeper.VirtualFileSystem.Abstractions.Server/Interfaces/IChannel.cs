using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server.Interfaces
{
    public interface IChannel
    {
        int Port { get; }
        string Name { get; }

        void Start(IPEndPoint endPoint = null);
        Task Process(Socket socket);
    }
}
