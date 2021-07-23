using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB.SMB.Command
{
    public static class CommandFactory
    {
        public static CommandBase CreateCommand(SMB2CommandName command)
        {
            CommandBase returnValue;
            switch (command)
            {
                case SMB2CommandName.Cancel:
                    returnValue= new WriteCommand();
                    break;
                case SMB2CommandName.ChangeNotify:
                    returnValue = new ChangeNotifyCommand();
                    break;
                case SMB2CommandName.Close:
                    returnValue = new CloseCommand();
                    break;
                case SMB2CommandName.Create:
                    returnValue = new CreateCommand();
                    break;
                case SMB2CommandName.Echo:
                    returnValue = new EchoCommand();
                    break;
                case SMB2CommandName.Flush:
                    returnValue = new FlushCommand();
                    break;
                case SMB2CommandName.IOCtl:
                    returnValue = new IOCtlCommand();
                    break;
                case SMB2CommandName.Lock:
                    returnValue = new LockCommand();
                    break;
                case SMB2CommandName.Logoff:
                    returnValue = new LogoffCommand();
                    break;
                case SMB2CommandName.Negotiate:
                    returnValue = new NegotiateCommand();
                    break;
                case SMB2CommandName.OplockBreak:
                    returnValue = new OplockBreakCommand();
                    break;
                case SMB2CommandName.QueryDirectory:
                    returnValue = new QueryDirectoryCommand();
                    break;
                case SMB2CommandName.QueryInfo:
                    returnValue = new QueryInfoCommand();
                    break;
                case SMB2CommandName.Read:
                    returnValue = new ReadCommand();
                    break;
                case SMB2CommandName.SessionSetup:
                    returnValue = new SessionSetupCommand();
                    break;
                case SMB2CommandName.SetInfo:
                    returnValue = new SetInfoCommand();
                    break;
                case SMB2CommandName.TreeConnect:
                    returnValue = new TreeConnectCommand();
                    break;
                case SMB2CommandName.TreeDisconnect:
                    returnValue = new TreeDisconnectCommand();
                    break;
                case SMB2CommandName.Write:
                    returnValue = new WriteCommand();
                    break;
                default:
                    returnValue = null;
                    break;

            }
            return returnValue;
        }
    }
}
