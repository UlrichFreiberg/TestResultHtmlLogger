using System;
using System.Collections.Generic;
using System.IO;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;
using Stf.Utilities.TestResultHtmlLogger.Properties;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILogfileManagement
    {
        ~TestResultHtmlLogger()
        {
            //logFileHandle.Close();
        }

        public LogConfiguration Configuration = new LogConfiguration();

        StreamWriter _logFileHandle;

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

        string _mLogFileName;
        /// <summary>
        /// Path to the resulting logfile
        /// </summary>
        string LogFileName
        {
            get
            {
                return _mLogFileName;
            }
            set
            {
                _mLogFileName = value;
                BeginHtmlLogFile(LogFileName);
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

            if (_logFileHandle != null)
            {
                _logFileHandle.Close();
            }

            _logFileHandle = new StreamWriter(LogFileName);

            /*  if value is nullOrEmpty we want to close the file
             *       Close the currently opened log file.
             *       LogToFile = False
             *       LogFileName = String.Empty
             *       return
             * endif
             *  
             * Normalize value filename
             * if new file, then close the old file 
             * open new file - respect the overwritefileflag
             * 
                 
             * LogToFile = True
            */

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
            _logFileHandle.Flush();
            return true;
        }

        Boolean EndHtmlLogFile()
        {
            String htmlLine;

            htmlLine = "  </body>\n";
            htmlLine += "</html>\n";

            _logFileHandle.Write(htmlLine);
            _logFileHandle.Flush();
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
        public Boolean Init(string logFileName)
        {
            OverwriteLogFile = Configuration.OverwriteLogFile;
            TestName = "TestName_Not_Set";
            LogToFile = Configuration.LogToFile;
            LogTitle = Configuration.LogTitle;
            LogLevel = Configuration.LogLevel;
            LogFileName = Configuration.LogFileName;

            LogKeyValue("Environment", "TODO_ENVIRONMENT", "Configuration.EnvironmentName");
            LogKeyValue("OS", "TODO_Windows OS", "");
            LogKeyValue("InstDir", "TODO_InstDir", "TODO_InstDir");
            LogKeyValue("ResultDir", "TODO_ResultDir", "TODO_ResultDir");
            LogKeyValue("Controller", "TODO_Controller", "TODO_Controller");
            LogKeyValue("Hostname", "TODO_Hostname", "TODO_Hostname");
            LogKeyValue("TestDir", "TODO_TestDir", "TODO_TestDir");
            LogKeyValue("Test Iteration", "TODO_Test Iteration", "TODO_Test Iteration");
            LogKeyValue("Testname", "TODO_Testname", "TODO_Testname");
            LogKeyValue("Date", DateTime.Now.ToShortDateString(), "");

            //LogFileName = NewLogFileName

            LogTrace(String.Format("Log Initiated at [{0}]", LogFileName));
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
