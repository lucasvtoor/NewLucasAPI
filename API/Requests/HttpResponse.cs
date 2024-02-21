using System.Net.Sockets;
using API.Headers;
using API.Responses;

namespace API.Requests;

public class HttpResponse
{
    public Header[] Headers;
    public object? Body;
    public StatusCode StatusCode;
    public async Task WriteOutputAsync(NetworkStream stream)
    {
        await StatusCode.Write(stream);
        foreach (var header in Headers)
        {
            await header.Write(stream);
        }

        await stream.WriteStringAsync("");
        if (Body != null)
        {
            await stream.WriteObjectAsync(Body);
        }
    }
}