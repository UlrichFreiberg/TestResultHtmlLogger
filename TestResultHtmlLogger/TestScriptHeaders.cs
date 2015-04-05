// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptHeaders.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Stf.Utilities.Interfaces;

namespace Stf.Utilities
{
    using Utilities.Interfaces;

    /// <summary>
    /// The test result html logger.
    /// </summary>
    public partial class TestResultHtmlLogger : ITestScriptHeaders
    {
        /// <summary>
        /// Gets or sets the name of Current Test
        /// </summary>
        public string TestName { get; set; }

        // =============================================================
        // Used by Assertion functions
        // =============================================================

        /// <summary>
        /// The set run status.
        /// </summary>
        /// <param name="runStatusAllPassed">
        /// The run status all passed.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int SetRunStatus(bool runStatusAllPassed)
        {
            int retVal;

            LogHeader("Test status");
            if (runStatusAllPassed)
            {
                retVal = LogPass("Test status", "Test Completed with errors");
            }
            else
            {
                retVal = LogFail("Test status", "Test Completed with errors");
            }

            return retVal;
        }

        /// <summary>
        /// The set run status.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int SetRunStatus()
        {
            // Figure out if there is a failing test or not, and then call 
            return SetRunStatus(true);
        }
    }
}
