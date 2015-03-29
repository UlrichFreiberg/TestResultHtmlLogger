using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities.TestResultHtmlLogger;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Init()
        {
            var myLogger = new TestResultHtmlLogger {FileName = @"c:\temp\unittestlogger.html"};
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

            myLogger.LogFunctionEnter(LogLevel.Info, "Int", "NameOfFunction", (new[] { "arg1", "arg2" }), new object[] { null });
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
                myLogger.LogInfo(String.Format("LogInfo Nr {0}", i));
            }
        }

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
        /// The test log screenshot.
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
            var myLogger = new TestResultHtmlLogger {FileName = @"c:\temp\unittestlogger.html"};

            myLogger.FileName = @"c:\temp\unittestlogger.html" ;
            myLogger.FileName = @"c:\temp\unittestlogger2.html";
            myLogger.FileName = @"c:\temp\unittestlogger3.html";
        }
    }
}
