using API.Requests;

namespace API.Headers;

[Header]

public class AccessControlExposeHeadersHeader : Header
{
    public override void Read(HttpRequest request, string content)
    {
        if(!content.Contains("yuh")) return;
        //ClientHints = (from s in content.Substring("Accept-Language: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(HttpResponse response)
    {
       throw new NotImplementedException();
    }
}