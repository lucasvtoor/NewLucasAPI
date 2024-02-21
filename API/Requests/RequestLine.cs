namespace API.Requests;

public class RequestLine: ILoggable
{
    public RequestMethods RequestMethod;
    public string Path;
    public string Version;
    public string Log()
    {
        return $"Path: {Path} V{Version}, Method:{RequestMethod}";
    }
}