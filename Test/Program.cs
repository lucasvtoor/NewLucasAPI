using API;


public class Program
{
    public static async Task Main(string[] args)
    {
        await WebServer.Build().Start();
    }
}