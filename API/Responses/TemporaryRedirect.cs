namespace API.Responses;

public class TemporaryRedirect : StatusCode
{
    public TemporaryRedirect() : base(307, "Temporary Redirect")
    {
    }
}