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
        int ITestScriptHeaders.SetRunStatus()
        {
            throw new NotImplementedException();
        }

        // =============================================================
        //
        // Headers in test scripts
        //
        // =============================================================
        int ITestScriptHeaders.LogHeader(string headerMessage)
        {
            throw new NotImplementedException();
        }

        int ITestScriptHeaders.LogKeyValue(string Key, string value)
        {
            throw new NotImplementedException();
        }

        int ITestScriptHeaders.LogSubHeader(string subHeaderMessage)
        {
            throw new NotImplementedException();
        }

        int ITestScriptHeaders.Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
