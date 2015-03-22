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

        [TestMethod]
        public void TestMethod_AllLogType()
        {
            var MyLogger = new TestResultHtmlLogger.TestResultHtmlLogger();
            MyLogger.Init(@"c:\temp\unittestlogger.html");
            MyLogger.LogLevel = TestResultHtmlLogger.LogLevel.Internal;

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
        }
    }
}
