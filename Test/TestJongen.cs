using API.Headers;
using API.Requests;
using API.Responses;

public class TestJongen
{
    [GET("/controller/{value}/requests")]
    public string Jongen(int value)
    {
        return "Yo";
    }

    [GET("/favicon.ico")]
    public HttpResponse FavIcon()
    {
        var faviconBytes =
            File.ReadAllBytes("../../../favicon-32x32.png");
        return new FavIconResponse
        {
            StatusCode = new Ok(),
            Headers = new Header[]
            {
                new ContentTypeHeader { type = "image/x-icon" },
                new ContentLengthHeader { Length = faviconBytes.Length }
            },
            Image = faviconBytes
        };
    }


    [GET("/jochert")]
    public HttpResponse Test()
    {
        var res = new HttpResponse();
        res.StatusCode = new Ok();
        res.Headers =
        [
            new ContentTypeHeader
            {
                type = "text/plain"
            }
        ];
        res.Body = GetTest();
        return res;
    }

    [GET("/test")]
    public string GetTest()
    {
        Console.WriteLine("Werkt");
        return "CheckDit";
    }
}