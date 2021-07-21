using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public class Command<IHeader, IBody> : ICommand<IHeader, IBody>
    {
        public IHeader Header { get; set; }
        public IBody Body { get ; set; }

        public virtual ICommand<IHeader, IBody> Parse(byte[] MessageContent)
        {
            this.Body = Body;
            this.Header = Header;
            return this;
        }
    }
}
