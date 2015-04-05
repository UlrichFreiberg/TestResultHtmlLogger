// --------------------------------------------------------------------------------------------------------------------
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
    public class UnitTestStfAssert_Object
    {
        /// <summary>
        /// The test method assert equals.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertIsObject()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestMethodAssertIsObject.html" };
            var myAsserts = new StfAssert(myLogger);

            Assert.IsFalse(myAsserts.AssertIsObject("An integer", 1));
            Assert.IsTrue(myAsserts.AssertIsObject("A string", "1"));
            Assert.IsTrue(myAsserts.AssertIsObject("An object", new object()));
            Assert.IsTrue(myAsserts.AssertIsObject("An object", myAsserts));
            Assert.IsFalse(myAsserts.AssertIsObject("null", null));
        }
    }
}
