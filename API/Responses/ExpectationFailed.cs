namespace API.Responses;

public class ExpectationFailed : StatusCode
{
    public ExpectationFailed() : base(417, "Expectation Failed")
    {
    }
}