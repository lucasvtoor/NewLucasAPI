using System.Net.Sockets;
using System.Reflection;
using API.Headers;

namespace API.Requests;

public class RequestHandler : IRequestHandler
{
    public IEndpointManager EndpointManager;
    public RequestParser RequestParser;


    public Task HandleAsync(NetworkStream stream, CancellationTokenSource cts)
    {
        var httpRequest = new HttpRequest();
        var streamReader = new StreamReader(stream);
        RequestParser.ReadRequestLine(httpRequest, streamReader);
        RequestParser.ReadRequestHeaders(httpRequest, streamReader);
        if (((ContentLengthHeader)httpRequest.Headers[typeof(ContentLengthHeader)]).Length > 0)
        {
            var method = ParseUri(httpRequest);
            var bodyTypeParameter = method.GetMethodParameterWithAttribute<BodyAttribute>();
            if (bodyTypeParameter == null)
            {
                //Body Empty Route
            }

            var bodyRequest =
                (HttpRequest<object>)Activator.CreateInstance(
                    typeof(HttpRequest<>).MakeGenericType(bodyTypeParameter.ParameterType));
            // var bodyType = bodyTypeParameter.ParameterType;
            // var body = Activator.CreateInstance(bodyType);
            // var genericHttpRequestType = typeof(HttpRequest<>).MakeGenericType(bodyType);
            // var genericHttpRequest = Activator.CreateInstance(genericHttpRequestType) as HttpRequest;
            // genericHttpRequest.Body = body;
            // httpRequest = genericHttpRequest;
            bodyRequest.Body = RequestParser.ReadRequestBody(bodyTypeParameter.ParameterType, streamReader);
        }

        throw new NotImplementedException();
    }


    public MethodInfo ParseUri(HttpRequest request)
    {
        var keys = EndpointManager.Keys();
        var endpoints = keys.Where(s => s.Item2 == request.RequestLine.RequestMethod).Select(s => s.Item1);
        var uri = request.RequestLine.Path;
        return EndpointManager.Get((GetTemplateMatch(endpoints, uri), request.RequestLine.RequestMethod));
    }

    static string GetTemplateMatch(IEnumerable<string> templates, string uri)
    {
        string[] uriParts = uri.Trim('/').Split('/');

        foreach (var template in templates)
        {
            string[] templateParts = template.Trim('/').Split('/');
            if (templateParts.Length == uriParts.Length)
            {
                var match = true;
                for (int i = 0; i < templateParts.Length; i++)
                {
                    if (!templateParts[i].StartsWith("{") || !templateParts[i].EndsWith("}"))
                    {
                        if (templateParts[i] != uriParts[i])
                        {
                            match = false;
                            break;
                        }
                    }
                }

                if (match)
                {
                    return template;
                }
            }
        }

        return null; // No match found
    }
}