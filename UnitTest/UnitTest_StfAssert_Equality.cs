// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest_StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities;

namespace UnitTest
{
    /// <summary>
    /// The unit test stf asserts.
    /// </summary>
    [TestClass]
    public class UnitTestStfAssert_Equality
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
        /// The test method assert equals.
        /// </summary>
        [TestMethod]
        public void TestMethodAssertGreaterThan()
        {
            var myLogger = new TestResultHtmlLogger { FileName = @"c:\temp\unittestlogger_TestMethodAssertGreaterThan.html" };
            var myAsserts = new StfAssert(myLogger);
            var obj1 = new DateTime(42);
            var obj2 = new DateTime(4242);

            Assert.IsTrue(myAsserts.AssertGreaterThan("2 > 1", 2, 1));
            Assert.IsTrue(myAsserts.AssertGreaterThan("2.0 > 1", 2.0, 1));
            Assert.IsFalse(myAsserts.AssertGreaterThan("1 > \"2\"", 1, "2"));
            Assert.IsFalse(myAsserts.AssertGreaterThan("1 > \"1.0\"", 1, "1.0"));

            Assert.IsFalse(myAsserts.AssertGreaterThan("\"\" == \"\"", string.Empty, string.Empty));
            Assert.IsFalse(myAsserts.AssertGreaterThan("\"\" == \" \"", string.Empty, " "));
            Assert.IsTrue(myAsserts.AssertGreaterThan("\" \" == \" \"", " ", string.Empty));
            Assert.IsFalse(myAsserts.AssertGreaterThan("\"a\" == \"A\"", "a", "A"));
            Assert.IsTrue(myAsserts.AssertGreaterThan("\"A\" == \"a\"", "A", "a"));
            Assert.IsFalse(myAsserts.AssertGreaterThan("\"string\" == \"string\"", "string", "string"));

            Assert.IsFalse(myAsserts.AssertGreaterThan("obj1 = obj1", obj1, obj1));
            Assert.IsFalse(myAsserts.AssertGreaterThan("obj1 = obj2", obj1, obj2));
            Assert.IsTrue(myAsserts.AssertGreaterThan("obj2 = obj1", obj2, obj1));

            // fail scenarios
            Assert.IsFalse(myAsserts.AssertGreaterThan("obj1 = 1", obj1, 1));
            Assert.IsFalse(myAsserts.AssertGreaterThan("obj1 = \"string\"", obj1, "string"));
        }
    }
}
