namespace API.Responses;

public class Forbidden : StatusCode
{
    public Forbidden() : base(403, "Forbidden")
    {
    }
}