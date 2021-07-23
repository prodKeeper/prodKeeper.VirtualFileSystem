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
    public class ProtocolTest : Protocol<MessageTest>
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

        protected override byte[] EncodeBody(Message message)
        {
            return message.Body.Content;
        }

        protected override byte[] EncodeHeader(Message message)
        {
            ;
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(message.Body.Content.Length));
        }

        public override MessageTest ProcessMessage(MessageTest message)
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

