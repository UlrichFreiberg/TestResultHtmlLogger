using System;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : IPerformanceManagement
    {
        /// <summary>
        /// Used for indicating performance issues - if not logging, then something takes a long time:-)
        /// </summary>
        DateTime _timeOfLastMessage;

        public void CheckForPerformanceAlert()
        {
            var elapsedTime = DateTime.Now - _timeOfLastMessage;
            _timeOfLastMessage = DateTime.Now;

            if (elapsedTime.Seconds > Configuration.AlertLongInterval)
            {
                LogPerformanceAlert(elapsedTime.TotalSeconds);
            }
        }

        // =============================================================
        //
        // how long time since last - any performance issues?
        //
        // =============================================================
        public int LogPerformanceAlert(double elapsedTime)
        {
            String performanceAlert = String.Format("PerfAlert: {0} seconds since last logEntry", elapsedTime);

            return LogWarning(performanceAlert);
        }
    }
}
