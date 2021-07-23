using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class BodySMB : IBody
    {
        public byte[] Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
