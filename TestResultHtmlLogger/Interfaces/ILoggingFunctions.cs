namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface ILoggingFunctions
    {
        // normal logging functions - testscripts/models/adapters
        int LogError(string message);
        int Error(string message);
        int LogWarning(string message);
        int Warning(string message);
        int LogInfo(string message);
        int Info(string message);
        int LogDebug(string message);
        int Debug(string message);

        // normal logging functions - models and adapters
        int LogTrace(string message);
        int Trace(string message);
        int LogInternal(string message);
        int Internal(string message);

        // used solely by Assert functions
        int LogPass(string testStepName, string message);
        int Pass(string testStepName, string message);
        int LogFail(string testStepName, string message);
        int Fail(string testStepName, string message);

        int LogKeyValue(string key, string value, string message);

        // Headers in test scripts
        int LogHeader(string headerMessage);
        int LogSubHeader(string subHeaderMessage);
    }
}
