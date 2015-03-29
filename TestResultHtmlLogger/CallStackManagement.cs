// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallStackManagement.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   Defines the TestResultHtmlLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    /// <summary>
    /// The test result html logger. The <see cref="ICallStackManagement"/> part
    /// </summary>
    public partial class TestResultHtmlLogger : ICallStackManagement
    {
        /// <summary>
        /// The _call stack.
        /// </summary>
        private readonly Stack<string> _callStack = new Stack<string>();

        // =============================================================
        //
        // Functions in models/adapters
        //
        // =============================================================

        /// <summary>
        /// The log function enter. Should be called/inserted when entering a model/adapter function.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="nameOfReturnType">
        /// The name of return type.
        /// </param>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <param name="args">
        /// The <c>args</c>.
        /// </param>
        /// <param name="argValues">
        /// The <c>arg</c> values.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName, string[] args, object[] argValues)
        {
            string message;
            string argsString;

            argsString = "TODO: Concatenated string of argName and Values";

            message = string.Format("> {0} {1} {2} returning {3}", IndentString(), functionName, argsString, nameOfReturnType);
            _callStack.Push(functionName);
            return LogOneHtmlMessage(logLevel, message);
        }

        public int LogFunctionEnter(LogLevel logLevel, string nameOfReturnType, string functionName)
        {
            return LogFunctionEnter(logLevel, nameOfReturnType, functionName, null, null);
        }

        /// <summary>
        /// The log function exit. Should be called/inserted when exiting a model/adapter function.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <param name="returnValue">
        /// The return value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogFunctionExit(LogLevel logLevel, string functionName, object returnValue)
        {
            string message;
            string poppedName;

            poppedName = _callStack.Pop();
            message = string.Format("< {0} Exited {1} returning {2}", IndentString(), poppedName, "returnValue.ToString");
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

        /// <summary>
        /// The log get.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="callingProperty">
        /// The calling property.
        /// </param>
        /// <param name="getValue">
        /// The get value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogGet(LogLevel logLevel, string callingProperty, object getValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The log set.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="callingProperty">
        /// The calling property.
        /// </param>
        /// <param name="setValue">
        /// The set value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogSet(LogLevel logLevel, string callingProperty, object setValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The indent string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string IndentString()
        {
            var dotCount = _callStack.Count * 3;
            var retVal = string.Empty;

            for (var i = 0; i < dotCount; i++)
            {
                retVal += ".";
            }

            return retVal;
        }
    }
}
