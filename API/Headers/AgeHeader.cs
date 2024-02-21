using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]
public class AgeHeader : Header
{
    private int age;

    public override void Read(HttpRequest request, string content)
    {
        if (!content.Contains("Age:")) return;
        age = int.Parse(content.Substring(5, content.Length - 5));
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
        await stream.WriteStringAsync($"Age: {age}");
    }
}