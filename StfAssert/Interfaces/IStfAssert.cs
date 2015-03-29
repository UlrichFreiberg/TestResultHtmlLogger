// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStfAssert.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   Defines the IStfAssert type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Stf.Utilities.StfAssert.Interfaces
{
    /// <summary>
    /// The StfAssert interface.
    /// </summary>
    public interface IStfAssert
    {
        /// <summary>
        /// Gets or sets a value indicating whether negative testing is enabled - 
        /// As in LogFail and errors don't count as errors
        /// </summary>
        bool EnableNegativeTesting { get; set; }

        /// <summary>
        /// Gets the last message reported - used by Unit tests 
        /// </summary>
        string LastMessage { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="expected">Value expected for the assert</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertEquals(string testStep, object expected, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="expected">Value expected for the assert</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertBooleanEqual(string testStep, object expected, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="expected">Value expected for the assert</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertEqualsCi(string testStep, object expected, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="expected">Value expected for the assert</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNotEquals(string testStep, object expected, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="expected">Value expected for the assert</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNotEqualsCi(string testStep, object expected, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNothing(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNotNothing(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertEmpty(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNotEmpty(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertIsObject(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="value"></param>
        /// <param name="expectedTypeName"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertIsInstanceOf(string testStep, object value, string expectedTypeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNotNull(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertNull(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertHasValue(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="actual">Value that was actually experienced</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertHasNoValue(string testStep, object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="leftHandSide"></param>
        /// <param name="rightHandSide"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertGreaterThan(string testStep, object leftHandSide, object rightHandSide);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="leftHandSide"></param>
        /// <param name="rightHandSide"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertLessThan(string testStep, object leftHandSide, object rightHandSide);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="filenameAndPath">Absolut path to the file of interest</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertFileExists(string testStep, string filenameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="foldernameAndPath"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertFolderExists(string testStep, string foldernameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="foldernameAndPath"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertFolderNotExists(string testStep, string foldernameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="filenameAndPath">Absolut path to the file of interest</param>
        /// <returns><see cref="bool"/></returns>
        bool AssertFileNotExists(string testStep, string filenameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="value"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertTrue(string testStep, bool value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the test script</param>
        /// <param name="value"></param>
        /// <returns><see cref="bool"/></returns>
        bool AssertFalse(string testStep, bool value);
    }
}
