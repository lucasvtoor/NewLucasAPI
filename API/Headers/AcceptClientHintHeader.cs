using API.Requests;

namespace API.Headers;

[Header]

public class AcceptClientHintHeader : Header
{
    public string[] ClientHints;
    public override void Read(HttpRequest request, string content)
    {
       if(false || false){}
    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Accept-CH: {String.Join(", ", ClientHints)}");
        
    }
}