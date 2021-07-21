using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface ICommand 
    {
        IHeader Header { get; set; }
        IBody Body { get; set; }

    }
}
