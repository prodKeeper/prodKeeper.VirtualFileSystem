﻿using ProdKeeper.VirtualFileSystem.Abstraction;
using ProdKeeper.VirtualFileSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class FileSystem : IVirtualFileSystem
    {
        public VFSStatus CloseFile()
        {
            throw new NotImplementedException();
        }

        public VFSStatus CloseFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus CreateFileHandler(out IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus FlushFileBuffer()
        {
            throw new NotImplementedException();
        }

        public VFSStatus FlushFileBuffer(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileSystemInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus GetFileSystemInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus QueryDirectory()
        {
            throw new NotImplementedException();
        }

        public VFSStatus QueryDirectory(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus ReadFile()
        {
            throw new NotImplementedException();
        }

        public VFSStatus ReadFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileSystemInformation()
        {
            throw new NotImplementedException();
        }

        public VFSStatus SetFileSystemInformation(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }

        public VFSStatus WriteFile()
        {
            throw new NotImplementedException();
        }

        public VFSStatus WriteFile(IVirtualFile fileHandler)
        {
            throw new NotImplementedException();
        }
    }
}
