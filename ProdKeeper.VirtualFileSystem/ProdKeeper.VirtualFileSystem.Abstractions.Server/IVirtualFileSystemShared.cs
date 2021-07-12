using ProdKeeper.VirtualFileSystem.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server
{
    public interface IVirtualFileSystemShared
    {
        string Name { get; set; }
        IVirtualFileSystem FileSystem { get; set; }
    }
}
