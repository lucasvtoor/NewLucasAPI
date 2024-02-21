using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

public class ECTHeader : Header
{
    public ECT Ect;
    public override void Read(HttpRequest request, string content)
    {
        if(!content.StartsWith("ECT: ")) return;
        Ect = content.Substring("ECT: ".Length) switch
        {
            "slow-2g" => ECT.Slow2G,
            "2g" => ECT.TwoG,
            "3g" => ECT.ThreeG,
            "4g" => ECT.FourG,
            _ => Ect
        };
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
       throw new NotImplementedException();
    }
}