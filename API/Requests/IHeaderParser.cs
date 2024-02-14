namespace API.Requests;

public interface IHeaderParser
{
    IEnumerable<Type> GetAllHeaders();
    public void ReadHeader(HttpRequest request,string content);
}