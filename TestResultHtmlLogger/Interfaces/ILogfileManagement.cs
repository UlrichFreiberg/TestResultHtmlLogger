using System;

namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
{
    public interface ILogfileManagement
    {
        // Have we logged a Error or Fail? 
	    int ErrorOrFail();

	    int CloseLogFile();
	    int ArchiveThisLogFile();
    }
}
