using ProdKeeper.VirtualFileSystem.Abstraction;
using ProdKeeper.VirtualFileSystem.Abstractions.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class Client : IVirtualFileSystemClient
    {
        public string Name { get => "Test Client"; }
        public IVirtualFileSystem FileSystem { get { return new TestClientFS(); }  }
    }
}
