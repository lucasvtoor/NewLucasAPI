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