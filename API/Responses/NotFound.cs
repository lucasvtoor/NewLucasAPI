namespace API.Responses;

public class NotFound : StatusCode
{
    public NotFound() : base(404, "Not Found")
    {
    }
}