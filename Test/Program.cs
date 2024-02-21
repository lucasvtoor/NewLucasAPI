using API;
using API.Requests;

public class TestJongen
{
    [GET("/controller/{value}/requests")]
    public string Jongen(int value)
    {
        return "Yo";
    }

    [GET("/test")]
    public string GetTest()
    {
        Console.WriteLine("Werkt");
        return "CheckDit";
    }
}


public class Program
{
    public static async Task Main(string[] args)
    {
        await WebServer.Build().Start();
    }
}