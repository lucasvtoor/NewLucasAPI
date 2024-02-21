namespace API.Responses;

public class Gone : StatusCode
{
    public Gone() : base(410, "Gone")
    {
    }
}