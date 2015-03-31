using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities.StfAssert;
using Stf.Utilities.TestResultHtmlLogger;

namespace UnitTest
{
    [TestClass]
    public class UnitTestStfAsserts
    {
        [TestMethod]
        public void TestMethod_AssertEquals()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\TestMethod_AssertEquals.html" };
            var myAsserts = new StfAssert(myLogger);

            myAsserts.AssertEquals("1 = 1", 1, 1);
            myAsserts.AssertEquals("1 = 1.0", 1, 1.0);
            myAsserts.AssertEquals("1 = \"1\"", 1, "1");
            myAsserts.AssertEquals("1 = \"1.0\"", 1, "1.0");

            myAsserts.AssertEquals("\"\" == \"\"", "", "");
            myAsserts.AssertEquals("\"\" == \" \"", "", " ");
            myAsserts.AssertEquals("\" \" == \" \"", " ", "");
            myAsserts.AssertEquals("\"A\" == \"a\"", "A", "a");
            myAsserts.AssertEquals("\"string\" == \"string\"", "string", "string");

            var obj1 = new DateTime(42);
            var obj2 = new DateTime(4242);

            myAsserts.AssertEquals("obj1 = obj1", obj1, obj1);
            myAsserts.AssertEquals("obj1 = obj2", obj1, obj2);
        }
    }
}
