namespace API.Responses;

public class URITooLong : StatusCode
{
    public URITooLong() : base(414, "URI Too Long")
    {
    }
}