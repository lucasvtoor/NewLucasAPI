namespace API.Responses;

public class Ok : StatusCode
{
    public Ok() : base(200, "OK")
    {
    }
}