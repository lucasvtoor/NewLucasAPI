namespace API.Headers;

public static class HeaderExtensions
{
    public static string QFactorWeight(this float f)
    {
        return f == 0f ? "," : $";q={f:0.0},";
    }
}