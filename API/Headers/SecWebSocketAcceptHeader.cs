using API.Requests;

namespace API.Headers;

[Header]

public class SecWebSocketAcceptHeader : Header
{
    public string key;
    public override void Read(HttpRequest request, string content)
    {
       if(false || false){}
    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Sec-WebSocket-Accept: {key}");
    }
}