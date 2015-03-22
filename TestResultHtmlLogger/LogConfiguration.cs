using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public class LogConfiguration
    {
        public Boolean OverwriteLogFile { get; set; }
        public Boolean LogToFile { get; set; }
        public String LogTitle { get; set; }
        public String LogFileName { get; set; }
        public int AlertLongInterval { get; set; }
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Standard constructor - sets up default configuration... 
        /// TODO:Later YACF kicks in..
        /// </summary>
        public LogConfiguration()
        {
            OverwriteLogFile = true;
            LogToFile = false;
            LogTitle = "A Working Title";
            LogFileName = @"C:\temp\TestResultHtmlLogger.html";
            AlertLongInterval = 10000;
            LogLevel = LogLevel.Error;
        }
    }
}
