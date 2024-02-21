using API.Requests;

namespace API.Headers;

[Header]

public class AcceptClientHintHeader : Header
{
    public string[] ClientHints;
    public override void Read(HttpRequest request, string content)
    {   
        if(!content.Contains("Accept-CH: ")) return;
        ClientHints = (from s in content.Substring("Accept-CH: ".Length).Split(',') select s).ToArray();
        request.AddHeader(this);
    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Accept-CH: {String.Join(", ", ClientHints)}");
        
    }
}