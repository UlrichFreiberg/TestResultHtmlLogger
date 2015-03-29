using System;
using System.IO;

namespace Stf.Utilities.TestResultHtmlLogger
{
    internal class LogfileWriter
    {
        private StreamWriter Stream { set; get; }
        public String LogFileName { set; get; }
        public Boolean Initialized{ set; get; }

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
            if (Initialized)
            {
                Close();
            }

            /*       LogToFile = False */

            /* Normalize value filename
             * if new file, then close the old file 
             * open new file - respect the overwritefileflag
            */

            Stream = new StreamWriter(LogFileName) {AutoFlush = true};
            Initialized = true;
            return true;
        }

        public Boolean Close()
        {
            if (Initialized)
            {
                Stream.Close();
            }

            Initialized = false;
            return true;
            /*       LogToFile = False */
        }
    }
}
