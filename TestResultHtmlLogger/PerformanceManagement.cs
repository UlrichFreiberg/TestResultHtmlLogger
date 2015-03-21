using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : IPerformanceManagement
    {
        // =============================================================
        //
        // how long time since last - any performance issues?
        //
        // =============================================================
        int IPerformanceManagement.LogPerformanceAlert(int elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}
