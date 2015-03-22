using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : IPerformanceManagement
    {
        /// <summary>
        /// Used for indicating performance issues - if not logging, then something takes a long time:-)
        /// </summary>
        DateTime TimeOfLastMessage;

        public void CheckForPerformanceAlert()
        {
            var ElapsedTime = DateTime.Now - TimeOfLastMessage;

            if (ElapsedTime.Seconds > Configuration.AlertLongInterval)
            {
                LogPerformanceAlert(ElapsedTime.TotalSeconds);
            }
        }

        // =============================================================
        //
        // how long time since last - any performance issues?
        //
        // =============================================================
        public int LogPerformanceAlert(double elapsedTime)
        {
            String PerformanceAlert = String.Format("PerfAlert: {0} seconds since last logEntry", elapsedTime);

            return LogWarning(PerformanceAlert);
        }
    }
}
