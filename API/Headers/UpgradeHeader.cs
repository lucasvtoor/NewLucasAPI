using API.Requests;

namespace API.Headers;

[Header]

public class UpgradeHeader : Header
{
    public string type { get; set; }
    public override void Read(HttpRequest request, string content)
    {
       throw new NotImplementedException();
    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Upgrade: {type}");
    }
}