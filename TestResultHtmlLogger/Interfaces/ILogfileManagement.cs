using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface ILogfileManagement
    {
        int Init(string logFileName);

        // Have we logged a Error or Fail? 
	    int ErrorOrFail();

	    int CloseLogFile();
	    int ArchiveThisLogFile();
    }
}
