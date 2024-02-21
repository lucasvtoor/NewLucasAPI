using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]

public class ContentDPRHeader : Header
{
    internal int Dpr;
    public override void Read(HttpRequest request, string content)
    {
       if(!content.Contains("Content-DPR:")) return;
       Dpr = int.Parse(content.Substring("Content-DPR: ".Length));
       request.AddHeader(this);

    }

    public override async Task Write(NetworkStream stream)
    {
        await stream.WriteStringAsync($"Content-DPR: {Dpr}");
    }
}