using API.Requests;

namespace API.Headers;

[Header]
[DeprecatedHeader]
public class AcceptCharsetHeader : Header
{
    public override void Read(HttpRequest request, string content)
    {
        
    }

    public override async Task Write(HttpResponse response)
    {
       throw new NotImplementedException();
    }
}