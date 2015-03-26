using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Init()
        {
            var MyLogger = new TestResultHtmlLogger.TestResultHtmlLogger();

            MyLogger.Init(@"c:\temp\unittestlogger.html");
        }


        /// <summary>
        /// All log levels
        /// </summary>
        [TestMethod]
        public void TestMethod_AllLogType()
        {
            var MyLogger = new TestResultHtmlLogger.TestResultHtmlLogger();

            MyLogger.Init(@"c:\temp\unittestlogger.html");
            MyLogger.LogLevel = TestResultHtmlLogger.LogLevel.Internal;

            MyLogger.Header("For Some Reason this is never shown - seems like the first line is ignored");
            MyLogger.LogError("LogError");
            MyLogger.Error("Error");
            MyLogger.LogWarning("LogWarning");
            MyLogger.Warning("Warning");
            MyLogger.LogInfo("LogInfo");
            MyLogger.Info("Info");
            MyLogger.LogDebug("LogDebug");
            MyLogger.Debug("Debug");

            // normal logging functions - models and adapters
            MyLogger.LogTrace("LogTrace");
            MyLogger.Trace("Trace");
            MyLogger.LogInternal("LogInternal");
            MyLogger.Internal("Internal");

            // Header logging functions - testscripts
            MyLogger.LogSubHeader("LogSubHeader");
            MyLogger.SubHeader("SubHeader");
            MyLogger.LogHeader("LogHeader");
            MyLogger.Header("Header");

            // used solely by Assert functions
            MyLogger.LogPass("testStepName LogPass", "LogPass");
            MyLogger.Pass("testStepName Pass", "Pass");
            MyLogger.LogFail("testStepName LogFail", "LogFail");
            MyLogger.Fail("testStepName Fail", "Fail");

            MyLogger.LogKeyValue("SomeKey", "SomeValue", "LogKeyValue");

            MyLogger.LogFunctionEnter(TestResultHtmlLogger.LogLevel.Info, "Int", "NameOfFunction", (new String[] { "arg1", "arg2" }), new object[] { null });
            MyLogger.LogFunctionExit(TestResultHtmlLogger.LogLevel.Info, "NameOfFunction", 42);

            MyLogger.LogFunctionEnter(TestResultHtmlLogger.LogLevel.Info, "Int", "NameOfFunctionShort");
            MyLogger.LogFunctionExit(TestResultHtmlLogger.LogLevel.Info, "NameOfFunctionShort");

            MyLogger.LogInfo("Ovid TRACE: Nu kommer der en PASSING TestRunStatus");
            MyLogger.SetRunStatus(true);
            MyLogger.LogInfo("Ovid TRACE: Nu kommer der en FALING TestRunStatus");
            MyLogger.SetRunStatus(false);

        }


        [TestMethod]
        public void TestMethod_LotsOfEntries()
        {
            var MyLogger = new TestResultHtmlLogger.TestResultHtmlLogger();

            MyLogger.Init(@"c:\temp\unittestlogger.html");
            MyLogger.LogLevel = TestResultHtmlLogger.LogLevel.Internal;

            MyLogger.Header("For Some Reason this is never shown - seems like the first line is ignored");
            for (int i = 0; i < 75; i++)
            {
                MyLogger.LogInfo(String.Format("LogInfo Nr {0}", i));
            }
        }
    }
}
