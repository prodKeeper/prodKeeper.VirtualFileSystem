using ProdKeeper.VirtualFileSystem.Abstractions;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProdKeeper.FileSystem.Test
{
    public class ProtocolTest : Protocol<CommandTest>
    {
        protected override int HeaderSize => 4;

        protected override IBody DecodeBody(byte[] message)
        {
            Body body = new Body();
            body.Content = message;
            return body;
        }

        protected override IHeader DecodeHeader(byte[] message)
        {
            Header header = new Header();
            header.Content = message;
            header.BodyLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(header.Content, 0));
            return header;

        }

        protected override byte[] EncodeBody(Command message)
        {
            return message.Body.Content;
        }

        protected override byte[] EncodeHeader(Command message)
        {
            ;
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(message.Body.Content.Length));
        }

        public override CommandTest ProcessMessage(CommandTest message)
        {
            Body body = (Body)message.Body;
            MyMessage mm = new MyMessage();
            mm.IntProperty = body.Valeur.IntProperty + 4;
            mm.StringProperty = body.Valeur.StringProperty + " Processed";
            ((Body)message.Body).Valeur = mm;
            
            return message;

        }
    }
}

