// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Stf.Utilities.StfAssert
{
    using System;

    using Stf.Utilities.StfAssert.Interfaces;
    using Stf.Utilities.TestResultHtmlLogger;

    /// <summary>
    /// The stf assert.
    /// </summary>
    public class StfAssert : IStfAssert
    {
        public StfAssert(TestResultHtmlLogger logger)
        {
            AssertLogger = logger;
        }
        public StfAssert()
        {
            AssertLogger = null;
        }

        TestResultHtmlLogger AssertLogger { get; set; }

        /// <summary>
        /// The m enable negative testing.
        /// </summary>
        private bool enableNegativeTesting;

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public TestResultHtmlLogger Logger { get; set; }

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
                this.Logger.LogTrace(string.Format("EnableNegativeTesting set to [{0}]", value.ToString()));
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
            bool RetVal;

            RetVal = WrapperAssertEquals(testStep, expected, actual);

            if (RetVal)
            {
                AssertLogger.LogPass(testStep, "Pass");
            }
            else
            {
                AssertLogger.LogFail(testStep, "Fail");
            }

            return RetVal;
        }

        private bool WrapperAssertEquals<T1, T2>(string testStep, T1 expected, T2 actual)
        {
            var ExpectedTypeInfo = expected.GetType();
            var ActualTypeInfo = actual.GetType();

            if (ExpectedTypeInfo.IsPrimitive && ActualTypeInfo.IsPrimitive)
            {
                return CompareTo(expected, actual);
            }

            if (ActualTypeInfo != ExpectedTypeInfo)
            {
                Console.WriteLine("Different type of objects are different");
                return false;
            }

            if (expected is IConvertible)
            {
                return CompareTo(expected, actual);
            }

            switch (ActualTypeInfo.FullName)
            {
                case "System.String":
                    var OrgStringActual = (string)(Convert.ChangeType(actual, ActualTypeInfo));
                    var OrgStringExpected = (string)(Convert.ChangeType(expected, ExpectedTypeInfo));
                    var RetVal = string.Compare(OrgStringExpected, OrgStringActual);
                    return (RetVal == 0);
            }

            return false;
        }

        private bool CompareTo<T1, T2>(T1 obj1, T2 obj2)
        {
            if ((obj1 is IConvertible) && (obj2 is IConvertible))
            {
                return ValueEquality(obj1, obj2);
            }

            return false;
        }

        private bool ValueEquality<T1, T2>(T1 val1, T2 val2)
        //where T1 : IConvertible
        //where T2 : IConvertible
        {
            // convert val2 to type of val1.
            T1 boxed2 = (T1)Convert.ChangeType(val2, typeof(T1));

            // compare now that same type.
            return val1.Equals(boxed2);
        }

        /// <summary>
        /// Assert if two strings are the same - Case Insignificant
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
        public bool AssertEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that two values are not equal - Case Insignificant
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
        public bool AssertNotEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that a string is Null or Empty
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
        public bool AssertEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that a string is Not (Null or Empty)
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
        public bool AssertNotEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
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
        public bool AssertIsInstanceOf(string testStep, object value, string expectedTypeName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            string msg;

            if (value)
            {
                msg = string.Format("TestStep:'{0}' - AssertTrue - value True", testStep);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("TestStep:'{0}' - AssertTrue - value False", testStep);
                this.AssertFail(testStep, msg);
            }

            return true;
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
            string msg;

            if (!value)
            {
                msg = string.Format("TestStep:'{0}' - AssertFalse - value False", testStep);
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("TestStep:'{0}' - AssertFalse - value True", testStep);
                this.AssertFail(testStep, msg);
            }

            return true;
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
            this.Logger.LogPass(testStep, message);
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
            this.Logger.LogFail(testStep, message);
            return true;
        }
    }
}
