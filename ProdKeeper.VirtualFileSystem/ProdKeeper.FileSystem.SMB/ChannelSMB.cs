using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class ChannelSMB : Channel<MessageSMB>
    {
        public override int Port => 445;

        public override string Name => "Channel SMB";

        public override Protocol<MessageSMB> Protocol => new ProtocolSMB();
    }
}
