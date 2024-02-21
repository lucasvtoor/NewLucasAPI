namespace API.Responses;

public class PaymentRequired : StatusCode
{
    public PaymentRequired() : base(402, "Payment Required")
    {
    }
}