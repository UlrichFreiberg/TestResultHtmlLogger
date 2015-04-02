namespace Stf.Utilities.StfAssert.Interfaces
{
    interface IStfStringAssert
    {
#region Some wrapping of https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.stringassert.aspx

        bool StringContains(string testStep, string value, string substring);
        bool StringDoesNotContain(string testStep, string value, string substring);

        bool StringMatches(string testStep, string value, string pattern);
        bool StringDoesNotMatch(string testStep, string value, string pattern);

        bool StringStartsWith(string testStep, string value, string substring);
        bool StringDoesNotStartWith(string testStep, string value, string substring);

        bool StringEndsWith(string testStep, string value, string substring);
        bool StringDoesNotEndsWith(string testStep, string value, string substring);
#endregion

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
        bool StringEqualsCi(string testStep, string expected, string actual);

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
        bool StringNotEqualsCi(string testStep, string expected, string actual);

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
        bool StringEmpty(string testStep, string actual);

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
        bool StringNotEmpty(string testStep, string actual);
    }
}
