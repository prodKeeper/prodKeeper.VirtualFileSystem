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
            var str = System.Text.Encoding.UTF8.GetString(message.Body.Content);
            var sr = new StringReader(str);
            var xs = new XmlSerializer(typeof(MyMessage));
            MyMessage mm = (MyMessage)xs.Deserialize(sr);

            mm.IntProperty = mm.IntProperty + 4;
            mm.StringProperty = mm.StringProperty + " Processed";

            var sb2 = new StringBuilder();
            var sw2 = new StringWriter(sb2);
            var xs2 = new XmlSerializer(typeof(MyMessage));
            xs.Serialize(sw2, mm);
            CommandTest msgReturn = new CommandTest();
            
            message.Body.Content = Encoding.UTF8.GetBytes(sb2.ToString());
            return message;

        }
    }
}

