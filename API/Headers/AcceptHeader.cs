using System.Net.Sockets;
using System.Text;
using API.Headers.Structs;
using API.Requests;

namespace API.Headers;

[Header]
public class AcceptHeader : Header
{
    private Accept[] accepts;


    public override void Read( HttpRequest request,string content)
    {
        return;
        if(!content.Contains("Accept: ")) return;
        accepts = Accept.ParseAcceptHeader((content.Substring("Accept: ".Length,
            content.Length - "Accept: ".Length))).ToArray();
        
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
        var sb = new StringBuilder();
        sb.Append("Accept: ");
        foreach (var accept in accepts)
        {
            sb.Append(accept);
        }

        sb.Remove(sb.Length - 2, sb.Length);
        stream.WriteStringAsync(
            sb.ToString());
    }
}