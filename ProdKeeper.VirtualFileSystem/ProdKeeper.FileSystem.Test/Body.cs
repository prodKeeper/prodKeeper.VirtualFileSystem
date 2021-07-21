using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class Body : IBody
    {
        public byte[] Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
