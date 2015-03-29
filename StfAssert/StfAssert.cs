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
        /// <summary>
        /// The m enable negative testing.
        /// </summary>
        private bool mEnableNegativeTesting;

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
                return this.mEnableNegativeTesting;
            }

            set
            {
                this.Logger.LogTrace(string.Format("EnableNegativeTesting set to [{0}]", value.ToString()));
                this.mEnableNegativeTesting = value;
            }
        }

        /// <summary>
        /// Gets the last message.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string LastMessage
        {
            get { throw new NotImplementedException(); }
            private set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// The assert equals.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertEquals(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert boolean equal.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertBooleanEqual(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert equals ci.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert not equals.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNotEquals(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert not equals ci.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNotEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert nothing.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNothing(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert not nothing.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNotNothing(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert empty.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert not empty.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNotEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert is object.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertIsObject(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert is instance of.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="expectedTypeName">
        /// The expected type name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertIsInstanceOf(string testStep, object value, string expectedTypeName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert not null.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNotNull(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert null.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertNull(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert has value.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertHasValue(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert has no value.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertHasNoValue(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert greater than.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="leftHandSide">
        /// The left hand side.
        /// </param>
        /// <param name="rightHandSide">
        /// The right hand side.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertGreaterThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert less than.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="leftHandSide">
        /// The left hand side.
        /// </param>
        /// <param name="rightHandSide">
        /// The right hand side.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertLessThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert file exists.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="filenameAndPath">
        /// The filename and path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertFileExists(string testStep, string filenameAndPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert folder exists.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="foldernameAndPath">
        /// The foldername and path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertFolderExists(string testStep, string foldernameAndPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert folder not exists.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="foldernameAndPath">
        /// The foldername and path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertFolderNotExists(string testStep, string foldernameAndPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert file not exists.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="filenameAndPath">
        /// The filename and path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AssertFileNotExists(string testStep, string filenameAndPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The assert true.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="value">
        /// The value actually experienced
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
        /// The assert false.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="value">
        /// The value actually experienced
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
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        private bool CheckHasValue(object actual, ref string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="actual">
        /// The value actually experienced
        /// </param>
        /// <param name="message">
        /// The message.
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
        /// The expected.
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
        /// The message.
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
        /// The message.
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
