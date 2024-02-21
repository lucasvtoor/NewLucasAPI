using System.Net.Sockets;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using API.Headers;

namespace API.Requests;

public class RequestHandler : IRequestHandler
{
    public IEndpointManager EndpointManager;
    public IRequestParser RequestParser;
    public ILogger Logger;

    public RequestHandler(IEndpointManager endpointManager, IRequestParser requestParser, ILogger logger)
    {
        Logger = logger;
        EndpointManager = endpointManager;
        RequestParser = requestParser;
    }

    public async Task HandleAsync(NetworkStream stream, CancellationTokenSource cts)
    {
        var httpRequest = new HttpRequest();
        var streamReader = new StreamReader(stream);
        RequestParser.ReadRequestLine(httpRequest, streamReader);
        RequestParser.ReadRequestHeaders(httpRequest, streamReader);
        if (httpRequest.Headers.ContainsKey(typeof(ContentLengthHeader)))
        {
            Logger.LogDebug("Has error");
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
        Logger.LogDebug(httpRequest.RequestLine.Path);
        var methodInfo = EndpointManager.Get((httpRequest.RequestLine.Path, httpRequest.RequestLine.RequestMethod));
        var controllerInstance = Activator.CreateInstance(methodInfo.DeclaringType);
        var result = methodInfo.Invoke(controllerInstance, null);
        if (methodInfo.ReturnType != typeof(HttpResponse))
        {
            var httpResponse = new HttpResponse();
            httpResponse.Body = result;
            await httpResponse.WriteOutputAsync(stream);
        }

        var res = (HttpResponse)result;
        res.WriteOutputAsync(stream);
    }

    public MethodInfo ParseUri(HttpRequest request)
    {
        var keys = EndpointManager.Keys();
        var endpoints = keys.Where(s => s.Item2 == request.RequestLine.RequestMethod).Select(s => s.Item1);
        var uri = request.RequestLine.Path;
        var templateMatch = GetTemplateMatch(endpoints, uri);
        Logger.LogInfo(templateMatch);

        return EndpointManager.Get((templateMatch, request.RequestLine.RequestMethod));
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

        throw new NotImplementedException(); // No match found
    }
}