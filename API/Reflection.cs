using System.Reflection;
using API.Requests;

namespace API;

public static class Reflection
{
    public static IEnumerable<Type> WithAttribute<T>(this Type[] types) where T : Attribute
    {
        return types.Where(t => t.GetCustomAttribute<T>() != null);
    }

    public static IEnumerable<Type> WithoutAttribute<T>(this Type[] types) where T : Attribute
    {
        return types.Where(t => t.GetCustomAttribute<T>() == null);
    }


    public static IEnumerable<Type> GetDerivedTypesFor(Type baseType)
    {
        var assembly = Assembly.GetExecutingAssembly();

        return assembly.GetTypes()
            .Where(type => type != baseType
                           && baseType.IsAssignableFrom(type));
    }

    public static IEnumerable<Type> GetDerivedTypesFor<T>()
    {
        return GetDerivedTypesFor(typeof(T));
    }

    public static ParameterInfo? GetMethodParameterWithAttribute<T>(this MethodInfo methodInfo) where T : Attribute
    {
        return methodInfo.GetParameters().Where(p => p.GetCustomAttribute<T>() != null).FirstOrDefault();
    }


    public static Dictionary<(string, RequestMethods), MethodInfo> GetEndpoints()
    {
        var dict = Assembly.GetEntryAssembly()
            .GetTypes()
            .WithoutAttribute<ControllerAttribute>()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttribute<RequestAttribute>(true) != null)
            .ToDictionary(m => (m.GetCustomAttribute<RequestAttribute>(true).Uri, m.GetCustomAttribute<RequestAttribute>(true).RequestMethod));
        var controllers = Assembly.GetExecutingAssembly()
            .GetTypes()
            .WithAttribute<ControllerAttribute>();
        foreach (var controller in controllers)
        {
            var attr = controller.GetCustomAttribute<ControllerAttribute>();
            var endpoints = controller.GetMethods()
                .Where(m => m.GetCustomAttribute<RequestAttribute>(true) != null);


            foreach (var endpoint in endpoints)
            {
                var requestAttr = endpoint.GetCustomAttribute<RequestAttribute>();
                dict.Add((attr.Path + requestAttr.Uri, requestAttr.RequestMethod), endpoint);
            }
        }

        return dict;
    }
}