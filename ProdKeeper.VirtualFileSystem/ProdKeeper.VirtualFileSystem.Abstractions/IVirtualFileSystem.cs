using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.VirtualFileSystem.Abstraction
{
    public interface IVirtualFileSystem
    {
        VFSStatus CreateFileHandler(out IVirtualFile fileHandler);
        VFSStatus CloseFile(IVirtualFile fileHandler);
        VFSStatus ReadFile(IVirtualFile fileHandler);
        VFSStatus WriteFile(IVirtualFile fileHandler);
        VFSStatus FlushFileBuffer(IVirtualFile fileHandler);
        //VFSStatus LockFile();
        //VFSStatus UnlockFile();
        VFSStatus QueryDirectory(IVirtualFile fileHandler);
        VFSStatus GetFileInformation(IVirtualFile fileHandler);
        VFSStatus SetFileInformation(IVirtualFile fileHandler);
        VFSStatus GetFileSystemInformation(IVirtualFile fileHandler);
        VFSStatus SetFileSystemInformation(IVirtualFile fileHandler);
        //VFSStatus GetSecurityInformation();
        //VFSStatus SetSecurityInformation();
        //VFSStatus NotifyChange();
        //VFSStatus Cancel();
        //VFSStatus DeviceIOControl();
    }
}
