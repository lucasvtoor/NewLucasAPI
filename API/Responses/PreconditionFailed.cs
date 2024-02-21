namespace API.Responses;

public class PreconditionFailed : StatusCode
{
    public PreconditionFailed() : base(412, "Precondition Failed")
    {
    }
}