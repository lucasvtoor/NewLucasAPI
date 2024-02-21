namespace API.Responses;

public class MethodNotAllowed : StatusCode
{
    public MethodNotAllowed() : base(405, "Method Not Allowed")
    {
    }
}