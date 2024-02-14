namespace API.Requests;

public class RequestAttribute : Attribute
{
    public string Uri;
    public RequestMethods RequestMethod;
    
    
    protected RequestAttribute(string uri)
    {
        Uri = uri;
    }

    public RequestAttribute(string uri, RequestMethods requestMethod) : this(uri)
    {
        RequestMethod = requestMethod;
    }
}