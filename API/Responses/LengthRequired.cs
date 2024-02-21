namespace API.Responses;

public class LengthRequired : StatusCode
{
    public LengthRequired() : base(411, "Length Required")
    {
    }
}