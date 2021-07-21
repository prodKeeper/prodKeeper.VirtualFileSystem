using System.Net.Sockets;
using System.Threading.Tasks;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface IProtocol<TMessageType> where TMessageType : ICommand<IHeader, IBody>
    {
        Task<TMessageType> ReceiveAsync(NetworkStream networkStream);
        Task SendAsync(NetworkStream networkStream, TMessageType message);

        TMessageType ProcessMessage<TCommandType>(TCommandType message) where TCommandType : TMessageType, new();
    }
}