using API.Requests;

namespace API.Headers;

[Header]

public class SourceMapHeader : Header
{
    public string url;
    public override void Read(HttpRequest request, string content)
    {
    }

    public override async Task Write(HttpResponse response)
    {
        response.WriteOutputAsync($"SourceMap: {url}");
    }
}