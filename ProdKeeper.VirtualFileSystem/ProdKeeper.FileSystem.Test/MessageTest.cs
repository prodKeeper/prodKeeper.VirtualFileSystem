using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class MessageTest : Message
    {
        public MessageTest() { }
        public MessageTest(Header h, Body b) : base(h, b) { }
    }
}
