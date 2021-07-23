using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using ProdKeeper.VirtualFileSystem.Abstractions.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Server
{
    public abstract class Channel<TCommand> : IChannel where TCommand:Message, new()
    {

        public abstract int Port { get; }

        public abstract string Name { get; }

        public abstract Protocol<TCommand> Protocol { get; }
        

        public async Task Process(Socket socket)
        {
            do
            {
                var clientSocket = await Task.Factory.FromAsync(
                    new Func<AsyncCallback, object, IAsyncResult>(socket.BeginAccept),
                    new Func<IAsyncResult, Socket>(socket.EndAccept),
                    null
                    ).ConfigureAwait(false);

                Console.WriteLine("Server:: Client Connected");
                List<byte> byteReceived = new List<byte>();
                using (var stream = new NetworkStream(clientSocket, true))
                {
                    var messageReceived=await Protocol.ReceiveAsync(stream).ConfigureAwait(false);
                    var messageToSend=Protocol.ProcessMessage(messageReceived);
                    await Protocol.SendAsync(stream, messageToSend);
                }
               

            } while (true);
        }

        public void Start(IPEndPoint endPoint=null)
        {
            if(endPoint==null)
                endPoint = new IPEndPoint(IPAddress.Loopback, Port);
            var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(128);
            _ = Task.Run(() => Process(socket));
        }
    }
}
