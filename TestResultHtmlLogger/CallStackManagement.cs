using System;
using System.Collections.Generic;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ITestResultHtmlLogger
    {
        readonly Stack<String> _callStack = new Stack<String>();

        private String IndentString()
        {
            int dotCount = _callStack.Count * 3;
            String retVal = String.Empty;

            for(int i=0; i<dotCount;i++) {
                retVal += ".";
            }

            //"".PadLeft(CallStack.Count * 3)
            return retVal;
        }

        // =============================================================
        //
        // Functions in models/adapters
        //
        // =============================================================
        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName, string[] args, object[] argValues)
        {
            String message;
            String argsString;

            argsString = "TODO: Concatenated string of argName and Values";

            message = String.Format("> {0} {1} {2} returning {3}", IndentString(), functionName, argsString, nameOfReturnType);
            _callStack.Push(functionName);
            return LogOneHtmlMessage(logLevel, message);
        }

        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName)
        {
            return LogFunctionEnter(logLevel, nameOfReturnType, functionName, null, null);
        }

        public int LogFunctionExit(LogLevel logLevel, string functionName, object returnValue)
        {
            String message;
            String poppedName;

            poppedName = _callStack.Pop();
            message = String.Format("< {0} Exited {1} returning {2}", IndentString(), poppedName, "returnValue.ToString");
            return LogOneHtmlMessage(logLevel, message);
        }

        public int LogFunctionExit(LogLevel logLevel, string functionName)
        {
            return LogFunctionExit(logLevel, functionName, null);
        }

        // =============================================================
        //
        // Properties in models/adapters
        //
        // =============================================================
        int ITestResultHtmlLogger.LogGet(LogLevel logLevel, string callingProperty, object getValue)
        {
            throw new NotImplementedException();
        }

        int ITestResultHtmlLogger.LogSet(LogLevel logLevel, string callingProperty, object setValue)
        {
            throw new NotImplementedException();
        }
    }
}
