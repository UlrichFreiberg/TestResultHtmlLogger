using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface IAutomationIdentification
    {
        // dump an AutomationIdentification object
        int LogAutomationIdObject(LogLevel logLevel, object automationIdObj, string message);
    }
}
