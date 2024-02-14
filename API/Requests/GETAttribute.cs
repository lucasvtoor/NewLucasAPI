namespace API.Requests;

public class GETAttribute : RequestAttribute
{
    public GETAttribute(string uri) : base(uri, RequestMethods.GET)
    {
    }
}