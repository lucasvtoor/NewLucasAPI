namespace API.Requests;

public class ControllerAttribute : Attribute
{
    public string Path;

    public ControllerAttribute(string path)
    {
        Path = path;
    }
}