namespace API.Responses;

public class PermanentRedirect : StatusCode
{
    public PermanentRedirect() : base(308, "Permanent Redirect")
    {
    }
}