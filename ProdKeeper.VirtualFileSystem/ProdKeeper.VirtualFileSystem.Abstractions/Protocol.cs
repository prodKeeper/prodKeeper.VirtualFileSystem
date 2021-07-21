using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ProdKeeper.VirtualFileSystem.Abstractions
{
    public abstract class Protocol<TCommand> : IProtocol<TCommand> where TCommand:Command, new()
    {
        protected abstract int HeaderSize { get; }
        public async Task<TCommand> ReceiveAsync(NetworkStream networkStream)
        {
            TCommand commandType = new TCommand();
            commandType.Header = await ReadHeader(networkStream).ConfigureAwait(false);
            AssertValidMessageLength(commandType.Header.BodyLength);
            commandType.Body = await ReadBody(networkStream, commandType.Header.BodyLength);
            return commandType;
        }

        public TCommand ProcessMessage(TCommand message)
        {
            return message;
        }
        public async Task SendAsync(NetworkStream networkStream, TCommand message)
        {
            var (header, body) = Encode(message);
            await networkStream.WriteAsync(header, 0, header.Length);
            await networkStream.WriteAsync(body, 0, body.Length);
        }

        async Task<IHeader> ReadHeader(NetworkStream networkStream)
        {
            var headerBytes = await ReadAsync(networkStream, HeaderSize).ConfigureAwait(false);
            return DecodeHeader(headerBytes);
        }

        async Task<IBody> ReadBody(NetworkStream networkStream, int bodyLength)
        {
            var bodyByte = await ReadAsync(networkStream, bodyLength).ConfigureAwait(false);
            return DecodeBody(bodyByte);

        }

        async Task<byte[]> ReadAsync(NetworkStream networkStream, int byteToRead)
        {
            var buffer = new byte[byteToRead];
            var byteRead = 0;
            while (byteRead < byteToRead)
            {
                var bytesReceived = await networkStream.ReadAsync(buffer, byteRead, (byteToRead - byteRead)).ConfigureAwait(false);
                if (bytesReceived == 0)
                    throw new Exception("Socket Closed");
                byteRead += bytesReceived;
            }
            return buffer;
        }


        protected (byte[] header, byte[] body) Encode(Command message)
        {

            var bodyBytes = EncodeBody(message);
            var headerBytes = EncodeHeader(message);
            return (headerBytes, bodyBytes);
        }
        protected abstract IBody DecodeBody(byte[] message);
        protected abstract IHeader DecodeHeader(byte[] message);
        protected abstract byte[] EncodeBody(Command message);
        protected abstract byte[] EncodeHeader(Command message);
        protected virtual void AssertValidMessageLength(int messageLength)
        {
            if (messageLength < 1)
                throw new ArgumentOutOfRangeException("invalid Message length");
        }

        
    }
}
