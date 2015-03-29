using System;
using System.Collections.Generic;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;
using Stf.Utilities.TestResultHtmlLogger.Properties;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILogfileManagement
    {
        ~TestResultHtmlLogger()
        {
            _logFileHandle.Close();
        }

        public LogConfiguration Configuration = new LogConfiguration();

        LogfileWriter _logFileHandle = new LogfileWriter();

        /// <summary>
        /// Do we log for a given loglevel?
        /// </summary>
        Dictionary<LogLevel, Boolean> _addLoglevelToRunReport;

        /// <summary>
        /// NumberOfLoglevelMessages - to the finishing TestStatus
        /// </summary>
        Dictionary<LogLevel, int> _numberOfLoglevelMessages;

        /// <summary>
        /// Logging disabled until LogFile property is set. />
        /// </summary>
        public Boolean LogToFile { get; set; }

        /// <summary>
        /// If logfile exists overwrite it.
        /// </summary>
        Boolean OverwriteLogFile { get; set; }

        /// <summary>
        /// Details about Environment, Test Agent (the current machine - OS, versions of Software), Date
        /// </summary>
        Dictionary<string, string> _logInfoDetails;

        /// <summary>
        /// Title
        /// </summary>
        string LogTitle { get; set; }

        string _mFileName;
        /// <summary>
        /// Path to the resulting logfile
        /// </summary>
        public string FileName
        {
            get
            {
                return _mFileName;
            }
            set
            {
                _mFileName = value;
                if (!Init(FileName))
                {
                    Console.WriteLine(@"Coulnd't initialise the logfile");
                }
            }
        }

        LogLevel _mLogLevel;
        /// <summary>
        /// What level should the logger accept logging for. Lower levels than this will be ignored - as "trace" will be ignored is level is set to "debug"
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return _mLogLevel;
            }

            set
            {
                _mLogLevel = value;
                _timeOfLastMessage = DateTime.Now;

                //TODO: Should go to a contructor
                _addLoglevelToRunReport = new Dictionary<LogLevel, bool>();
                _numberOfLoglevelMessages = new Dictionary<LogLevel, int>();

                foreach (LogLevel loglevel in Enum.GetValues(typeof(LogLevel)))
                {
                    _numberOfLoglevelMessages.Add(loglevel, 0);
                    _addLoglevelToRunReport.Add(loglevel, true);
                }

                switch (value)
                {
                    case LogLevel.Error:
                        _addLoglevelToRunReport[LogLevel.Warning] = false;
                        _addLoglevelToRunReport[LogLevel.Info] = false;
                        _addLoglevelToRunReport[LogLevel.Debug] = false;
                        _addLoglevelToRunReport[LogLevel.Trace] = false;
                        _addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Warning:
                        _addLoglevelToRunReport[LogLevel.Info] = false;
                        _addLoglevelToRunReport[LogLevel.Debug] = false;
                        _addLoglevelToRunReport[LogLevel.Trace] = false;
                        _addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Info:
                        _addLoglevelToRunReport[LogLevel.Debug] = false;
                        _addLoglevelToRunReport[LogLevel.Trace] = false;
                        _addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Debug:
                        _addLoglevelToRunReport[LogLevel.Trace] = false;
                        _addLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Trace:
                        _addLoglevelToRunReport[LogLevel.Internal] = false;
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
        string ArchiveDirecory { get; set; }

        /// <summary>
        /// Should we archive the logfile
        /// </summary>
        Boolean ArchiveLogFile { get; set; }

        /// <summary>
        ///   reads in the JavaScript functions for the logfile buttons etc
        /// </summary>
        /// <returns></returns>
        string GetJavaScript()
        {
            String retVal;
            var styleSheet = Resources.ResourceManager.GetObject("logger");

            retVal = styleSheet.ToString();

            return retVal;
        }

        

        /// <summary>
        ///   reads in the HTML that constitoes the top LogHeader
        /// </summary>
        /// <returns></returns>
        string GetOpenBody()
        {
            String retVal;
            var openBody = Resources.ResourceManager.GetObject("OpenBody");

            retVal = openBody.ToString();
            return retVal;
        }

        /// <summary>
        ///   reads in the CSS 
        /// </summary>
        /// <returns></returns>
        string GetStyleSheet()
        {
            String retVal;
            var styleSheet = Resources.ResourceManager.GetObject("style");

            retVal = styleSheet.ToString();

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Boolean BeginHtmlLogFile(string fileName)
        {
            String htmlLine;

            _logFileHandle.Open(fileName);

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

            _logFileHandle.Write(htmlLine);
            return true;
        }

        Boolean EndHtmlLogFile()
        {
            String htmlLine;

            htmlLine = "  </body>\n";
            htmlLine += "</html>\n";

            _logFileHandle.Write(htmlLine);
            return true;
        }

        int IncrementImgCount()
        {
            throw new NotImplementedException();
        }

        public int CurrentLogLevel { get; set; }
        public int BuildArchiveLogFilePath { get; set; }
        public int LocalLogFileName { get; set; }

        /// <summary>
        /// Initialise a logger
        /// </summary>
        /// <param name="logFileName"></param>
        /// <returns></returns>
        private Boolean Init(string logFileName)
        {
            var userName = String.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);

            OverwriteLogFile = Configuration.OverwriteLogFile;
            TestName = "TestName_Not_Set";
            LogToFile = Configuration.LogToFile;
            LogTitle = Configuration.LogTitle;
            LogLevel = Configuration.LogLevel;

            // If no valid logfilename is given, then go for the configured value
            if (String.IsNullOrEmpty(logFileName))
            {
                FileName = Configuration.LogFileName;                
            }

            if (_logFileHandle.Initialized)
            {
                EndHtmlLogFile();
                _logFileHandle.Close();
            }

            if (!_logFileHandle.Open(logFileName))
            {
                return false;
            }

            if (!BeginHtmlLogFile(logFileName))
            {
                return false;                
            }

            LogKeyValue("Environment", "TODO_ENVIRONMENT", "Configuration.EnvironmentName");
            LogKeyValue("OS", Environment.OSVersion.ToString(), "");
            LogKeyValue("User", userName, "");
            LogKeyValue("InstDir", Environment.CurrentDirectory, "TODO_InstDir");
            LogKeyValue("ResultDir", Environment.CurrentDirectory, "TODO_ResultDir");
            LogKeyValue("Controller", Environment.MachineName, "TODO_Controller");
            LogKeyValue("Hostname", Environment.MachineName, "TODO_Hostname");
            LogKeyValue("TestDir", Environment.CurrentDirectory, "TODO_TestDir");
            LogKeyValue("Test Iteration", "TODO_Test Iteration", "TODO_Test Iteration");
            LogKeyValue("Testname", TestName, "TODO_Testname");
            LogKeyValue("Date", DateTime.Now.ToShortDateString(), "");

            LogTrace(String.Format("Log Initiated at [{0}]", FileName));
            return true;
        }

        // =============================================================
        // Have we logged a Error or Fail? 
        // =============================================================
        public int ErrorOrFail()
        {
            throw new NotImplementedException();
        }

        public int CloseLogFile()
        {
            throw new NotImplementedException();
        }

        public int ArchiveThisLogFile()
        {
            throw new NotImplementedException();
        }
    }
}
