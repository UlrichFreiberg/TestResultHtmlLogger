﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StfAssert.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Stf.Utilities.StfAssert
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Stf.Utilities.StfAssert.Interfaces;
    using Stf.Utilities.TestResultHtmlLogger;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The stf assert.
    /// </summary>
    public partial class StfAssert : IStfAssert
    {
        /// <summary>
        /// The m enable negative testing.
        /// </summary>
        private bool enableNegativeTesting;

        /// <summary>
        /// Initializes a new instance of the <see cref="StfAssert"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public StfAssert(TestResultHtmlLogger logger)
        {
            AssertLogger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StfAssert"/> class.
        /// </summary>
        public StfAssert()
        {
            AssertLogger = null;
        }

        /// <summary>
        /// Gets or sets the assert logger.
        /// </summary>
        public TestResultHtmlLogger AssertLogger { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether enable negative testing.
        /// </summary>
        public bool EnableNegativeTesting
        {
            get
            {
                return this.enableNegativeTesting;
            }

            set
            {
                this.AssertLogger.LogTrace(string.Format("EnableNegativeTesting set to [{0}]", value.ToString()));
                this.enableNegativeTesting = value;
            }
        }

        /// <summary>
        /// Gets the last message.
        /// </summary>
        public string LastMessage
        {
            get { throw new NotImplementedException(); }
            private set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// The assert pass.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AssertPass(string testStep, string message)
        {
            this.AssertLogger.LogPass(testStep, message);
            return true;
        }

        /// <summary>
        /// The assert fail.
        /// </summary>
        /// <param name="testStep">
        /// The test step.
        /// </param>
        /// <param name="message">
        /// The Message.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AssertFail(string testStep, string message)
        {
            this.AssertLogger.LogFail(testStep, message);
            return true;
        }
    }
}
