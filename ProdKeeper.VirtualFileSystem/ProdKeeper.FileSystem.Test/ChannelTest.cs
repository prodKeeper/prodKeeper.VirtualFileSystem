using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class ChannelTest : Channel<MessageTest>
    {
        public override int Port => 9090;

        public override string Name => "Test Serveur";

        public override Protocol<MessageTest> Protocol => new ProtocolTest();
    }
}
