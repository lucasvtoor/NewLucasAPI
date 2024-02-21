namespace API.Responses;

public class RangeNotSatisfiable : StatusCode
{
    public RangeNotSatisfiable() : base(416, "Range Not Satisfiable")
    {
    }
}