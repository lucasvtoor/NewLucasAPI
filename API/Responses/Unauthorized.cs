namespace API.Responses;

public class Unauthorized : StatusCode
{
    public Unauthorized() : base(401, "Unauthorized")
    {
    }
}