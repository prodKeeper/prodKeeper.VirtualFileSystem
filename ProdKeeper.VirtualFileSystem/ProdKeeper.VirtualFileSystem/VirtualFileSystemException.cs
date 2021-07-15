using System;
using System.Runtime.Serialization;

namespace ProdKeeper.VirtualFileSystem
{
    [Serializable]
    internal class VirtualFileSystemException : Exception
    {
        public VirtualFileSystemException()
        {
        }

        public VirtualFileSystemException(string message) : base(message)
        {
        }

        public VirtualFileSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VirtualFileSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}