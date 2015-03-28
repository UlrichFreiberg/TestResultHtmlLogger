// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenShots.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   The test result html logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace TestResultHtmlLogger
{
    /// <summary>
    /// The test result html logger.
    /// </summary>
    public partial class TestResultHtmlLogger : IScreenshots
    {
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
            throw new NotImplementedException();
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
            // TODO: log a screenshot of all monitors connected to the machine (this one currently only gets the primary screen)
            return LogOneImage(logLevel, DoScreenshot(Screen.GetBounds(Point.Empty)), message);
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
        /// The take one screenshot.
        /// </summary>
        /// <param name="bounds">
        /// The bounds.
        /// </param>
        /// <returns>
        /// Base64 encoded image <see cref="string"/>
        /// </returns>
        private string DoScreenshot(Rectangle bounds)
        {
            var imageString = string.Empty;

            try
            {
                using (var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format16bppRgb565))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

                        using (var memoryStream = new MemoryStream())
                        {
                            bitmap.Save(memoryStream, ImageFormat.Png);
                            imageString = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Internal(string.Format("Failed to grab screenshot. Error message: {0}", exception.Message)); // TODO: Handle specific exceptions
            }

            return imageString;
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
            if (!AddLoglevelToRunReport[logLevel])
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

            logFileHandle.Write(html);
            logFileHandle.Flush();

            return html.Length;
        }
    }
}
