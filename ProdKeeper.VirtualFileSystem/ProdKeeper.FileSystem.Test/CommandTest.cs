using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class CommandTest : Command
    {
        public CommandTest() { }
        public CommandTest(Header h, Body b) : base(h, b) { }
    }
}
