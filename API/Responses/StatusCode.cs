using System.Net.Sockets;
using API.Requests;

namespace API.Responses;

public abstract partial class StatusCode
{
    public int Code;
    public string Body;

    protected StatusCode(int code, string body)
    {
        Code = code;
        Body = body;
    }
    
    private static Lazy<StatusCode> ok = new(() => new Ok());

    public static StatusCode Ok 
    {
        get { return ok.Value; }
    }

    public async Task Write(NetworkStream stream)
    {
        await stream.WriteStringAsync($"HTTP/1.1 {Code} {Body}");
    }
}

public abstract partial class StatusCode
{
    
}