namespace API.Responses;

public class NotModified : StatusCode
{
    public NotModified() : base(304, "Not Modified")
    {
    }
}