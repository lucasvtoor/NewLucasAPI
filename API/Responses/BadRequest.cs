namespace API.Responses;

public class BadRequest : StatusCode
{
    public BadRequest() : base(400, "Bad Request")
    {
    }
}