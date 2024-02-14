using API.Headers;

namespace API.Requests;

public class Request
{
    public RequestLine RequestLine;
    public Header[] Headers;
    public RequestBody? RequestBody;
}