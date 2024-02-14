using API.Requests;

namespace API.Headers;

[Header]

public class DownlinkHeader : Header
{
    public override void Read(HttpRequest request, string content)
    {
      throw new NotImplementedException();
    }

    public override async Task Write(HttpResponse response)
    {
       throw new NotImplementedException();
    }
}