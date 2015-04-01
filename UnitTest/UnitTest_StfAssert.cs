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
            var obj1 = new DateTime(42);
            var obj2 = new DateTime(4242);

            myAsserts.AssertEquals("1 = 1", 1, 1);
            myAsserts.AssertEquals("1 = 1.0", 1, 1.0);
            myAsserts.AssertEquals("1 = \"1\"", 1, "1");
            myAsserts.AssertEquals("1 = \"1.0\"", 1, "1.0");

            myAsserts.AssertEquals("\"\" == \"\"", "", "");
            myAsserts.AssertEquals("\"\" == \" \"", "", " ");
            myAsserts.AssertEquals("\" \" == \" \"", " ", "");
            myAsserts.AssertEquals("\"A\" == \"a\"", "A", "a");
            myAsserts.AssertEquals("\"string\" == \"string\"", "string", "string");

            myAsserts.AssertEquals("obj1 = obj1", obj1, obj1);
            myAsserts.AssertEquals("obj1 = obj2", obj1, obj2);

            // fail scenarios
            myAsserts.AssertEquals("obj1 = 1", obj1, 1);
            myAsserts.AssertEquals("obj1 = \"string\"", obj1, "string");
            //Assert. myAsserts.AssertEquals("\"string\" = 1", "string", 1);
        }

        [TestMethod]
        public void TestMethod_AssertStrings()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\TestMethod_AssertStrings.html" };
            var myAsserts = new StfAssert(myLogger);

            Assert.IsTrue(myAsserts.StringContains("TestStepName", "Hejsa", "Hej"));
            Assert.IsFalse(myAsserts.StringContains("TestStepName", "Hejsa", "Bent"));
        }
    }
}
