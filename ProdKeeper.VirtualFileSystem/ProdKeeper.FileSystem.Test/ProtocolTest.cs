using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class ProtocolTest : Protocol<CommandTest>
    {
        protected override int HeaderSize => throw new NotImplementedException();

        protected override IBody DecodeBody(byte[] message)
        {
            throw new NotImplementedException();
        }

        protected override IHeader DecodeHeader(byte[] message)
        {
            throw new NotImplementedException();
        }

        protected override byte[] EncodeBody(Command message)
        {
            throw new NotImplementedException();
        }

        protected override byte[] EncodeHeader(Command message)
        {
            throw new NotImplementedException();
        }
    }
}
