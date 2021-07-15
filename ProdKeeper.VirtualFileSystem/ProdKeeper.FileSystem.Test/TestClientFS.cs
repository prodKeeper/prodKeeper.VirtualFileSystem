using ProdKeeper.VirtualFileSystem.Abstraction;
using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.Test
{
    public class TestClientFS : IVirtualFileSystem
    {
        public VFSStatus CloseFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus CreateFileHandler(out IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus FlushFileBuffer(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileSystemInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus QueryDirectory(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus ReadFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileSystemInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus WriteFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }
    }
}
