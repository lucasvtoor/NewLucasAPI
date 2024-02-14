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
        if(!content.Contains("Accept: ")) return;
        accepts = (from s in content.Substring("Accept: ".Length).Split(',') select (Accept)s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(HttpResponse response)
    {
        var sb = new StringBuilder();
        sb.Append("Accept: ");
        foreach (var accept in accepts)
        {
            sb.Append(accept);
        }

        sb.Remove(sb.Length - 2, sb.Length);
        response.WriteOutputAsync(
            sb.ToString());
    }
}