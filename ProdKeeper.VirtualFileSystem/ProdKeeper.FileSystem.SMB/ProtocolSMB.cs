using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class ProtocolSMB : Protocol<MessageSMB>
    {
        protected override int HeaderSize => 64;

        protected override IBody DecodeBody(byte[] message)
        {
            throw new NotImplementedException();
        }

        protected override IHeader DecodeHeader(byte[] message)
        {
            byte[] byteHeader = new byte[HeaderSize];
            Array.Copy(message, 0, byteHeader, 0, HeaderSize);

            HeaderSMB header = new HeaderSMB();
            header.Content = byteHeader;
            return header;
        }

        protected override byte[] EncodeBody(Message message)
        {
            return message.Header.Content;
        }

        protected override byte[] EncodeHeader(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
