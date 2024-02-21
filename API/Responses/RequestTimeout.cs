namespace API.Responses;

public class RequestTimeout : StatusCode
{
    public RequestTimeout() : base(408, "Request Timeout")
    {
    }
}