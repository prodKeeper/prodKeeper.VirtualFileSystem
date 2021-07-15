using ProdKeeper.VirtualFileSystem.Abstractions.Client;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class Server : IVirtualFileSystemServer
    {
        public string Name { get { return "SMB server"; } }
        public int Port { get { return 445; } }

        public Server()
        {
            this.Listen = true;
        }

        public ICommand[] Commands => throw new NotImplementedException();

        public bool Listen { get; set; }

        public ICommand KeepAlive => throw new NotImplementedException();

        public bool AddShare(IVirtualFileSystemShared share)
        {
            throw new NotImplementedException();
        }

        public bool AddShare(IVirtualFileSystemShared share, IVirtualFileSystemClient client)
        {
            throw new NotImplementedException();
        }

        public bool RemoveShare(IVirtualFileSystemShared share)
        {
            throw new NotImplementedException();
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
