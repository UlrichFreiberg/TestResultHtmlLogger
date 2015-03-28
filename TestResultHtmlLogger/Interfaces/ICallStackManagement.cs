namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface ITestResultHtmlLogger
    {
        // Functions in models/adapters
        int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName, string[] args, object[] argValues);
        int LogFunctionExit(LogLevel logLevel, string functionName, object returnValue);

        // Properties in models/adapters
        int LogGet(LogLevel logLevel, string callingProperty, object getValue);
        int LogSet(LogLevel logLevel, string callingProperty, object setValue);
    }
}
