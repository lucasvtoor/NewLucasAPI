using System.Reflection;

namespace API.Requests;

public class EndpointManager: IEndpointManager
{
    public Dictionary<(string,RequestMethods), MethodInfo> Endpoints;
    private ILogger Logger;

    public EndpointManager(ILogger logger)
    {
        Logger = logger;
        BuildEndpoints();
    }


    public void BuildEndpoints()
    {
        Endpoints = Reflection.GetEndpoints();
        foreach (var keyValuePair in Keys())
        {
            Logger.LogInfo($"{keyValuePair.Item2}: http://localhost:{Properties.Port}{keyValuePair.Item1}");
        }
    }

    public MethodInfo GetMethodByPathAndMethod(string path,RequestMethods requestMethod)
    {
        return Endpoints[(path,requestMethod)];
    }

    public IEnumerable<(string, RequestMethods)> Keys()
    {
        return Endpoints.Keys;
    }

    public Dictionary<(string, RequestMethods), MethodInfo> CopyEndpoints()
    {
        return new Dictionary<(string, RequestMethods), MethodInfo>(Endpoints);
    }

    public MethodInfo Get((string, RequestMethods) sr)
    {
        return Endpoints[sr];
    }
}