using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface IBody
    {
        byte[] Content { get; set; }
    }
}
