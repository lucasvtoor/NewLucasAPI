using System.Reflection;

namespace API.Requests;

public interface IEndpointManager
{
    public MethodInfo GetMethodByPathAndMethod(string path,RequestMethods requestMethod);
    public IEnumerable<(string,RequestMethods)> Keys();
    public MethodInfo Get((string, RequestMethods) sr);
}