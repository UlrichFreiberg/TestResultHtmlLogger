using System;
using System.IO;

namespace Stf.Utilities.TestResultHtmlLogger
{
    internal class LogfileWriter
    {
        public StreamWriter Stream { set; get; }
        public String LogFileName { set; get; }
        private Boolean _initialized;

        public Boolean Write(String stuffToWrite)
        {
            Stream.Write(stuffToWrite);
            return true;
        }

        public Boolean Open(String fileName)
        {
            LogFileName = fileName;
            return Open();
        }

        public Boolean Open()
        {
            if (_initialized)
            {
                Close();
            }

            /*       LogToFile = False */

            /* Normalize value filename
             * if new file, then close the old file 
             * open new file - respect the overwritefileflag
             * 
                 
             * LogToFile = True
            */

            Stream = new StreamWriter(LogFileName) {AutoFlush = true};
            _initialized = true;
            return true;
        }

        public Boolean Close()
        {
            if (_initialized)
            {
                Stream.Close();
            }

            _initialized = false;
            return true;
            /*       LogToFile = False */
        }
    }
}
