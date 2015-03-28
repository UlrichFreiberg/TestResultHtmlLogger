using System;
using Stf.Utilities.StfAssert.Interfaces;

namespace Stf.Utilities.StfAssert
{
    public class StfAssert : IStfAssert
    {
        Boolean Equals(Object expected, Object actual, ref String message) 
        {
            return true;
        }

        Boolean Comparable(Object expected, Object actual)
        {
            return true;
        }

        Boolean AssertPass(String testStep, String message)
        {
            return true;
        }

        Boolean AssertFail(String testStep, String message)
        {
            return true;
        }

        public bool EnableNegativeTesting
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CheckHasValue(object actual, ref string message)
        {
            throw new NotImplementedException();
        }

        public string LastMessage
        {
            get { throw new NotImplementedException(); }
            private set { throw new NotImplementedException(); }
        }

        public bool AssertEquals(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertBooleanEqual(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNotEquals(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNotEqualsCi(string testStep, object expected, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNothing(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNotNothing(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNotEmpty(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertIsObject(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertIsInstanceOf(string testStep, object value, string expectedTypeName)
        {
            throw new NotImplementedException();
        }

        public bool AssertNotNull(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertNull(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertHasValue(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertHasNoValue(string testStep, object actual)
        {
            throw new NotImplementedException();
        }

        public bool AssertGreaterThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        public bool AssertLessThan(string testStep, object leftHandSide, object rightHandSide)
        {
            throw new NotImplementedException();
        }

        public bool AssertFileExists(string testStep, string filenameAndPath)
        {
            throw new NotImplementedException();
        }

        public bool AssertFolderExists(string testStep, string foldernameAndPath)
        {
            throw new NotImplementedException();
        }

        public bool AssertFolderNotExists(string testStep, string foldernameAndPath)
        {
            throw new NotImplementedException();
        }

        public bool AssertFileNotExists(string testStep, string filenameAndPath)
        {
            throw new NotImplementedException();
        }

        public bool AssertTrue(string testStep, bool value)
        {
            throw new NotImplementedException();
        }

        public bool AssertFalse(string testStep, bool value)
        {
            throw new NotImplementedException();
        }
    }
}
