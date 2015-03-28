namespace Stf.Utilities.TestResultHtmlLogger.Interfaces
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
