namespace API;

/// <summary>
/// A class for logging messages, implementing the <see cref="ILogger"/> interface.
/// </summary>
public class LucasLogger : ILogger
{
    /// <summary>
    /// The type of logged class.
    /// </summary>
    public Type Type = typeof(LucasLogger);

    /// <inheritdoc cref="ILogger.LogError"/>
    public void LogError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        LogTyped(error);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc cref="ILogger.LogError"/>
    public void LogError(Exception e)
    {
        LogError(e.Message);
    }

    /// <inheritdoc cref="ILogger.LogWarning"/>
    public void LogWarning(string warning)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        LogTimeStamped(LogTyped(warning));
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc cref="ILogger.LogInfo"/>
    public void LogInfo(string info)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        LogTimeStamped(LogTyped(info));
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc cref="ILogger.LogDebug"/>
    public void LogDebug(string debug)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        LogTimeStamped(LogTyped(debug));
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc cref="ILogger.LogTyped"/>
    public string LogTyped(string text)
    {
        return ($"[{Type.Name}]: {text}");
    }
    /// <inheritdoc cref="ILogger.LogTimeStamped"/>
    public void LogTimeStamped(string text)
    {
        Console.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] {text}");
    }
}