using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface IPerformanceManagement
    {
        // how long time since last - any performance issues?
	    // int CheckTime;
	    int LogPerformanceAlert(int elapsedTime);
    }
}
