using ProdKeeper.VirtualFileSystem.Abstraction;
using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class FileSystem : IVirtualFileSystem
    {
        public VFSStatus CreateFile()
        {
            throw new NotImplementedException();
        }

        public VFSStatus FlushFileBuffer()
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileSystemInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus QueryDirectory()
        {
            throw new NotImplementedException();
        }

        public VFSStatus ReadFile()
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileSystemInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus WriteFile()
        {
            throw new NotImplementedException();
        }
    }
}
