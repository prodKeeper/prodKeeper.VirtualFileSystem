using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface IHeader
    {
        int BodyLength { get; set; }
        byte[] Content { get; set; }

        void Parse(byte[] content);

    }
}
