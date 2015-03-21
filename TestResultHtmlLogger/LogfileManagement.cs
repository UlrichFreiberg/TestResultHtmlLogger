using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILogfileManagement
    {
        // reads in the JavaScript functions for the logfile buttons etc
        string GetJavaScript()
        {
            throw new NotImplementedException();
        }

        // reads in the CSS 
        string GetStyleSheet()
        {
            throw new NotImplementedException();
        }

        Boolean BeginHtmlLogFile(string FileName)
        {
            throw new NotImplementedException();
        }

        Boolean EndHtmlLogFile()
        {
            throw new NotImplementedException();
        }

        int IncrementMessageCount()
        {
            throw new NotImplementedException();
        }

        int IncrementPassCount()
        {
            throw new NotImplementedException();
        }

        int IncrementFailCount()
        {
            throw new NotImplementedException();
        }

        int IncrementErrorCount()
        {
            throw new NotImplementedException();
        }

        int IncrementWarnCount()
        {
            throw new NotImplementedException();
        }

        int IncrementInfoCount()
        {
            throw new NotImplementedException();
        }

        int IncrementDebugCount()
        {
            throw new NotImplementedException();
        }

        int IncrementTraceCount()
        {
            throw new NotImplementedException();
        }

        int IncrementInternalCount()
        {
            throw new NotImplementedException();
        }

        int IncrementImgCount()
        {
            throw new NotImplementedException();
        }

        int IncrementKeyValue()
        {
            throw new NotImplementedException();
        }

        public int CurrentLogLevel { get; set; }
        public int BuildArchiveLogFilePath { get; set; }
        public int LocalLogFileName { get; set; }

        int ILogfileManagement.Init(string logFileName)
        {
            throw new NotImplementedException();
        }

        // =============================================================
        // Have we logged a Error or Fail? 
        // =============================================================
        int ILogfileManagement.ErrorOrFail()
        {
            throw new NotImplementedException();
        }

        int ILogfileManagement.CloseLogFile()
        {
            throw new NotImplementedException();
        }

        int ILogfileManagement.ArchiveThisLogFile()
        {
            throw new NotImplementedException();
        }
    }
}
