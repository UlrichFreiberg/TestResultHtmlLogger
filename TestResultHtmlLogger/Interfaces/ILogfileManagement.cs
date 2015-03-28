using System;

namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface ILogfileManagement
    {
        Boolean Init(string logFileName);

        // Have we logged a Error or Fail? 
	    int ErrorOrFail();

	    int CloseLogFile();
	    int ArchiveThisLogFile();
    }
}
