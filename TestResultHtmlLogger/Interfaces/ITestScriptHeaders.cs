using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public interface ITestScriptHeaders
    {
        // Used by Assertion functions
        int SetRunStatus();

        // Headers in test scripts
        int LogHeader(string headerMessage);
        int LogKeyValue(string Key, string value);
        int LogSubHeader(string subHeaderMessage);
        int Log(string message);
    }
}
