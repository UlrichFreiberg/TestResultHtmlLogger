using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface IScreenshots
    {
	    int LogAllWindows(LogLevel logLevel, string message);
	    int LogScreenshot(LogLevel logLevel, string message);
	    int LogImage(LogLevel logLevel, string imageFile, string message);
    }
}
