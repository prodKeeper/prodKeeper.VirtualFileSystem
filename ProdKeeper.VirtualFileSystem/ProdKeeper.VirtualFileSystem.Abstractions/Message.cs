using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public abstract class Message : IMessage
    {
        public Message()
        {
            Header = null;
            Body = null;
        }
        public Message(IHeader header, IBody body)
        {
            Header = header;
            Body = body;
        }
        public virtual IHeader Header { get; set; }
        public virtual IBody Body { get ; set; }

    }
}
