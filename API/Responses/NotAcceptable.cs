namespace API.Responses;

public class NotAcceptable : StatusCode
{
    public NotAcceptable() : base(406, "Not Acceptable")
    {
    }
}