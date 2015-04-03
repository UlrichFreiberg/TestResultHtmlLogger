// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace WinFormsApp
{
    using System;
    using System.Diagnostics;
    using System.Drawing.Text;
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
            this.Mylogger.LogLevel = LogLevel.Trace;
 
            this.Mylogger.LogInfo("logFile opened from DemoApp constructor");
            this.TxtMessage.Text = @"Some test message";
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
        private void BtnCallStackDemo_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogFunctionEnter(LogLevel.Info, "Void", "BtnCallStackDemo_Click");
            this.Mylogger.LogInfo("Someone pressed the CallStackDemo button");
            callStackDemo("Demo");
            this.Mylogger.LogFunctionExit(LogLevel.Info, "BtnCallStackDemo_Click");
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
        private void BtnShowLogFile_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogInfo_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogInfo("Info: " + this.TxtMessage.Text);
        }

        private void btnLogTrace_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogTrace("Info: " + this.TxtMessage.Text);
        }

        private void btnLogPass_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogPass("OvidDemo", this.TxtMessage.Text);
        }

        private void btnLogFail_Click(object sender, EventArgs e)
        {
            this.Mylogger.LogFail("OvidDemo", this.TxtMessage.Text);
        }

        private int callStackDemo(string argument)
        {
            var retVal = 40;

            this.Mylogger.LogFunctionEnter(LogLevel.Debug, "Void", "callStackDemo");
            this.Mylogger.LogInfo(string.Format("SomeCounter is [{0}]", this.SomeCounter++));
            this.callStackDemoL1("From Demo");
            this.callStackDemoL1("From Demo");

            this.Mylogger.LogFunctionExit(LogLevel.Debug, "callStackDemo");                        
            return retVal;
        }

        private int callStackDemoL1(string argument)
        {
            var retVal = 41;

            this.Mylogger.LogFunctionEnter(LogLevel.Debug, "Void", "callStackDemoL1");
            this.Mylogger.LogInfo(string.Format("SomeCounter is [{0}]", this.SomeCounter++));
            this.callStackDemoL2("From Demo1");
            this.callStackDemoL2("From Demo1");
            this.Mylogger.LogFunctionExit(LogLevel.Debug, "callStackDemoL1");
            return retVal;
        }

        private int callStackDemoL2(string argument)
        {
            var retVal = 42;

            this.Mylogger.LogFunctionEnter(LogLevel.Debug, "Void", "callStackDemoL2");
            this.Mylogger.LogInfo(string.Format("SomeCounter is [{0}]", this.SomeCounter++));
            this.Mylogger.LogFunctionExit(LogLevel.Debug, "callStackDemoL2");
            return retVal;
        }
    }
}
