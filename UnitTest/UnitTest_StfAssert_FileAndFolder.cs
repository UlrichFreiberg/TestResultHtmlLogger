// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest_StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities;
    using System.IO;

    /// <summary>
    /// The unit test stf asserts.
    /// </summary>
    [TestClass]
    public class UnitTestStfAssert__FileAndFolder
    {
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
