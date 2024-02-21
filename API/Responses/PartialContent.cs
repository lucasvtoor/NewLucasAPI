namespace API.Responses;

public class PartialContent : StatusCode
{
    public PartialContent() : base(206, "Partial Content")
    {
    }
}