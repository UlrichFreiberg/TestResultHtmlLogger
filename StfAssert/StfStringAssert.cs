using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stf.Utilities.StfAssert.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stf.Utilities.TestResultHtmlLogger;

namespace Stf.Utilities.StfAssert
{
    using System.Diagnostics.SymbolStore;

    public partial class StfAssert : IStfStringAssert
    {
        private enum StringAssertFunction { Contains, ContainsNot, Match, MatchNot } ;

        private string WrapperStringAsserts(StringAssertFunction function, string value, string argstring)
        {
            string retVal = null;
            try
            {
                switch (function)
                {
                    case StringAssertFunction.Contains:
                        Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains(value, argstring);
                        break;
                }
            }
            catch (AssertFailedException Ex)
            {
                retVal = Ex.Message;
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
            throw new NotImplementedException();
        }

        public bool StringMatches(string testStep, string value, string pattern)
        {
            throw new NotImplementedException();
        }

        public bool StringDoesNotMatch(string testStep, string value, string pattern)
        {
            throw new NotImplementedException();
        }

        public bool StringStartsWith(string testStep, string value, string substring)
        {
            throw new NotImplementedException();
        }

        public bool StringDoesNotStartWith(string testStep, string value, string substring)
        {
            throw new NotImplementedException();
        }

        public bool StringEndsWith(string testStep, string value, string substring)
        {
            throw new NotImplementedException();
        }

        public bool StringDoesNotEndsWith(string testStep, string value, string substring)
        {
            throw new NotImplementedException();
        }
    }
}
