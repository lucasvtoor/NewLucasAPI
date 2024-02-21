namespace API.Responses;

public class ImATeapot : StatusCode
{
    public ImATeapot() : base(418, "I'm a Teapot")
    {
    }
}