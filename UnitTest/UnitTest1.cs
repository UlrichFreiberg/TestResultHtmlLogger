// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities.StfAssert;
    using Stf.Utilities.TestResultHtmlLogger;
    using Stf.Utilities.TestResultHtmlLogger.Interfaces;

    /// <summary>
    /// The unit test 1.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// The test method_ init.
        /// </summary>
        [TestMethod]
        public void TestMethod_Init()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger.html" };
            myLogger.CloseLogFile();
        }

        /// <summary>
        /// All log levels
        /// </summary>
        [TestMethod]
        public void TestMethod_AllLogType()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger.html", 
                LogLevel = LogLevel.Internal
            };

            myLogger.Info("For Some Reason this is never shown - seems like the first line is ignored");
            myLogger.LogError("LogError");
            myLogger.Error("Error");
            myLogger.LogWarning("LogWarning");
            myLogger.Warning("Warning");
            myLogger.LogInfo("LogInfo");
            myLogger.Info("Info");
            myLogger.LogDebug("LogDebug");
            myLogger.Debug("Debug");

            // normal logging functions - models and adapters
            myLogger.LogTrace("LogTrace");
            myLogger.Trace("Trace");
            myLogger.LogInternal("LogInternal");
            myLogger.Internal("Internal");

            // Header logging functions - testscripts
            myLogger.LogSubHeader("LogSubHeader");
            myLogger.SubHeader("SubHeader");
            myLogger.LogHeader("LogHeader");
            myLogger.Header("Header");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction", new[] { "arg1", "arg2" }, new object[] { null });
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction", 42);

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunctionShort");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunctionShort");

            // used solely by Assert functions
            myLogger.LogPass("testStepName LogPass", "LogPass");
            myLogger.Pass("testStepName Pass", "Pass");
            myLogger.LogFail("testStepName LogFail", "LogFail");
            myLogger.Fail("testStepName Fail", "Fail");

            myLogger.LogKeyValue("SomeKey", "SomeValue", "LogKeyValue");

            myLogger.LogInfo("Ovid TRACE: Nu kommer der en PASSING TestRunStatus");
            myLogger.SetRunStatus(true);
            myLogger.LogInfo("Ovid TRACE: Nu kommer der en FALING TestRunStatus");
            myLogger.SetRunStatus(false);
        }

        /// <summary>
        /// The test method_ lots of entries.
        /// </summary>
        [TestMethod]
        public void TestMethod_LotsOfEntries()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger.html", 
                LogLevel = LogLevel.Internal
            };

            myLogger.Header("For Some Reason this is never shown - seems like the first line is ignored");
            for (int i = 0; i < 75; i++)
            {
                myLogger.LogInfo(string.Format("LogInfo Nr {0}", i));
            }
        }

        /// <summary>
        /// The test method_ call stack.
        /// </summary>
        [TestMethod]
        public void TestMethod_CallStack()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger.html", 
                LogLevel = LogLevel.Internal
            };

            myLogger.Header("For Some Reason this is never shown - seems like the first line is ignored");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L1");
            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L2");
            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L3");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L3");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L2");
            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L3");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L2");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L1");
        }

        /// <summary>
        /// The test log screen shot.
        /// </summary>
        [TestMethod]
        public void TestLogScreenshot()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger.html", 
                LogLevel = LogLevel.Internal
            };

            myLogger.Header("For Some Reason this is never shown - seems like the first line is ignored");

            myLogger.LogTrace("Just before a screenshot is taken");
            myLogger.LogScreenshot(LogLevel.Info, "Grabbed screenshot");
            myLogger.LogTrace("right after a screenshot is taken");
        }

        /// <summary>
        /// The test log screenshot.
        /// </summary>
        [TestMethod]
        public void TestLogFileWriter()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger.html" };

            myLogger.FileName = @"c:\temp\unittestlogger.html";
            myLogger.FileName = @"c:\temp\unittestlogger2.html";
            myLogger.FileName = @"c:\temp\unittestlogger3.html";
        }

        /// <summary>
        /// The test method_ asserts.
        /// </summary>
        [TestMethod]
        public void TestMethod_Asserts()
        {
            var myLogger = new TestResultHtmlLogger
                               {
                                   FileName = @"c:\temp\unittestlogger_asserts.html", 
                                   LogLevel = LogLevel.Internal
                               };
            var myAsserter = new StfAssert
                                 {
                                    Logger = myLogger
                                 };

            myAsserter.AssertTrue("True Value for AssertTrue", true);
            myAsserter.AssertTrue("False Value for AssertTrue", false);
            myAsserter.AssertTrue("2 > 3 Value for AssertTrue", 2 > 3);
            myAsserter.AssertTrue("3 > 2 Value for AssertTrue", 3 > 2);

            myAsserter.AssertFalse("True Value for AssertFalse", true);
            myAsserter.AssertFalse("False Value for AssertFalse", false);
            myAsserter.AssertFalse("2 > 3 Value for AssertFalse", 2 > 3);
            myAsserter.AssertFalse("3 > 2 Value for AssertFalse", 3 > 2);
        }
    }
}
