using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProdKeeper.FileSystem.Test
{
    public class Body : IBody
    {
        public byte[] Content { get; set; }

        public MyMessage Valeur
        {
            get {
                if (Content == null)
                    return new MyMessage();
                var str = System.Text.Encoding.UTF8.GetString(Content);
                var sr = new StringReader(str);
                var xs = new XmlSerializer(typeof(MyMessage));
                return (MyMessage)xs.Deserialize(sr);
            }

            set
            {
                MyMessage objValue = value;
                if (objValue == null)
                    objValue = new MyMessage();
                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                var xs = new XmlSerializer(typeof(MyMessage));
                xs.Serialize(sw, value);
                Content = Encoding.UTF8.GetBytes(sb.ToString());
            }
        
        }
    }
}
