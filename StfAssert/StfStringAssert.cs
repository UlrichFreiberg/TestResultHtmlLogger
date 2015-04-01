namespace Stf.Utilities.StfAssert
{
    using System.Text.RegularExpressions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities.StfAssert.Interfaces;

    public partial class StfAssert : IStfStringAssert
    {
        private enum StringAssertFunction { Contains, DoesNotMatch, EndsWith, Matches, StartsWith } ;

        private string WrapperStringAsserts(StringAssertFunction function, string value, string argstring)
        {
            string retVal = null;
            try
            {
                switch (function)
                {
                    case StringAssertFunction.Contains:
                        StringAssert.Contains(value, argstring);
                        break;
                    case StringAssertFunction.Matches:
                        StringAssert.Matches(value, new Regex(argstring));
                        break;
                    case StringAssertFunction.DoesNotMatch:
                        StringAssert.DoesNotMatch(value, new Regex(argstring));
                        break;
                    case StringAssertFunction.StartsWith:
                        StringAssert.StartsWith(value, argstring);
                        break;
                    case StringAssertFunction.EndsWith:
                        StringAssert.EndsWith(value, argstring);
                        break;
                }
            }
            catch (AssertFailedException ex)
            {
                retVal = ex.Message;
            }

            return retVal;
        }

        public bool StringContains(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.Contains, value, substring);

            if (retVal == null)
            {
                var message = string.Format("AssertContains [{0}] contains [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                AssertLogger.LogFail(testStep, retVal);
            }

            return (retVal == null);
        }


        public bool StringDoesNotContain(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.Contains, value, substring);

            if (retVal != null)
            {
                var message = string.Format("AssertDoesNotContain [{0}] don't contain [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                var message = string.Format("AssertDoesNotContain [{0}] do contain [{1}]", value, substring);
                AssertLogger.LogFail(testStep, message);
            }

            return (retVal != null);
        }

        public bool StringMatches(string testStep, string value, string pattern)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.Matches, value, pattern);

            if (retVal == null)
            {
                var message = string.Format("StringMatches [{0}] is matched by [{1}]", value, pattern);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                AssertLogger.LogFail(testStep, retVal);
            }

            return (retVal == null);
        }

        public bool StringDoesNotMatch(string testStep, string value, string pattern)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.DoesNotMatch, value, pattern);

            if (retVal == null)
            {
                var message = string.Format("StringDoesNotMatches [{0}] is not matched by [{1}]", value, pattern);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                AssertLogger.LogFail(testStep, retVal);
            }

            return (retVal == null);
        }

        public bool StringStartsWith(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.StartsWith, value, substring);

            if (retVal == null)
            {
                var message = string.Format("StringStartsWith [{0}] StartsWith [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                AssertLogger.LogFail(testStep, retVal);
            }

            return (retVal == null);
        }

        public bool StringDoesNotStartWith(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.StartsWith, value, substring);

            if (retVal != null)
            {
                var message = string.Format("StringDoesNotStartWith [{0}] doesn't start with [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                var message = string.Format("StringDoesNotStartWith [{0}] do start with [{1}]", value, substring);
                AssertLogger.LogFail(testStep, message);
            }

            return (retVal != null);
        }

        public bool StringEndsWith(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.EndsWith, value, substring);

            if (retVal == null)
            {
                var message = string.Format("StringEndsWith [{0}] EndsWith [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                AssertLogger.LogFail(testStep, retVal);
            }

            return (retVal == null);
        }

        public bool StringDoesNotEndsWith(string testStep, string value, string substring)
        {
            var retVal = WrapperStringAsserts(StringAssertFunction.EndsWith, value, substring);

            if (retVal != null)
            {
                var message = string.Format("StringDoesNotEndsWith [{0}] doesn't ends with [{1}]", value, substring);
                AssertLogger.LogPass(testStep, message);
            }
            else
            {
                var message = string.Format("StringDoesNotEndsWith [{0}] do ends with [{1}]", value, substring);
                AssertLogger.LogFail(testStep, message);
            }

            return (retVal != null);
        }
    }
}
