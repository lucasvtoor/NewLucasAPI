using API.Requests;

namespace API.Headers;

[Header]

public class ConnectionHeader : Header
{
    public string type;
    public override void Read(HttpRequest request, string content)
    {
      throw new NotImplementedException();
    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Connection: {type}");
    }
}