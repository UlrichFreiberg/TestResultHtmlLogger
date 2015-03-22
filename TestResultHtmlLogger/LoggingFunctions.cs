using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILoggingFunctions
    {
        int messageId = 0;

        int LogOneHtmlMessage(LogLevel logLevel, string Message)
        {
            string HtmlLine, LogLevelString;
            string IndentString;
            string messageIdString;

            if (! AddLoglevelToRunReport[logLevel]) {
                return -1;
            }
            
            messageIdString = string.Format("m{0}", messageId++);
            LogLevelString = Enum.GetName(typeof(LogLevel), logLevel);
            CheckForPerformanceAlert();

            // TODO need some info from LogFunctionEnter/Exit, to set the indentation right
            IndentString = "";

            switch (logLevel)
            {
                case LogLevel.Header:
                    HtmlLine = string.Format("<div class=\"line logheader\">{0}</div>", Message);
                    break;
                case LogLevel.SubHeader:
                    HtmlLine = string.Format("<div class=\"line logsubheader\">{0}</div>", Message);
                    break;

                default:
                    HtmlLine = String.Format("<div onclick=\"sa('{0}')\" id=\"{0}\" class=\"line {1} \">\n", messageIdString, LogLevelString);
                    HtmlLine += String.Format("    <div class=\"el time\">{0}</div>\n", TimeOfLastMessage);
                    HtmlLine += String.Format("    <div class=\"el level\">{0}</div>\n", LogLevelString);
                    HtmlLine += String.Format("    <div class=\"el pad\">{0}</div>\n", IndentString);
                    HtmlLine += String.Format("    <div class=\"el msg\">{0}</div>\n", Message);
                    HtmlLine += String.Format("</div>");
                    break;
            }

            logFileHandle.Write(HtmlLine);
            logFileHandle.Flush();
            return HtmlLine.Length;
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
        // normal logging functions - models and adapters
        //
        // =============================================================

        public int LogInternal(string message)
        {
            return LogOneHtmlMessage(LogLevel.Trace, message);
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
            var TempNeedsToBeReworkedMessage = string.Format("PASS - testStepName=[{0}], message=[{1}]", testStepName, message);

            return LogOneHtmlMessage(LogLevel.Pass, TempNeedsToBeReworkedMessage);
        }

        public int Pass(string testStepName, string message)
        {
            return LogPass(testStepName, message);
        }

        public int LogFail(string testStepName, string message)
        {
            var TempNeedsToBeReworkedMessage = string.Format("FAIL - testStepName=[{0}], message=[{1}]", testStepName, message);

            return LogOneHtmlMessage(LogLevel.Fail, message);
        }

        public int Fail(string testStepName, string message)
        {
            return LogFail(testStepName, message);
        }

        public int LogKeyValue(string key, string value, string message)
        {
            var TempNeedsToBeReworkedMessage = string.Format("Message=[{0}], Key=[{1}], Value=[{2}]", message, key, value);

            return LogOneHtmlMessage(LogLevel.KeyValue, TempNeedsToBeReworkedMessage);
        }
    }
}
