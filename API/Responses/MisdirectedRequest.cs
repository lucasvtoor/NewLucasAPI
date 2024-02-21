namespace API.Responses;

public class MisdirectedRequest : StatusCode
{
    public MisdirectedRequest() : base(421, "Misdirected Request")
    {
    }
}