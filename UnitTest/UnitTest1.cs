using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var MyLogger = new TestResultHtmlLogger.TestResultHtmlLogger();
            MyLogger.Init(@"c:\temp\unittestlogger.html");
        }
    }
}
