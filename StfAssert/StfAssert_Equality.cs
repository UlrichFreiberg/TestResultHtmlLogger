// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities.Interfaces;

namespace Stf.Utilities
{
    /// <summary>
    /// The stf assert.
    /// </summary>
    public partial class StfAssert : IStfAssert
    {
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
        public bool AssertGreaterThan<T1, T2>(string testStep, T1 leftHandSide, T2 rightHandSide)
            where T1 : IConvertible,IComparable
            where T2 : IConvertible,IComparable
        {
            T1 rhsAsLhs ;
            bool retVal;
            string msg;

            try
            {
                // convert val2 to type of val1.
                rhsAsLhs = (T1)Convert.ChangeType(rightHandSide, typeof(T1));
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                retVal = false;
                this.AssertFail(testStep, msg);
                return false;
            }

            int compareVal = leftHandSide.CompareTo(rhsAsLhs);
            retVal = compareVal > 0;

            if (retVal)
            {
                msg = string.Format("AssertGreaterThan: [{0}] is greater then [{1}]", leftHandSide.ToString(), rightHandSide.ToString());
                this.AssertPass(testStep, msg);
            }
            else
            {
                msg = string.Format("AssertGreaterThan: [{0}] is Not greater then [{1}]", leftHandSide.ToString(), rightHandSide.ToString());
                this.AssertFail(testStep, msg);                
            }

            return retVal;
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
        {
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
