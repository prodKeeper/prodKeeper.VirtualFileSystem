using ProdKeeper.VirtualFileSystem.Abstractions.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server
{
    public interface IVirtualFileSystemServer
    {
        string Name { get;  }

        bool Listen { get; set; }
        int Port { get; }

        bool AddShare(IVirtualFileSystemShared share, IVirtualFileSystemClient client);

        bool RemoveShare(IVirtualFileSystemShared share);

        ICommand[] Commands { get; }

        ICommand KeepAlive { get; }

        bool Stop();
    }
}
