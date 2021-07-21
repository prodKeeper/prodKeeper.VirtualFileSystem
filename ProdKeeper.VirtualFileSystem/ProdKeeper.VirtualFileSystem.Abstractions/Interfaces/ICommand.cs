using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface ICommand<IHeader, IBody> 
    {
        IHeader Header { get; set; }
        IBody Body { get; set; }

        ICommand<IHeader, IBody> Parse(byte[] MessageContent);

    }
}
