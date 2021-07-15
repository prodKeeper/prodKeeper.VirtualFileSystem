using ProdKeeper.FileSystem.SMB;
using ProdKeeper.VirtualFileSystem;
using System;

namespace ProdKeeper.VFSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VFSServer vfs = new VFSServer();
            Server smb = new Server();
            vfs.AddServer(smb);
            vfs.Start();
        }
    }
}
