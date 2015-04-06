// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest_StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities;

namespace UnitTest
{
    /// <summary>
    /// The unit test stf asserts.
    /// </summary>
    [TestClass]
    public class UnitTestStfAsserts
    {
        /// <summary>
        /// The test method assert strings.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertTrue()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_AssertTrue.html" };
            var myAsserts = new StfAssert(myLogger);

            Assert.IsTrue(myAsserts.AssertTrue("true", true));
            Assert.IsFalse(myAsserts.AssertTrue("false", false));
        }

        /// <summary>
        /// The test method assert strings.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertFalse()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_AssertFalse.html" };
            var myAsserts = new StfAssert(myLogger);

            Assert.IsFalse(myAsserts.AssertFalse("true", true));
            Assert.IsTrue(myAsserts.AssertFalse("false", false));
        }
    }
}
