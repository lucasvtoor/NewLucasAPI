namespace API.Requests;

public interface IRequestParser
{
    void ReadRequestLine(HttpRequest request, StreamReader stream);
    void ReadRequestHeaders(HttpRequest request, StreamReader stream);
    object ReadRequestBody(Type type, StreamReader stream);

}