namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface IScreenshots
    {
	    int LogAllWindows(LogLevel logLevel, string message);
	    int LogScreenshot(LogLevel logLevel, string message);
	    int LogImage(LogLevel logLevel, string imageFile, string message);
    }
}
