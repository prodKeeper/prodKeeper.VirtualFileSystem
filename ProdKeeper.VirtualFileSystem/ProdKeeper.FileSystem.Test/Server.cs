using ProdKeeper.VirtualFileSystem.Abstractions.Client;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class Server : IVirtualFileSystemServer
    {
        public string Name => "Test File SystemServer";

        public bool Listen { get; set; }

        public int Port => 8080;

        public ICommand[] Commands => throw new NotImplementedException();

        public ICommand KeepAlive => throw new NotImplementedException();

        public bool AddShare(IVirtualFileSystemShared share, IVirtualFileSystemClient client)
        {
            throw new NotImplementedException();
        }

        public bool RemoveShare(IVirtualFileSystemShared share)
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
