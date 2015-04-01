// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogfileWriter.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   Defines the LogfileWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Stf.Utilities.TestResultHtmlLogger
{
    using System.IO;

    /// <summary>
    /// The logfile writer.
    /// </summary>
    internal class LogfileWriter
    {
        /// <summary>
        /// Gets or sets the log file name.
        /// </summary>
        public string LogFileName { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not the logfile is initialized.
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// Gets or sets the stream.
        /// </summary>
        private StreamWriter Stream { get; set; }

        /// <summary>
        /// Writes a buffer of characters to the logfile.
        /// </summary>
        /// <param name="stuffToWrite">
        /// The stuff to write.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Write(string stuffToWrite)
        {
            if (this.Stream == null)
            {
                return false;
            }

            this.Stream.Write(stuffToWrite);
            return true;
        }

        /// <summary>
        /// Open a logfile stream - respects the OverWriteFlag (soon:-)).
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Open(string fileName)
        {
            LogFileName = fileName;
            return Open();
        }

        /// <summary>
        /// Open a logfile stream - respects the OverWriteFlag (soon:-)).
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Open()
        {
            if (this.Initialized)
            {
                this.Close();
            }

            /*       LogToFile = False */

            /* Normalize value filename
             * if new file, then close the old file 
             * open new file - respect the overwritefileflag
            */

            this.Stream = new StreamWriter(this.LogFileName) { AutoFlush = true };
            this.Initialized = true;
            return true;
        }

        /// <summary>
        /// Closing the logfile stream
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Close()
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
