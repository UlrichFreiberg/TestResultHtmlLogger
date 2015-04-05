// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities;
    using Stf.Utilities.Interfaces;

    /// <summary>
    /// The unit test 1.
    /// </summary>
    [TestClass]
    public class UnitTestTestResultHtmlLogger
    {
        /// <summary>
        /// The test method_ init.
        /// </summary>
        [TestMethod]
        public void TestMethodInit()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestMethodInit.html" };
            myLogger.CloseLogFile();
        }

        /// <summary>
        /// All log levels
        /// </summary>
        [TestMethod]
        public void TestMethodAllLogType()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestMethodAllLogType.html",
                LogLevel = LogLevel.Internal
            };

            myLogger.LogError("LogError");
            myLogger.LogWarning("LogWarning");
            myLogger.LogInfo("LogInfo");
            myLogger.LogDebug("LogDebug");

            // normal logging functions - models and adapters
            myLogger.LogTrace("LogTrace");
            myLogger.LogInternal("LogInternal");

            // Header logging functions - testscripts
            myLogger.LogHeader("LogHeader");
            myLogger.LogSubHeader("LogSubHeader");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction", new[] { "arg1", "arg2" }, new object[] { null });
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction", 42);

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunctionShort");
            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunctionShort");

            // used solely by Assert functions
            myLogger.LogPass("testStepName LogPass", "LogPass");
            myLogger.LogFail("testStepName LogFail", "LogFail");

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
        public void TestMethodLotsOfEntries()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestMethodLotsOfEntries.html",
                LogLevel = LogLevel.Internal
            };

            for (int i = 0; i < 75; i++)
            {
                myLogger.LogInfo(string.Format("LogInfo Nr {0}", i));
            }
        }

        /// <summary>
        /// The test method_ call stack.
        /// </summary>
        [TestMethod]
        public void TestMethodCallStack()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestMethodCallStack.html",
                LogLevel = LogLevel.Internal
            };

            myLogger.LogInfo("NameOfFunction_L0A");
            myLogger.LogInfo("NameOfFunction_L0B");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L1");
            myLogger.LogInfo("NameOfFunction_L1A");
            myLogger.LogInfo("NameOfFunction_L1B");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L2");
            myLogger.LogInfo("NameOfFunction_L2A");
            myLogger.LogInfo("NameOfFunction_L2B");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L3");
            myLogger.LogInfo("NameOfFunction_L3A");
            myLogger.LogInfo("NameOfFunction_L3B");

            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L3");
            myLogger.LogInfo("NameOfFunction_L2A");
            myLogger.LogInfo("NameOfFunction_L2B");

            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L2");
            myLogger.LogInfo("NameOfFunction_L1A");
            myLogger.LogInfo("NameOfFunction_L1B");

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction_L2");
            myLogger.LogInfo("NameOfFunction_L2A");
            myLogger.LogInfo("NameOfFunction_L2B");

            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L2");
            myLogger.LogInfo("NameOfFunction_L1A");
            myLogger.LogInfo("NameOfFunction_L1B");

            myLogger.LogFunctionExit(LogLevel.Info, "NameOfFunction_L1");
            myLogger.LogInfo("NameOfFunction_L0A");
            myLogger.LogInfo("NameOfFunction_L0B");
        }

        /// <summary>
        /// The test log screen shot.
        /// </summary>
        [TestMethod]
        public void TestLogScreenshot()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestLogScreenshot.html",
                LogLevel = LogLevel.Internal
            };

            myLogger.LogTrace("Just before a screenshot is taken");
            myLogger.LogScreenshot(LogLevel.Info, "Grabbed screenshot");
            myLogger.LogTrace("right after a screenshot is taken");
        }

        /// <summary>
        /// The test log all windows.
        /// </summary>
        [TestMethod]
        public void TestLogAllWindows()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestLogAllWindows.html",
                LogLevel = LogLevel.Internal
            };

            myLogger.LogTrace("Just before logging all windows");
            myLogger.LogAllWindows(LogLevel.Info, "Grabbed all windows");
            myLogger.LogTrace("right after logging all windows");
        }

        /// <summary>
        /// The test log screen shot.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            var myLoggerByConstructor = new TestResultHtmlLogger(@"c:\temp\unittestlogger_TestLogFileWriterByConstructor.html");
            myLoggerByConstructor.CloseLogFile();
        }

        /// <summary>
        /// The test log screen shot.
        /// </summary>
        [TestMethod]
        public void TestLogFileWriter()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestLogFileWriter.html" };

            myLogger.FileName = @"c:\temp\unittestlogger.html";
            myLogger.FileName = @"c:\temp\unittestlogger2.html";
            myLogger.FileName = @"c:\temp\unittestlogger3.html";

            myLogger.CloseLogFile();
        }

        /// <summary>
        /// The test method_ asserts.
        /// </summary>
        [TestMethod]
        public void TestMethodAsserts()
        {
            var myLogger = new TestResultHtmlLogger
                               {
                                   FileName = @"c:\temp\unittestlogger_TestMethodAsserts.html",
                                   LogLevel = LogLevel.Internal
                               };
            var myAsserter = new StfAssert
                                 {
                                     AssertLogger = myLogger
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

        /// <summary>
        /// The test for keyvalues
        /// </summary>
        [TestMethod]
        public void TestMethodKeyValues()
        {
            var myLogger = new TestResultHtmlLogger
            {
                FileName = @"c:\temp\unittestlogger_TestMethodKeyValues.html",
                LogLevel = LogLevel.Internal
            };

            myLogger.LogKeyValue("Bent", "42", "First value for Bent");
            myLogger.LogKeyValue("Bent", "43", "Second value for Bent - this is the only one that should be shown in the list");
        }
    }
}
