using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ITestResultHtmlLogger
    {
        // =============================================================
        //
        // Functions in models/adapters
        //
        // =============================================================
        int ITestResultHtmlLogger.LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName, string[] args, object[] argValues)
        {
            throw new NotImplementedException();
        }

        int ITestResultHtmlLogger.LogFunctionExit(LogLevel logLevel, string functionName, object returnValue)
        {
            throw new NotImplementedException();
        }

        // =============================================================
        //
        // Properties in models/adapters
        //
        // =============================================================
        int ITestResultHtmlLogger.LogGet(LogLevel logLevel, string callingProperty, object getValue)
        {
            throw new NotImplementedException();
        }

        int ITestResultHtmlLogger.LogSet(LogLevel logLevel, string callingProperty, object setValue)
        {
            throw new NotImplementedException();
        }
    }
}
