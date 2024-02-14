using API.Headers;

namespace API.Requests;

public class HeaderParser : IHeaderParser
{
    public List<Header> Headers;
    public IEnumerable<Type> GetAllHeaders()
    {
        return Reflection.GetDerivedTypesFor(typeof(Header));
    }

    public HeaderParser()
    {
        Headers = GetAllHeaders()
            .Select(headerType => (Header)Activator.CreateInstance(headerType))
            .ToList();
    }

    public void ReadHeader(HttpRequest request, string content)
    {
        foreach (var header in Headers)
        {
            header.Read(request,content);
        }
    }
}