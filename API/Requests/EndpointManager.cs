using System.Reflection;

namespace API.Requests;

public class EndpointManager: IEndpointManager
{
    public Dictionary<(string,RequestMethods), MethodInfo> endpoints;


    public void BuildEndpoints()
    {
        endpoints = Reflection.GetEndpoints();
    }

    public MethodInfo GetMethodByPathAndMethod(string path,RequestMethods requestMethod)
    {
        return endpoints[(path,requestMethod)];
    }

    public IEnumerable<(string, RequestMethods)> Keys()
    {
        return endpoints.Keys;
    }

    public Dictionary<(string, RequestMethods), MethodInfo> CopyEndpoints()
    {
        return new Dictionary<(string, RequestMethods), MethodInfo>(endpoints);
    }

    public MethodInfo Get((string, RequestMethods) sr)
    {
        return endpoints[sr];
    }
}