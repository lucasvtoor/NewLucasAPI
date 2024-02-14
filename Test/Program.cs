using API.Requests;

public class Test
{
    [GET("/controller/{value}/requests")]
    public string Jongen(int value)
    {
        return "Yo";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
    }
}