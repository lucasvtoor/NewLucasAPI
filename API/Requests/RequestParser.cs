using System.Text.Json;


namespace API.Requests;

public class RequestParser: IRequestParser
{
    private IHeaderParser HeaderParser;

    public RequestParser(IHeaderParser headerParser)
    {
        HeaderParser = headerParser;
    }

    public RequestLine ReadRequestLine(HttpRequest request,StreamReader stream)
    {
        var requestLine = new RequestLine();
        var content = _readRequestLine(stream);
        var parts = content.Split(' ');
        requestLine.RequestMethod = Enum.Parse<RequestMethods>(parts[0]);
        requestLine.Path = parts[1];
        requestLine.Version = parts[2];
        
        
        return requestLine;
    }
    private string _readRequestLine(StreamReader stream)
    {
       return stream.ReadLine();
    }

    public void ReadRequestHeaders(HttpRequest request,StreamReader stream)
    {
        var headerLines = _readRequestHeaders(stream);
        foreach (var headerLine in headerLines)
        {
            HeaderParser.ReadHeader(request,headerLine);
        }
    }
    private string[] _readRequestHeaders(StreamReader stream)
    {
        var lines = new List<string>();
        while (true)
        {
            string line = stream.ReadLine();
            if (string.IsNullOrEmpty(line)) break;
            lines.Add(line);
        }
    
        return lines.ToArray();
    }

    public object ReadRequestBody(Type type, StreamReader stream)
    {
       return JsonSerializer.Deserialize(_readRequestBody(stream),type);
    }
    private string _readRequestBody(StreamReader stream)
    {
        throw new NotImplementedException();
    }
}