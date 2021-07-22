using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class Header : IHeader
    {
        public int BodyLength { get; set; }
        public byte[] Content { get; set; }
    }
}
