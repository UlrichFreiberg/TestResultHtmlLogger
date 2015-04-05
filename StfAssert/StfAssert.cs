// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Stf.Utilities.StfAssert
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities.StfAssert.Interfaces;
    using Stf.Utilities.TestResultHtmlLogger;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The stf assert.
    /// </summary>
    public partial class StfAssert : IStfAssert
    {
        /// <summary>
        /// The m enable negative testing.
        /// </summary>
        private bool enableNegativeTesting;

        /// <summary>
        /// Initializes a new instance of the <see cref="StfAssert"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public StfAssert(TestResultHtmlLogger logger)
        {
            AssertLogger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StfAssert"/> class.
        /// </summary>
        public StfAssert()
        {
            AssertLogger = null;
        }

        /// <summary>
        /// Gets or sets the assert logger.
        /// </summary>
        public TestResultHtmlLogger AssertLogger { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether enable negative testing.
        /// </summary>
        public bool EnableNegativeTesting
        {
            get
            {
                return this.enableNegativeTesting;
            }

            set
            {
                this.AssertLogger.LogTrace(string.Format("EnableNegativeTesting set to [{0}]", value.ToString()));
                this.enableNegativeTesting = value;
            }
        }

        /// <summary>
        /// Gets the last message.
        /// </summary>
        public string LastMessage
        {
            get { throw new NotImplementedException(); }
            private set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Assert if two values are the same. Values and objects can be compared.
        /// </summary>
        /// <typeparam name="T1">
        /// </typeparam>
        /// <typeparam name="T2">
        /// </typeparam>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="expected">
        /// Value <c>expected</c> for the assert
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertEquals<T1, T2>(string testStep, T1 expected, T2 actual)
        {
            bool retVal = true;
            string msg;

            try
            {
                msg = string.Format("AssertEquals: [{0}] Are Equal to [{1}]", expected, actual);
                Assert.AreEqual(expected, actual);
                this.AssertPass(testStep, msg);
            }
            catch (AssertFailedException ex)
            {
                msg = ex.Message;
                retVal = false;
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that two values are the same. Values and objects can be compared.
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="expected">
        /// Value <c>expected</c> for the assert
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertNotEquals(string testStep, object expected, object actual)
        {
            var retVal = true;
            string msg;

            try
            {
                Assert.AreNotEqual(expected, actual);
                msg = string.Format("AssertNotEquals: [{0}] Not Equal to [{1}]", expected, actual);
                retVal = this.AssertPass(testStep, msg);
            }
            catch (AssertFailedException ex)
            {
                msg = ex.Message;
                retVal = false;
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a value is a Object type and not a reference type
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertIsObject(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts a variable is of a specific type
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="value">
        /// The variable to investigate
        /// </param>
        /// <param name="expectedTypeName">
        /// The expected type of the variable
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertIsInstanceOf(string testStep, object value, Type expectedType)
        {
            var retVal = true;
            string msg;

            try
            {
                Assert.IsInstanceOfType(value, expectedType);
                msg = string.Format("AssertNotEquals: [{0}] is of type [{1}]", value, expectedType.ToString());
                retVal = this.AssertPass(testStep, msg);
            }
            catch (AssertFailedException ex)
            {
                retVal = false;
                msg = ex.Message;
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts whether a variable is NOT Null
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertNotNull(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts whether a variable is Null
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertNull(string testStep, object actual)
        {
            bool retVal = actual == null;
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertNull: object Is null");
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertNull:'{0}' Is not null", actual.ToString());
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts whether a variable has a value - e.g. not Null or Empty
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertHasValue(string testStep, object actual)
        {
            bool retVal = actual != null;
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertHasValue: Has a value");
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertHasValue: Has no value");
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts whether a variable has NO value - e.g. Null or Empty
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="actual">
        /// Value that was actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertHasNoValue(string testStep, object actual)
        {
            bool retVal = actual == null;
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertHasNoValue: Has no value");
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertHasNoValue: Has a value");
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts whether the left hand side is greater than the right hand side
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="leftHandSide">
        /// The value to the left in a compare expression
        /// </param>
        /// <param name="rightHandSide">
        /// The value to the right in a compare expression
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertGreaterThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts whether the left hand side is less than the right hand side
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="leftHandSide">
        /// The value to the left in a compare expression
        /// </param>
        /// <param name="rightHandSide">
        /// The value to the right in a compare expression
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertLessThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that a file exists
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="filenameAndPath">
        /// Absolute path to the file of interest
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFileExists(string testStep, string filenameAndPath)
        {
            var retVal = File.Exists(filenameAndPath);
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertFileExists: [{0}] Does exist", filenameAndPath);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFileExists: [{0}] Does Not exist", filenameAndPath);
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a file exists
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="filenameAndPath">
        /// Absolute path to the file of interest
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFileContains(string testStep, string filenameAndPath, string pattern)
        {
            bool retVal;
            string msg;

            if (!File.Exists(filenameAndPath))
            {
                msg = string.Format("AssertFileContains: [{0}] Does Not exist", filenameAndPath);
                this.AssertFail(testStep, msg);
                return false;
            }

            var content = File.ReadAllText(filenameAndPath);
            Regex regex = new Regex(pattern);
            Match match = regex.Match(content);
            retVal = match.Success;

            if (retVal)
            {
                msg = string.Format("AssertFileContains: [{0}] Does contain [{1}]", filenameAndPath, pattern);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFileContains: [{0}] Does Not contain [{1}]", filenameAndPath, pattern);
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a folder (directory) exists
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="foldernameAndPath">
        /// Path to the folder
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFolderExists(string testStep, string foldernameAndPath)
        {
            var retVal = Directory.Exists(foldernameAndPath);
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertFolderExists: [{0}] Does exist", foldernameAndPath);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFolderExists: [{0}] Does Not exist", foldernameAndPath);
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a folder (directory) does NOT exists
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="foldernameAndPath">
        /// Path to the folder
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFolderNotExists(string testStep, string foldernameAndPath)
        {
            var retVal = !Directory.Exists(foldernameAndPath);
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertFolderNotExists: [{0}] Does Not exist", foldernameAndPath);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFolderNotExists: [{0}] Does exist", foldernameAndPath);
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a file doesn't exists
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="filenameAndPath">
        /// Absolute path to the file of interest
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFileNotExists(string testStep, string filenameAndPath)
        {
            var retVal = !File.Exists(filenameAndPath);
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertFileNotExists: [{0}] Does Not exist", filenameAndPath);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFileNotExists: [{0}] Does exist", filenameAndPath);
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a expression is True
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="value">
        /// The Value to investigate
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertTrue(string testStep, bool value)
        {
            bool retVal = value;
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertTrue: value True");
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertTrue: value False");
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// Asserts that a expression is True
        /// </summary>
        /// <param name="testStep">
        /// Name of the test step in the test script
        /// </param>
        /// <param name="value">
        /// The Value to investigate
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AssertFalse(string testStep, bool value)
        {
            bool retVal = !value;
            string msg;

            if (retVal)
            {
                msg = string.Format("AssertFalse: value False");
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertFalse: value True");
                this.AssertFail(testStep, msg);
            }

            return retVal;
        }

        /// <summary>
        /// The value equality.
        /// </summary>
        /// <param name="val1">
        /// The val 1.
        /// </param>
        /// <param name="val2">
        /// The val 2.
        /// </param>
        /// <typeparam name="T1">
        /// </typeparam>
        /// <typeparam name="T2">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ValueEquality<T1, T2>(T1 val1, T2 val2)

            // where T1 : IConvertible
        {
            // where T2 : IConvertible
            // convert val2 to type of val1.
            T1 boxed2 = (T1)Convert.ChangeType(val2, typeof(T1));

            // compare now that same type.
            return val1.Equals(boxed2);
        }

        /// <summary>
        /// The check has value.
        /// </summary>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckHasValue(object actual, ref string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="expected">
        /// The Expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Equals(object expected, object actual, ref string message)
        {
            return true;
        }

        /// <summary>
        /// The comparable.
        /// </summary>
        /// <param name="expected">
        /// The Expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Comparable(object expected, object actual)
        {
            return true;
        }

        /// <summary>
        /// The assert pass.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AssertPass(string testStep, string message)
        {
            this.AssertLogger.LogPass(testStep, message);
            return true;
        }

        /// <summary>
        /// The assert fail.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AssertFail(string testStep, string message)
        {
            this.AssertLogger.LogFail(testStep, message);
            return true;
        }

        /// <summary>
        /// The wrapper assert equals old.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The actual.
        /// </param>
        /// <typeparam name="T1">
        /// </typeparam>
        /// <typeparam name="T2">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool WrapperAssertEqualsOld<T1, T2>(string testStep, T1 expected, T2 actual)
        {
            var expectedTypeInfo = expected.GetType();
            var actualTypeInfo = actual.GetType();

            if (expectedTypeInfo.IsPrimitive && actualTypeInfo.IsPrimitive)
            {
                return CompareTo(expected, actual);
            }

            if (actualTypeInfo != expectedTypeInfo)
            {
                Console.WriteLine("Different type of objects are different");
                return false;
            }

            if (expected is IConvertible)
            {
                return CompareTo(expected, actual);
            }

            switch (actualTypeInfo.FullName)
            {
                case "System.String":
                    var orgStringActual = (string)Convert.ChangeType(actual, actualTypeInfo);
                    var orgStringExpected = (string)Convert.ChangeType(expected, expectedTypeInfo);
                    var retVal = string.CompareOrdinal(orgStringExpected, orgStringActual);
                    return retVal == 0;
            }

            return false;
        }

        /// <summary>
        /// The compare to.
        /// </summary>
        /// <param name="obj1">
        /// The obj 1.
        /// </param>
        /// <param name="obj2">
        /// The obj 2.
        /// </param>
        /// <typeparam name="T1">
        /// </typeparam>
        /// <typeparam name="T2">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CompareTo<T1, T2>(T1 obj1, T2 obj2)
        {
            if ((obj1 is IConvertible) && (obj2 is IConvertible))
            {
                return ValueEquality(obj1, obj2);
            }

            return false;
        }
    }
}
