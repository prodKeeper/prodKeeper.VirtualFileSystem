using System.IO;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server
{
    public interface ICommand
    {
        string CommandName { get; }

        byte[] Execute();
        byte[] Execute(Stream CommandContent);
        byte[] Execute(string CommandContent);
        byte[] Execute(byte[] CommandContent);
    }
}