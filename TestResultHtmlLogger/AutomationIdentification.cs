using System;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public sealed partial class TestResultHtmlLogger : IAutomationIdentification
    {
        // =============================================================
        //
        // dump an AutomationIdentification object
        //
        // =============================================================
        int IAutomationIdentification.LogAutomationIdObject(LogLevel logLevel, object automationIdObj, string message)
        {
            throw new NotImplementedException();
        }
    }
}
