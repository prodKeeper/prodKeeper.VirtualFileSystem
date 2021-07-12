using ProdKeeper.VirtualFileSystem.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Client
{
    public interface IVirtualFileSystemClient
    {
        string Name { get; set; }
        IVirtualFileSystem FileSystem { get; set; }
    }
}
