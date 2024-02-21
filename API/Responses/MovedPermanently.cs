namespace API.Responses;

public class MovedPermanently : StatusCode
{
    public MovedPermanently() : base(301, "Moved Permanently")
    {
    }
}