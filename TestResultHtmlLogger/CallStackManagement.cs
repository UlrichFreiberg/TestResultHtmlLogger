﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ITestResultHtmlLogger
    {
        Stack<String> CallStack = new Stack<String>();

        // =============================================================
        //
        // Functions in models/adapters
        //
        // =============================================================
        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName, string[] args, object[] argValues)
        {
            String message;
            String Args;

            Args = "TODO: Concatenated string of argName and Values";

            message = String.Format("--> {0} (1) returning {2}", functionName, Args, nameOfReturnType);
            CallStack.Push(functionName);
            return LogOneHtmlMessage(logLevel, message);
        }

        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName)
        {
            return LogFunctionEnter(logLevel, nameOfReturnType, functionName, null, null);
        }

        public int LogFunctionExit(LogLevel logLevel, string functionName, object returnValue)
        {
            String message;
            String PoppedName;

            PoppedName = CallStack.Pop();
            message = String.Format("<-- Exited {0} returning {1}", PoppedName, "returnValue.ToString");
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
