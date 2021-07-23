using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
namespace ProdKeeper.FileSystem.SMB
{
    public class MessageSMB : Message
    {
        public MessageSMB() { }
        public MessageSMB(HeaderSMB h, BodySMB b) : base(h, b) { }
    }
}
