﻿// --------------------------------------------------------------------------------------------------------------------
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
    }
}
