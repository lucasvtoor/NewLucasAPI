using System.Net.Sockets;
using API.Headers.Structs;
using API.Requests;

namespace API.Headers;

[Header]

public class AcceptLanguageHeader : Header
{
    internal AcceptLanguage[] Languages;
    public override void Read(HttpRequest request, string content)
    {
        return;
        if(!content.Contains("Accept-Language: ")) return;
        //ClientHints = (from s in content.Substring("Accept-Language: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}