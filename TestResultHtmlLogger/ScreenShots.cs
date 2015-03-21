using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : IScreenshots
    {
        // =============================================================
        //
        // scrrenshots - used by testscripts
        //
        // =============================================================
        int IScreenshots.LogAllWindows(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        int IScreenshots.LogScreenshot(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        int IScreenshots.LogImage(LogLevel logLevel, string imageFile, string message)
        {
            throw new NotImplementedException();
        }
    }
}
