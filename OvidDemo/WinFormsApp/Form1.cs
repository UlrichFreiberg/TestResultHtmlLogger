// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace WinFormsApp
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using Stf.Utilities.StfAssert;
    using Stf.Utilities.TestResultHtmlLogger;
    using Stf.Utilities.TestResultHtmlLogger.Interfaces;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The logfile name.
        /// </summary>
        private const string LogfileName = @"c:\temp\OvidDemo.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            this.Mylogger = new TestResultHtmlLogger(LogfileName);
            this.MyAssert = new StfAssert(this.Mylogger);

            this.Mylogger.LogInfo("logFile opened from constructor");
        }

        /// <summary>
        /// Gets and sets The i.
        /// </summary>
        public int SomeCounter { get; private set; }

        /// <summary>
        /// Gets The mylogger.
        /// </summary>
        public TestResultHtmlLogger Mylogger { get; private set; }

        /// <summary>
        /// Gets The my assert.
        /// </summary>
        public StfAssert MyAssert { get; private set; }

        /// <summary>
        /// The button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogFunctionEnter(LogLevel.Info, "Void", "button1_Click");
            this.Mylogger.LogInfo("Someone press the button");
            this.Mylogger.LogFunctionExit(LogLevel.Info, "button1_Click");
        }

        /// <summary>
        /// The add one.
        /// </summary>
        private void AddOne()
        {
            this.Mylogger.LogFunctionEnter(LogLevel.Debug, "Void", "button1_Click");
            this.SomeCounter++;
            this.Mylogger.LogFunctionExit(LogLevel.Debug, "button1_Click");            
        }

        /// <summary>
        /// The button 2_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(LogfileName);
        }

        /// <summary>
        /// The btn exit_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
