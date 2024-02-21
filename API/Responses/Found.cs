namespace API.Responses;

public class Found : StatusCode
{
    public Found() : base(302, "Found")
    {
    }
}