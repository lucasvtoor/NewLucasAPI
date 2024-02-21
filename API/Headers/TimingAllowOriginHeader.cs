using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]

public class TimingAllowOriginHeader : Header
{
    public string[] Origins;
    public override void Read(HttpRequest request, string content)
    {
        if (!content.Contains("Timing-Allow-Origin: ")) return;
             Origins = (from s in content.Substring("Timing-Allow-Origin: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}