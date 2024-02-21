using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]
[DeprecatedHeader]
public class AcceptClientHintLifetimeHeader : Header

{
    public override void Read(HttpRequest request, string content)
    {
      throw new NotImplementedException();
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}