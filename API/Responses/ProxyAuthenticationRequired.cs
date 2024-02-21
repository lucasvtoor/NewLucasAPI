namespace API.Responses;

public class ProxyAuthenticationRequired : StatusCode
{
    public ProxyAuthenticationRequired() : base(407, "Proxy Authentication Required")
    {
    }
}