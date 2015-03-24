using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILogfileManagement
    {
        ~TestResultHtmlLogger()
        {
            //logFileHandle.Close();
        }

        public LogConfiguration Configuration = new LogConfiguration();

        StreamWriter logFileHandle;

        /// <summary>
        /// Do we log for a given loglevel?
        /// </summary>
        Dictionary<LogLevel, Boolean> AddLoglevelToRunReport;

        /// <summary>
        /// NumberOfLoglevelMessages - to the finishing TestStatus
        /// </summary>
        Dictionary<LogLevel, int> NumberOfLoglevelMessages;

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
        Dictionary<string, string> LogInfoDetails;

        /// <summary>
        /// Title
        /// </summary>
        string LogTitle { get; set; }

        string mLogFileName;
        /// <summary>
        /// Path to the resulting logfile
        /// </summary>
        string LogFileName
        {
            get
            {
                return mLogFileName;
            }
            set
            {
                mLogFileName = value;
                BeginHtmlLogFile(LogFileName);
            }
        }

        LogLevel mLogLevel;
        /// <summary>
        /// What level should the logger accept logging for. Lower levels than this will be ignored - as "trace" will be ignored is level is set to "debug"
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return mLogLevel;
            }

            set
            {
                mLogLevel = value;
                TimeOfLastMessage = DateTime.Now;

                //TODO: Should go to a contructor
                AddLoglevelToRunReport = new Dictionary<LogLevel, bool>();
                NumberOfLoglevelMessages = new Dictionary<LogLevel, int>();

                foreach (LogLevel loglevel in Enum.GetValues(typeof(LogLevel)))
                {
                    NumberOfLoglevelMessages.Add(loglevel, 0);
                    AddLoglevelToRunReport.Add(loglevel, true);
                }

                switch (value)
                {
                    case LogLevel.Error:
                        AddLoglevelToRunReport[LogLevel.Warning] = false;
                        AddLoglevelToRunReport[LogLevel.Info] = false;
                        AddLoglevelToRunReport[LogLevel.Debug] = false;
                        AddLoglevelToRunReport[LogLevel.Trace] = false;
                        AddLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Warning:
                        AddLoglevelToRunReport[LogLevel.Info] = false;
                        AddLoglevelToRunReport[LogLevel.Debug] = false;
                        AddLoglevelToRunReport[LogLevel.Trace] = false;
                        AddLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Info:
                        AddLoglevelToRunReport[LogLevel.Debug] = false;
                        AddLoglevelToRunReport[LogLevel.Trace] = false;
                        AddLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Debug:
                        AddLoglevelToRunReport[LogLevel.Trace] = false;
                        AddLoglevelToRunReport[LogLevel.Internal] = false;
                        break;
                    case LogLevel.Trace:
                        AddLoglevelToRunReport[LogLevel.Internal] = false;
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
            String RetVal;
            var styleSheet = Properties.Resources.ResourceManager.GetObject("logger");

            RetVal = styleSheet.ToString();

            return RetVal;
        }

        

        /// <summary>
        ///   reads in the HTML that constitoes the top LogHeader
        /// </summary>
        /// <returns></returns>
        string GetOpenBody()
        {
            String RetVal;
            var openBody = Properties.Resources.ResourceManager.GetObject("OpenBody");

            RetVal = openBody.ToString();
            return RetVal;
        }

        /// <summary>
        ///   reads in the CSS 
        /// </summary>
        /// <returns></returns>
        string GetStyleSheet()
        {
            String RetVal;
            var styleSheet = Properties.Resources.ResourceManager.GetObject("style");

            RetVal = styleSheet.ToString();

            return RetVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        Boolean BeginHtmlLogFile(string FileName)
        {
            String HtmlLine;

            if (logFileHandle != null)
            {
                logFileHandle.Close();
            }

            logFileHandle = new StreamWriter(LogFileName);

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

            HtmlLine = "<!DOCTYPE html>\n";
            HtmlLine += "<html>\n";
            HtmlLine += "  <head>\n";
            HtmlLine += "    <title>Ulrich Og Kasper</title>\n";
            HtmlLine += "    <style type=\"text/css\">\n";
            HtmlLine += GetStyleSheet();
            HtmlLine += "    </style>\n<script type=\"text/javascript\">";
            HtmlLine += GetJavaScript();
            HtmlLine += "  </script>\n</head>\n";
            HtmlLine += GetOpenBody();

            logFileHandle.Write(HtmlLine);
            logFileHandle.Flush();
            return true;
        }

        Boolean EndHtmlLogFile()
        {
            String HtmlLine;

            HtmlLine = "  </body>\n";
            HtmlLine += "</html>\n";

            logFileHandle.Write(HtmlLine);
            logFileHandle.Flush();
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
