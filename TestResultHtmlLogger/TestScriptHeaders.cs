using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ITestScriptHeaders
    {
        /// <summary>
        /// Name of Current Test
        /// </summary>
        public string TestName { get; set; }

        // =============================================================
        //
        // Used by Assertion functions
        //
        // =============================================================
        public int SetRunStatus(Boolean RunStatusAllPassed)
        {
            int retVal;

            LogHeader("Teststatus");
            if (RunStatusAllPassed)
            {
                retVal = LogPass("Teststatus", "Test Completed with errors");
            }
            else
            {
                retVal = LogFail("Teststatus", "Test Completed with errors");
            }

            return retVal;
        }

        public int SetRunStatus()
        {
            // Figure out if there is a failing test or not, and then call 
            return SetRunStatus(true);
        }
    }
}
