﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest_StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities.StfAssert;
    using Stf.Utilities.TestResultHtmlLogger;
    using System.IO;

    /// <summary>
    /// The unit test stf asserts.
    /// </summary>
    [TestClass]
    public class UnitTestStfAsserts
    {
        /// <summary>
        /// The test method assert equals.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertEquals()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestMethodAssertEquals.html" };
            var myAsserts = new StfAssert(myLogger);
            var obj1 = new DateTime(42);
            var obj2 = new DateTime(4242);

            Assert.IsTrue(myAsserts.AssertEquals("1 = 1", 1, 1));
            Assert.IsFalse(myAsserts.AssertEquals("1 = 1.0", 1, 1.0));
            Assert.IsFalse(myAsserts.AssertEquals("1 = \"1\"", 1, "1"));
            Assert.IsFalse(myAsserts.AssertEquals("1 = \"1.0\"", 1, "1.0"));

            Assert.IsTrue(myAsserts.AssertEquals("\"\" == \"\"", string.Empty, string.Empty));
            Assert.IsFalse(myAsserts.AssertEquals("\"\" == \" \"", string.Empty, " "));
            Assert.IsFalse(myAsserts.AssertEquals("\" \" == \" \"", " ", string.Empty));
            Assert.IsFalse(myAsserts.AssertEquals("\"A\" == \"a\"", "A", "a"));
            Assert.IsTrue(myAsserts.AssertEquals("\"string\" == \"string\"", "string", "string"));

            Assert.IsTrue(myAsserts.AssertEquals("obj1 = obj1", obj1, obj1));
            Assert.IsFalse(myAsserts.AssertEquals("obj1 = obj2", obj1, obj2));

            // fail scenarios
            Assert.IsFalse(myAsserts.AssertEquals("obj1 = 1", obj1, 1));
            Assert.IsFalse(myAsserts.AssertEquals("obj1 = \"string\"", obj1, "string"));
        }

        /// <summary>
        /// The test method assert strings.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertStrings()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestMethodAssertStrings.html" };
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

            Assert.IsTrue(myAsserts.StringEquals("TestStepName 17", "Hejsa", "Hejsa"));
            Assert.IsFalse(myAsserts.StringEquals("TestStepName 18", "Hejsa", "hejsa"));

            Assert.IsTrue(myAsserts.StringNotEquals("TestStepName 19", "Hejsa", "hejsa"));
            Assert.IsFalse(myAsserts.StringNotEquals("TestStepName 20", "Hejsa", "Hejsa"));

            Assert.IsTrue(myAsserts.StringEqualsCi("TestStepName 21", "Hejsa", "hejsa"));
            Assert.IsFalse(myAsserts.StringEqualsCi("TestStepName 22", "Hejsa", "hej"));

            Assert.IsTrue(myAsserts.StringNotEqualsCi("TestStepName 23", "Hejsa", "hejs"));
            Assert.IsFalse(myAsserts.StringNotEqualsCi("TestStepName 24", "Hejsa", "hejsa"));

            Assert.IsTrue(myAsserts.StringEmpty("TestStepName 25", string.Empty));
            Assert.IsFalse(myAsserts.StringEmpty("TestStepName 26", "Hejsa"));

            Assert.IsTrue(myAsserts.StringNotEmpty("TestStepName 27", "Hejsa"));
            Assert.IsFalse(myAsserts.StringNotEmpty("TestStepName 28", string.Empty));
        }

                /// <summary>
        /// The test method assert strings.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertFileContains()
        {
            const string UnitTestFile = @"c:\temp\TestMethodAssertFileContains.txt";
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_AssertFileContains.html" };
            var myAsserts = new StfAssert(myLogger);
            var testFile = File.CreateText(UnitTestFile);
            testFile.WriteLine("one line of test data");
            testFile.Close();

            Assert.IsFalse(myAsserts.AssertFileContains("TestStepName 1", @"c:\DoNotExists.nope", "A string"));
            Assert.IsFalse(myAsserts.AssertFileContains("TestStepName 2", UnitTestFile, "Nothing Like it"));
            Assert.IsTrue(myAsserts.AssertFileContains("TestStepName 3", UnitTestFile, "test"));
            Assert.IsTrue(myAsserts.AssertFileContains("TestStepName 4", UnitTestFile, "t[eE]st"));
        }
    }
}
