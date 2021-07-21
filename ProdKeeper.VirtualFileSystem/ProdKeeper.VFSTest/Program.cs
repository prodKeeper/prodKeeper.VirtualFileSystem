using ProdKeeper.VirtualFileSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VFSTest
{
    public class Program
    {
        public static void Main()
        {
            Server server = new Server();

            server.Start();
        }
    }
}
