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
    }
}
