using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace API.Requests;

public static class StreamExtensions
{
    public static async Task WriteStringAsync(this NetworkStream stream,string content)
    {
        byte[] buffer = Encoding.UTF8.GetBytes($"{content}\n");


        if (stream.CanWrite)
        {
            await stream.WriteAsync(buffer, 0, buffer.Length);
            // Don't forget to flush the stream if buffering is enabled
            stream.Flush();
        }
    }

    public static async Task WriteObjectAsync(this NetworkStream stream, object content)
    {
        await stream.WriteStringAsync(JsonSerializer.Serialize(content));
    }
}