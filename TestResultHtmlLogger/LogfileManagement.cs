// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogfileManagement.cs" company="Foobar">
//   2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Stf.Utilities.TestResultHtmlLogger
{
    using System;
    using System.Collections.Generic;

    using Stf.Utilities.TestResultHtmlLogger.Interfaces;
    using Stf.Utilities.TestResultHtmlLogger.Properties;

    /// <summary>
    /// The test result html logger. the <see cref="ILogfileManagement"/> part
    /// </summary>
    public partial class TestResultHtmlLogger : ILogfileManagement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultHtmlLogger"/> class.
        /// </summary>
        /// <param name="archiveLogFile">
        /// The archive log file.
        /// </param>
        public TestResultHtmlLogger(bool archiveLogFile)
        {
            this.ArchiveLogFile = archiveLogFile;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultHtmlLogger"/> class.
        /// </summary>
        public TestResultHtmlLogger()
        {
        }

        /// <summary>
        /// The configuration.
        /// </summary>
        public LogConfiguration Configuration = new LogConfiguration();

        /// <summary>
        /// The _log file handle.
        /// </summary>
        private readonly LogfileWriter logFileHandle = new LogfileWriter();

        /// <summary>
        /// Do we log for a given log level?
        /// </summary>
        private Dictionary<LogLevel, bool> addLoglevelToRunReport;

        /// <summary>
        /// NumberOfLoglevelMessages - to the finishing TestStatus
        /// </summary>
        public Dictionary<LogLevel, int> NumberOfLoglevelMessages;

        /// <summary>
        /// Logging disabled until LogFile property is set. />
        /// </summary>
        private bool LogToFile { get; set; }

        /// <summary>
        /// If logfile exists overwrite it.
        /// </summary>
        private bool OverwriteLogFile { get; set; }

        /// <summary>
        /// Details about Environment, Test Agent (the current machine - OS, versions of Software), Date
        /// </summary>
        public Dictionary<string, string> LogInfoDetails;

        /// <summary>
        /// Title
        /// </summary>
        public string LogTitle { get; set; }

        /// <summary>
        /// The _m file name.
        /// </summary>
        private string mFileName;

        /// <summary>
        /// Gets or sets the path to the resulting logfile
        /// </summary>
        public string FileName
        {
            get
            {
                return this.mFileName;
            }

            set
            {
                this.mFileName = value;
                if (!Init(FileName))
                {
                    Console.WriteLine(@"Coulnd't initialise the logfile");
                }
            }
        }

        /// <summary>
        /// The _m log level.
        /// </summary>
        LogLevel mLogLevel;


        /// <summary>
        /// What level should the logger accept logging for. Lower levels than this will be ignored - as "trace" will be ignored is level is set to "debug"
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return this.mLogLevel;
            }

            set
            {
                this.mLogLevel = value;
                this.timeOfLastMessage = DateTime.Now;

                // TODO: Should go to a contructor
                this.addLoglevelToRunReport = new Dictionary<LogLevel, bool>();
                this.NumberOfLoglevelMessages = new Dictionary<LogLevel, int>();

                foreach (LogLevel loglevel in Enum.GetValues(typeof(LogLevel)))
                {
                    this.NumberOfLoglevelMessages.Add(loglevel, 0);
                    this.addLoglevelToRunReport.Add(loglevel, true);
                }

                switch (value)
                {
                    case LogLevel.Error:
                        this.addLoglevelToRunReport[LogLevel.Warning] = false;
                        this.addLoglevelToRunReport[LogLevel.Info] = false;
                        this.addLoglevelToRunReport[LogLevel.Debug] = false;
                        this.addLoglevelToRunReport[LogLevel.Trace] = false;
                        this.addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Warning:
                        this.addLoglevelToRunReport[LogLevel.Info] = false;
                        this.addLoglevelToRunReport[LogLevel.Debug] = false;
                        this.addLoglevelToRunReport[LogLevel.Trace] = false;
                        this.addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Info:
                        this.addLoglevelToRunReport[LogLevel.Debug] = false;
                        this.addLoglevelToRunReport[LogLevel.Trace] = false;
                        this.addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Debug:
                        this.addLoglevelToRunReport[LogLevel.Trace] = false;
                        this.addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Trace:
                        this.addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Internal:
                        break;
                    default:

                        // logError
                        break;
                }
            }
        }

        /// <summary>
        /// If the logfile should be archived - to where should it be archived
        /// </summary>
        public string ArchiveDirecory { get; set; }

        /// <summary>
        /// Should we archive the logfile
        /// </summary>
        public bool ArchiveLogFile { get; set; }

        /// <summary>
        ///   reads in the JavaScript functions for the logfile buttons etc
        /// </summary>
        /// <returns>A string representing the JS that controls the logger</returns>
        private string GetJavaScript()
        {
            string retVal;
            var loggerJs = Resources.ResourceManager.GetObject("logger");

            if (loggerJs == null)
            {
                retVal = "<error>No Logger JS section defined</error>";
            }
            else
            {
                retVal = loggerJs.ToString();
            }

            return retVal;
        }



        /// <summary>
        ///   reads in the HTML that constitutes the top LogHeader
        /// </summary>
        /// <returns>A Html string representing the start of the Body for the logger</returns>
        private string GetOpenBody()
        {
            string retVal;
            var openBody = Resources.ResourceManager.GetObject("OpenBody");

            if (openBody == null)
            {
                retVal = "<error>No OpenBody section file found</error>";
            }
            else
            {
                retVal = openBody.ToString();
            }

            return retVal;
        }

        /// <summary>
        ///   reads in the CSS 
        /// </summary>
        /// <returns>A string representing the CSS that controls the logger</returns>
        private string GetStyleSheet()
        {
            string retVal;
            var styleSheet = Resources.ResourceManager.GetObject("style");

            if (styleSheet == null)
            {
                retVal = "<error>No styleSheet file found</error>";
            }
            else
            {
                retVal = styleSheet.ToString();
            }

            return retVal;
        }

        /// <summary>
        /// Open and Start the logger
        /// </summary>
        /// <param name="fileName">
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// private
        private bool BeginHtmlLogFile(string fileName)
        {
            string htmlLine;

            this.logFileHandle.Open(fileName);

            htmlLine = "<!DOCTYPE html>\n";
            htmlLine += "<html>\n";
            htmlLine += "  <head>\n";
            htmlLine += "    <title>Ulrich Og Kasper</title>\n";
            htmlLine += "    <style type=\"text/css\">\n";
            htmlLine += GetStyleSheet();
            htmlLine += "    </style>\n<script type=\"text/javascript\">";
            htmlLine += GetJavaScript();
            htmlLine += "  </script>\n</head>\n";
            htmlLine += GetOpenBody();

            this.logFileHandle.Write(htmlLine);
            return true;
        }

        /// <summary>
        /// End html log file.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EndHtmlLogFile()
        {
            string htmlLine;

            htmlLine = "  </body>\n";
            htmlLine += "</html>\n";

            this.logFileHandle.Write(htmlLine);
            return true;
        }

        /// <summary>
        /// The increment img count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        int IncrementImgCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the current log level.
        /// </summary>
        public int CurrentLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the build archive log file path.
        /// </summary>
        public int BuildArchiveLogFilePath { get; set; }

        /// <summary>
        /// Gets or sets the local log file name.
        /// </summary>
        public int LocalLogFileName { get; set; }

        /// <summary>
        /// initialize a logger
        /// </summary>
        /// <param name="logFileName">
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Init(string logFileName)
        {
            var userName = string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);

            OverwriteLogFile = Configuration.OverwriteLogFile;
            TestName = "TestName_Not_Set";
            LogToFile = Configuration.LogToFile;
            LogTitle = Configuration.LogTitle;
            LogLevel = Configuration.LogLevel;

            // If no valid logfilename is given, then go for the configured value
            if (string.IsNullOrEmpty(logFileName))
            {
                FileName = Configuration.LogFileName;
            }

            if (this.logFileHandle.Initialized)
            {
                this.CloseLogFile();
            }

            if (!this.logFileHandle.Open(logFileName))
            {
                return false;
            }

            if (!BeginHtmlLogFile(logFileName))
            {
                return false;
            }

            LogKeyValue("Environment", "TODO_ENVIRONMENT", "Configuration.EnvironmentName");
            LogKeyValue("OS", Environment.OSVersion.ToString(), string.Empty);
            LogKeyValue("User", userName, string.Empty);
            LogKeyValue("InstDir", Environment.CurrentDirectory, "TODO_InstDir");
            LogKeyValue("ResultDir", Environment.CurrentDirectory, "TODO_ResultDir");
            LogKeyValue("Controller", Environment.MachineName, "TODO_Controller");
            LogKeyValue("Hostname", Environment.MachineName, "TODO_Hostname");
            LogKeyValue("TestDir", Environment.CurrentDirectory, "TODO_TestDir");
            LogKeyValue("Test Iteration", "TODO_Test Iteration", "TODO_Test Iteration");
            LogKeyValue("Testname", TestName, "TODO_Testname");
            LogKeyValue("Date", DateTime.Now.ToShortDateString(), string.Empty);

            LogTrace(string.Format("Log Initiated at [{0}]", FileName));
            return true;
        }

        /// <summary>
        /// Have we logged a Error or Fail? 
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int ErrorOrFail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The close log file.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CloseLogFile()
        {
            EndHtmlLogFile();
            return this.logFileHandle.Close();
        }

        /// <summary>
        /// The archive this log file.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int ArchiveThisLogFile()
        {
            throw new NotImplementedException();
        }
    }
}
