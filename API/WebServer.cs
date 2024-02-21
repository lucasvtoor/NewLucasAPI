using System.Net.Sockets;
using API.Requests;

namespace API;

public class WebServer
{
    public TcpListener Listener;
    public IRequestHandler RequestHandler;
    public ILogger Logger;
    public DependencyInjector Injector;

    public WebServer(IRequestHandler requestHandler, ILogger logger, DependencyInjector injector)
    {
        Logger = logger;
        Logger.LogInfo($"Starting new Server on port {Properties.Port}");
        Listener = new TcpListener(Properties.IpAddress, Properties.Port);
        RequestHandler = requestHandler;
    }

    public static WebServer Build()
    {
        var injector = new DependencyInjector();
        var ws = new WebServer(injector.GetSingleton<IRequestHandler>(), injector.GetSingleton<ILogger>(), injector);
        return ws;
    }

    public async Task Start()
    {
        Logger.LogLogo();
        Listener.Start();
        while (true)
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
        }
    }
}