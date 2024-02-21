using System.Net.Sockets;

namespace API.Requests;

public class FavIconResponse: HttpResponse
{
    public byte[] Image;
    
    public new async Task WriteOutputAsync(NetworkStream stream)
    {
        StatusCode.Write(stream);
        foreach (var header in Headers)
        {
            await header.Write(stream);
        }

        await stream.WriteStringAsync("");
        if (Body != null)
        {
            await stream.WriteAsync(Image);
        }
    }
}