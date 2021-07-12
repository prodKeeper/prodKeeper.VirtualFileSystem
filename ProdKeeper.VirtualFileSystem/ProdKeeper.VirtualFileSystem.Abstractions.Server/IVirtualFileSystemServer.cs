using ProdKeeper.VirtualFileSystem.Abstractions.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server
{
    public interface IVirtualFileSystemServer
    {
        string Name { get; set; }

        bool Start();

        bool AddShare(IVirtualFileSystemShared share, IVirtualFileSystemClient client);

        bool RemoveShare(IVirtualFileSystemShared share);

        bool Stop();
    }
}
