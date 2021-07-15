using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public interface IVirtualFile
    {
        long Handle { get; set; }
        string Path { get; set; }
        bool IsDirectory { get; set; }

        Stream Stream { get; set; }
    }
}
