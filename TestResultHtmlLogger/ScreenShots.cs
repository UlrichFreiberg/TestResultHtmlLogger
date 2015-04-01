// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenShots.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   The test result html logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Stf.Utilities.TestResultHtmlLogger
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using Stf.Utilities.TestResultHtmlLogger.Interfaces;
    using Stf.Utilities.TestResultHtmlLogger.Utils;

    /// <summary>
    /// The test result html logger.
    /// </summary>
    public partial class TestResultHtmlLogger : IScreenshots
    {
        /// <summary>
        /// The utilities.
        /// </summary>
        private ScreenshotUtilities utilities;

        /// <summary>
        /// Gets the utilities.
        /// </summary>
        private ScreenshotUtilities Utilities 
        {
            get { return utilities ?? (utilities = new ScreenshotUtilities(this)); }
        }

        /// <summary>
        /// The log all windows.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogAllWindows(LogLevel logLevel, string message)
        {
            // TODO: Duplicate code, fix this with some proper logic
            if (!this.addLoglevelToRunReport[logLevel])
            {
                return -1;
            }

            var allWindows = Utilities.GetImagesOfAllWindows();

            return allWindows.Sum(window => LogOneImage(logLevel, window.Value, message));
        }

        /// <summary>
        /// The log screenshot.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogScreenshot(LogLevel logLevel, string message)
        {
            var length = 0;
            foreach (var screen in Screen.AllScreens)
            {
                length += LogOneImage(logLevel, Utilities.DoScreenshot(screen.Bounds), message);
                if (length < 0)
                {
                    break;
                }
            }

            return length;
        }

        /// <summary>
        /// The log image.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="imageFile">
        /// The image file.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int LogImage(LogLevel logLevel, string imageFile, string message)
        {
            return LogOneImage(logLevel, imageFile, message);
        }

        /// <summary>
        /// The log one image.
        /// </summary>
        /// <param name="logLevel">
        /// The log level.
        /// </param>
        /// <param name="imageFile">
        /// The image file.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int LogOneImage(LogLevel logLevel, string imageFile, string message)
        {
            if (!this.addLoglevelToRunReport[logLevel])
            {
                return -1;
            }

            var messageIdString = GetNextMessageId();
            var logLevelString = Enum.GetName(typeof(LogLevel), logLevel);

            var html = string.Format("<div onclick=\"sa('{0}')\" id=\"{0}\" class=\"line info image\">", messageIdString);
            html += string.Format("    <div class=\"el time\">{0}</div>", DateTime.Now.ToString("HH:mm:ss"));
            html += string.Format("    <div class=\"el level\">{0}</div>", logLevelString);
            html += string.Format("    <div class=\"el msg\">{0}</div>", message);
            html += string.Format("    <p><img  onclick=\"showImage(this)\" class=\"embeddedimage\" alt=\"{0}\" src=\"data:image/png;base64, {1}\"</p>", message, imageFile);
            html += "</div>";

            this.logFileHandle.Write(html);

            return html.Length;
        }
    }
}
