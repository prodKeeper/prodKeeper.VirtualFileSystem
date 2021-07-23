using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB.SMB.Command
{
    public abstract class CommandBase
    {
        public abstract int BodySize{get;}
    }
}
