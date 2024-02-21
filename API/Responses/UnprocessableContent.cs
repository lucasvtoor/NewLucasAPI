namespace API.Responses;

public class UnprocessableContent : StatusCode
{
    public UnprocessableContent() : base(422, "Unprocessable Content")
    {
    }
}