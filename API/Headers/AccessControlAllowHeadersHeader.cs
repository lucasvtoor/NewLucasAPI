using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]

public class AccessControlAllowHeadersHeader : Header
{
    public string[] Headers;
    public override void Read(HttpRequest request, string content)
    {
        if(!content.Contains("Access-Control-Request-Headers: ")) return;
        Headers = (from s in content.Substring("Access-Control-Request-Headers: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}