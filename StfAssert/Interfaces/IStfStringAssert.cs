namespace Stf.Utilities.StfAssert.Interfaces
{
    interface IStfStringAssert
    {
        // Some wrapping of https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.stringassert.aspx

        bool StringContains(string testStep, string value, string substring);
        bool StringDoesNotContain(string testStep, string value, string substring);

        bool StringMatches(string testStep, string value, string pattern);
        bool StringDoesNotMatch(string testStep, string value, string pattern);

        bool StringStartsWith(string testStep, string value, string substring);
        bool StringDoesNotStartWith(string testStep, string value, string substring);

        bool StringEndsWith(string testStep, string value, string substring);
        bool StringDoesNotEndsWith(string testStep, string value, string substring);
    }
}
