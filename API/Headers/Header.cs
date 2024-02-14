using API.Requests;

namespace API.Headers;

public abstract class Header : IReadable,IWritable
{
    public abstract Task Write(HttpResponse response);
    public abstract void Read(HttpRequest request, string content);
}

