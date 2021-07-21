using System.Net.Sockets;
using System.Threading.Tasks;

namespace ProdKeeper.VirtualFileSystem.Abstractions.Interfaces
{
    public interface IProtocol<TCommand> where TCommand:Command, new()
    {
        Task<TCommand> ReceiveAsync(NetworkStream networkStream);
        Task SendAsync(NetworkStream networkStream, TCommand message);

        TCommand ProcessMessage(TCommand message);
    }
}