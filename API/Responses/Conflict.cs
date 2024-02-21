namespace API.Responses;

public class Conflict : StatusCode
{
    public Conflict() : base(409, "Conflict")
    {
    }
}