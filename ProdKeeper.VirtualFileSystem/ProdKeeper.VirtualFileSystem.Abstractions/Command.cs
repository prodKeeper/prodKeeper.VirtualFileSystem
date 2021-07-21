using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public abstract class Command : ICommand
    {
        public Command()
        {
            Header = null;
            Body = null;
        }
        public Command(IHeader header, IBody body)
        {
            Header = header;
            Body = body;
        }
        public IHeader Header { get; set; }
        public IBody Body { get ; set; }

    }
}
