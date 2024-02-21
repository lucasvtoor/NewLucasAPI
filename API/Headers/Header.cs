using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

public abstract class Header : IReadable,IWritable
{
    public abstract Task Write(NetworkStream stream);
    public abstract void Read(HttpRequest request, string content);
}

