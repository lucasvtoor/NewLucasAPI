namespace API.Responses;

public class NoContent : StatusCode
{
    public NoContent() : base(204, "No Content")
    {
    }
}