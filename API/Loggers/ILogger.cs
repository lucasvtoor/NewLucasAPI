namespace API;

public interface ILogger
{
    /// <summary>
    /// Logs a logo.
    /// </summary>
    public void LogLogo()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@"                      ++++++                      
                    ++++++++++                    
                ++++++++++++++++++                
            ++++++++++++++++++++++++++            
          ++++++++++++++++++++++++++++++          
      ++++++++++++++++++++++++++++++++++++++      
  ++++++++++++          ++++++++++++++++++++++++  
++++++++++++++          ++++++++++++++++++++++++%%
++++++++++++++          ++++++++++++++++++++++%%%%
++++++++++++++          ++++++++++++++++++%%%%%%%%
++++++++++++++          ++++++++++++++%%%%%%%%%%%%
++++++++++++++          ++++++++++++%%%%%%%%%%%%%%
++++++++++++++          ++++++++%%%%%%  %%  %%%%%%
++++++++++++++          ++++%%%%%%%%          %%%%
++++++++++++++          ##%%%%%%%%%%%%  %%  %%%%%%
++++++++++++++          ####%%%%%%%%          %%%%
++++++++++++++          ########%%%%%%  %%  %%%%%%
++++++++++++++          ############%%%%%%%%%%%%%%
++++++++++++##                        %%%%%%%%%%%%
++++++++######                        ####%%%%%%%%
++++##########                        ########%%%%
++############                        ucas######%%
  ##############################################  
      ######################################      
          ##############################          
            ##########################            
                ##################                
                    ##########                    
                      ######       ");
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="error">The error message to log.</param>
    void LogError(string error);
    /// <summary>
    /// Logs an exception.
    /// </summary>
    /// <param name="e">The exception to log.</param>
    void LogError(Exception e);
    /// Logs a warning message.
    /// </summary>
    /// <param name="warning">The warning message to log.</param>
    void LogWarning(string warning);
    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="info">The informational message to log.</param>
    void LogInfo(string info);
    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="debug">The debug message to log.</param>
    void LogDebug(string debug);
    /// <summary>
    /// Logs a typed message.
    /// </summary>
    /// <param name="text">The text to log.</param>
    /// <returns>The logged text.</returns>
    string LogTyped(string text);
    
    /// <summary>
    /// Logs a timestamped message.
    /// </summary>
    /// <param name="text">The text to log.</param>
    void LogTimeStamped(string text);
}