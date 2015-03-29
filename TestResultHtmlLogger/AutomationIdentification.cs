﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomationIdentification.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   Defines the TestResultHtmlLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    /// <summary>
    /// The test result logger. The <see cref="IAutomationIdentification"/> part.
    /// </summary>
    public partial class TestResultHtmlLogger : IAutomationIdentification
    {
        /// <summary>
        /// Dump an AutomationIdentification <c>object</c>.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="automationIdObj">
        /// The automation id obj.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogAutomationIdObject(LogLevel logLevel, object automationIdObj, string message)
        {
            throw new NotImplementedException();
        }
    }
}
