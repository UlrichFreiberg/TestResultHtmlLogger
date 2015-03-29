// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenshotUtilities.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   The screenshot utilities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Stf.Utilities.TestResultHtmlLogger.Utils
{
    /// <summary>
    /// The screenshot utilities.
    /// </summary>
    internal class ScreenshotUtilities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenshotUtilities"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ScreenshotUtilities(TestResultHtmlLogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public TestResultHtmlLogger Logger { get; set; }

        /// <summary>
        /// The take one screenshot.
        /// </summary>
        /// <param name="bounds">
        /// The bounds.
        /// </param>
        /// <returns>
        /// Base64 encoded image <see cref="string"/>
        /// </returns>
        public string DoScreenshot(Rectangle bounds)
        {
            var imageString = string.Empty;
            var startingPoint = new Point(bounds.X, bounds.Y);

            try
            {
                using (var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format16bppRgb565))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(startingPoint, Point.Empty, bounds.Size);

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
                // TODO: Handle specific exceptions
                Logger.LogInternal(string.Format("Failed to grab screen shot. Error message: {0}", exception.Message)); 
            }

            return imageString;
        }
    }
}
