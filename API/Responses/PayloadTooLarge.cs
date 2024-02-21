namespace API.Responses;

public class PayloadTooLarge : StatusCode
{
    public PayloadTooLarge() : base(413, "Payload Too Large")
    {
    }
}