using System.Net.Sockets;
using API.Requests;

namespace API;

public class WebServer
{
    public TcpListener Listener;
    public IRequestHandler RequestHandler;

    public async Task Start()
    {
        try
        {
            using var client = Listener.AcceptTcpClient();
            var cts = new CancellationTokenSource();
            await RequestHandler.HandleAsync(client.GetStream(), cts);
        }
        catch (SocketException e)
        {

        }
        finally
        {
            Listener.Stop();
        }
    }
    
    
}