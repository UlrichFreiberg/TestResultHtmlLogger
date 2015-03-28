using System;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILoggingFunctions
    {
        int _messageId = 0;
        String GetNextMessageId()
        {
            return string.Format("m{0}", _messageId++);
        }

        int LogOneHtmlMessage(LogLevel logLevel, string message)
        {
            string htmlLine, logLevelString;
            string indentString;
            string messageIdString;

            if (! _addLoglevelToRunReport[logLevel]) {
                return -1;
            }

            messageIdString = GetNextMessageId();
            logLevelString = Enum.GetName(typeof(LogLevel), logLevel);
            CheckForPerformanceAlert();

            // TODO need some info from LogFunctionEnter/Exit, to set the indentation right
            indentString = "";

            switch (logLevel)
            {
                case LogLevel.Header:
                    htmlLine = string.Format("<div class=\"line logheader\">{0}</div>\n", message);
                    break;
                case LogLevel.SubHeader:
                    htmlLine = string.Format("<div class=\"line logsubheader\">{0}</div>\n", message);
                    break;

              default:
                    htmlLine = String.Format("<div onclick=\"sa('{0}')\" id=\"{0}\" class=\"line {1} \">\n", messageIdString, logLevelString.ToLower());
                    htmlLine += String.Format("    <div class=\"el time\">{0}</div>\n", _timeOfLastMessage.ToString("HH:mm:ss"));
                    htmlLine += String.Format("    <div class=\"el level\">{0}</div>\n", logLevelString);
                    htmlLine += String.Format("    <div class=\"el pad\">{0}</div>\n", indentString);
                    htmlLine += String.Format("    <div class=\"el msg\">{0}</div>\n", message);
                    htmlLine += String.Format("</div>\n");
                    break;
            }

            _logFileHandle.Write(htmlLine);
            _logFileHandle.Flush();
            return htmlLine.Length;
        }

        // =============================================================
        //
        // normal logging functions - testscripts/models/adapters
        //
        // =============================================================
        public int LogError(string message)
        {
            return LogOneHtmlMessage(LogLevel.Error, message);
        }

        public int Error(string message)
        {
            return LogError(message);
        }

        public int LogWarning(string message)
        {
            return LogOneHtmlMessage(LogLevel.Warning, message);
        }

        public int Warning(string message)
        {
            return LogWarning(message);
        }

        public int LogInfo(string message)
        {
            return LogOneHtmlMessage(LogLevel.Info, message);
        }

        public int Info(string message)
        {
            return LogInfo(message);
        }

        public int LogDebug(string message)
        {
            return LogOneHtmlMessage(LogLevel.Debug, message);
        }

        public int Debug(string message)
        {
            return LogDebug(message);
        }

        public int LogTrace(string message)
        {
            return LogOneHtmlMessage(LogLevel.Trace, message);
        }

        public int Trace(string message)
        {
            return LogTrace(message);
        }

        // =============================================================
        //
        // Header logging functions - testscripts
        //
        // =============================================================

        public int LogHeader(string message)
        {
            return LogOneHtmlMessage(LogLevel.Header, message);
        }

        public int Header(string message)
        {
            return LogHeader(message);
        }

        public int LogSubHeader(string message)
        {
            return LogOneHtmlMessage(LogLevel.SubHeader, message);
        }

        public int SubHeader(string message)
        {
            return LogSubHeader(message);
        }

        // =============================================================
        //
        // normal logging functions - models and adapters
        //
        // =============================================================

        public int LogInternal(string message)
        {
            return LogOneHtmlMessage(LogLevel.Internal, message);
        }

        public int Internal(string message)
        {
            return LogInternal(message);
        }

        // =============================================================
        //
        // used solely by Assert functions
        //
        // =============================================================
        public int LogPass(string testStepName, string message)
        {
            var tempNeedsToBeReworkedMessage = string.Format("TestStepName=[{0}], message=[{1}]", testStepName, message);

            return LogOneHtmlMessage(LogLevel.Pass, tempNeedsToBeReworkedMessage);
        }

        public int Pass(string testStepName, string message)
        {
            return LogPass(testStepName, message);
        }

        public int LogFail(string testStepName, string message)
        {
            var tempNeedsToBeReworkedMessage = string.Format("TestStepName=[{0}], message=[{1}]", testStepName, message);

            return LogOneHtmlMessage(LogLevel.Fail, tempNeedsToBeReworkedMessage);
        }

        public int Fail(string testStepName, string message)
        {
            return LogFail(testStepName, message);
        }

        public int LogKeyValue(string key, string value, string message)
        {
            String htmlLine; 

            htmlLine = string.Format("<div class=\"line keyvalue\">\n");
            htmlLine += string.Format("   <div class=\"el key\">{0}</div>\n", key);
            htmlLine += string.Format("   <div class=\"el value\">{0}</div>\n", value);
            htmlLine += string.Format("   <div class=\"el msg\">{0}</div>\n", message);
            htmlLine += string.Format("</div>\n");

            _logFileHandle.Write(htmlLine);
            _logFileHandle.Flush();
            return htmlLine.Length;
        }
    }
}
