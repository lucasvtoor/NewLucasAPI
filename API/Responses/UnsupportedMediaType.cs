namespace API.Responses;

public class UnsupportedMediaType : StatusCode
{
    public UnsupportedMediaType() : base(415, "Unsupported Media Type")
    {
    }
}