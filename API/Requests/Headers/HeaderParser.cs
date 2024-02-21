using System.Reflection;
using API.Headers;

namespace API.Requests;

public class HeaderParser : IHeaderParser
{
    public List<Header> Headers;
    public ILogger Logger;
    
    public IEnumerable<Type> GetAllHeaders()
    {
        return Reflection.GetDerivedTypesFor(typeof(Header)).Where(s => s.GetCustomAttribute<DeprecatedHeaderAttribute>() == null);
    }

    public HeaderParser(ILogger logger)
    {
        Logger = logger;
        Headers = GetAllHeaders()
            .Select(headerType => (Header)Activator.CreateInstance(headerType))
            .ToList();
    }

    public void ReadHeader(HttpRequest request, string content)
    {
        Logger.LogInfo(content);
        foreach (var header in Headers)
        {
            header.Read(request,content);
        }
    }
}