namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface IAutomationIdentification
    {
        // dump an AutomationIdentification object
        int LogAutomationIdObject(LogLevel logLevel, object automationIdObj, string message);
    }
}
