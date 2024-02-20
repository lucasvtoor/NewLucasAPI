using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using API.Requests;

namespace API;

public static class DependencyInvoker
{
    public static T Invoke<T>(this Type type, DependencyInjector injector)
    {
        var constructor = type.GetConstructors().OrderBy(c => c.GetParameters().Length).FirstOrDefault();

        if (constructor != null)
        {
            var objects = constructor.GetParameters()
                .Select(parameterInfo => injector.GetSingleton(parameterInfo.ParameterType))
                .ToArray();
            return (T)constructor.Invoke(objects);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}

public class DependencyInjector
{
    private Dictionary<Type, object> Singletons = new();
    private Dictionary<Type, object> Scoped = new();
    private Dictionary<Type, object> Transient = new();

    public object GetSingleton(Type t)
    {
        return Singletons[t];
    }
    public object GetTransient(Type t)
    {
        return Transient[t];
    }
    public object GetScoped(Type t)
    {
        return Scoped[t];
    }
    public T GetSingleton<T>()
    {
        return (T)Singletons[typeof(T)];
    }
    public T GetTransient<T>()
    {
        return (T)Transient[typeof(T)];
    }
    public T GetScoped<T>()
    {
        return (T)Scoped[typeof(T)];
    }

    public void AddTransient<T, TO>()
    {
        Transient[typeof(T)] = typeof(TO).Invoke<TO>(this) ?? throw new InvalidOperationException();
    }

    public void AddScoped<T, TO>()
    {
        Scoped[typeof(T)] = typeof(TO).Invoke<TO>(this) ?? throw new InvalidOperationException();
    }

    public void AddSingleton<T, TO>()
    {
        Singletons[typeof(T)] = typeof(TO).Invoke<TO>(this) ?? throw new InvalidOperationException();
    }

    public DependencyInjector()
    {
        AddSingleton<IHeaderParser, HeaderParser>();
        AddSingleton<IRequestHandler, RequestHandler>();
        AddSingleton<IEndpointManager, EndpointManager>();
        AddSingleton<IRequestParser, RequestParser>();
    }
}