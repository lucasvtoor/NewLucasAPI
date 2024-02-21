namespace API.Requests;

public class POSTAttribute : RequestAttribute
{
    public Type? BodyType;
    public POSTAttribute(string uri) : base(uri, RequestMethods.POST)
    {
    }

    public POSTAttribute(string uri, Type bodyType) : base(uri, RequestMethods.POST)
    {
        BodyType = bodyType;
    }
}