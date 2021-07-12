using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstraction
{
    public interface IVirtualFileSystem
    {
        VFSStatus CreateFile();
        //VFSStatus CloseFile();
        VFSStatus ReadFile();
        VFSStatus WriteFile();
        VFSStatus FlushFileBuffer();
        //VFSStatus LockFile();
        //VFSStatus UnlockFile();
        VFSStatus QueryDirectory();
        VFSStatus GetFileInformation();
        VFSStatus SetFileInformation();
        VFSStatus GetFileSystemInformation();
        VFSStatus SetFileSystemInformation();
        //VFSStatus GetSecurityInformation();
        //VFSStatus SetSecurityInformation();
        //VFSStatus NotifyChange();
        //VFSStatus Cancel();
        //VFSStatus DeviceIOControl();
    }
}
