using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]

public class AccessControlAllowCredentialsHeader : Header
{
    public override void Read(HttpRequest request, string content)
    {
        if(!content.Contains("Access-Control-Allow-Credentials: ")) return;
        //ClientHints = (from s in content.Substring("Accept-Language: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}