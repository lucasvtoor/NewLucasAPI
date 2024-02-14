using System.Net.Sockets;

namespace API.Requests;

public interface IRequestHandler
{
    Task HandleAsync(NetworkStream stream, CancellationTokenSource cts);
}