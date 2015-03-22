using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface IPerformanceManagement
    {
        /// <summary>
        /// Check how long time since last - any performance issues?
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <returns></returns>
	    int LogPerformanceAlert(double elapsedTime);
    }
}
