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

            Assert.IsTrue(myAsserts.StringContains("TestStepName 1", "Hejsa", "Hej"));
            Assert.IsFalse(myAsserts.StringContains("TestStepName 2", "Hejsa", "Bent"));

            Assert.IsTrue(myAsserts.StringDoesNotContain("TestStepName 3", "Hejsa", "Bent"));
            Assert.IsFalse(myAsserts.StringDoesNotContain("TestStepName 4", "Hejsa", "Hej"));

            Assert.IsTrue(myAsserts.StringMatches("TestStepName 5", "Hejsa", "^He.*"));
            Assert.IsFalse(myAsserts.StringMatches("TestStepName 6", "Hejsa", "Nix.*"));

            Assert.IsTrue(myAsserts.StringDoesNotMatch("TestStepName 7", "Hejsa", "Nix.*"));
            Assert.IsFalse(myAsserts.StringDoesNotMatch("TestStepName 8", "Hejsa", "^He.*"));

            Assert.IsTrue(myAsserts.StringStartsWith("TestStepName 9", "Hejsa", "He"));
            Assert.IsFalse(myAsserts.StringStartsWith("TestStepName 10", "Hejsa", "hej"));

            Assert.IsTrue(myAsserts.StringDoesNotStartWith("TestStepName 11", "Hejsa", "hej"));
            Assert.IsFalse(myAsserts.StringDoesNotStartWith("TestStepName 12", "Hejsa", "He"));

            Assert.IsTrue(myAsserts.StringEndsWith("TestStepName 13", "Hejsa", "jsa"));
            Assert.IsFalse(myAsserts.StringEndsWith("TestStepName 14", "Hejsa", "Hej"));

            Assert.IsTrue(myAsserts.StringDoesNotEndsWith("TestStepName 15", "Hejsa", "Bent"));
            Assert.IsFalse(myAsserts.StringDoesNotEndsWith("TestStepName 16", "Hejsa", "ejsa"));
        }
    }
}
