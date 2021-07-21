using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class Header : IHeader
    {
        public int BodyLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Parse(byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
