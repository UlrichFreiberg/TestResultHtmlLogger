using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
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
