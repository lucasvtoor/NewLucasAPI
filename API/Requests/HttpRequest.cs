using API.Headers;

namespace API.Requests;

public class HttpRequest
{
    public RequestLine RequestLine;
    public Dictionary<Type,Header> Headers = new();
    public Dictionary<string, object> QueryParameters = new();

    public void AddHeader<T>(T t) where T : Header
    {
        Headers.Add(typeof(T), t);
    }

    public void AddQueryParameter(string name, object value)
    {
        QueryParameters.Add(name, value);
    }
    
}

public class HttpRequest<T> : HttpRequest
{
    public T Body { get; set; }
}