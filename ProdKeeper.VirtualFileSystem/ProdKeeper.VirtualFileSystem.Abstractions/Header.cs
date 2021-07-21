using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public abstract class Header : IHeader
    {
        public int BodyLength { get ; set ; }
        public byte[] Content { get ; set ; }

        public abstract void Parse(byte[] content);
    }
}
