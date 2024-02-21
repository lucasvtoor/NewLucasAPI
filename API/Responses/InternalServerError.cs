namespace API.Responses;

public class InternalServerError : StatusCode
{
    public InternalServerError() : base(500, "Internal Server Error")
    {
    }
}