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
            //<div class="line logheader">Teststatus</div>
            //<div onclick="sa('m3535')" id="m3535" class="line fail">
            //    <div class="el time">17:13:04</div>
            //    <div class="el level">fail</div>
            //    <div class="el pad"> ·  · </div>
            //    <div class="el msg">TITEL<span id="runstatus">gennemført med fejl!<br></div>
            //</div>        
        }
    }
}
