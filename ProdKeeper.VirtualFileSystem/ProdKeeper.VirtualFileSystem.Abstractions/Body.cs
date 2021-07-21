using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public abstract class Body : IBody
    {
        public byte[] Content { get; set; }
    }
}
