// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogConfiguration.cs" company="Foobar">
//   2015
// </copyright>
// <summary>
//   Defines the Settings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    /// <summary>
    /// The log configuration.
    /// </summary>
    public class LogConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogConfiguration"/> class. 
        /// TODO:Later YACF kicks in..
        /// </summary>
        public LogConfiguration()
        {
            OverwriteLogFile = Settings.Setting<bool>("OverwriteLogFile");
            LogToFile = Settings.Setting<bool>("LogToFile");
            LogTitle = Settings.Setting<string>("LogTitle");
            LogFileName = Settings.Setting<string>("LogFileName");
            AlertLongInterval = Settings.Setting<int>("AlertLongInterval");
            LogLevel = LogLevel.Info; // TODO: Settings.Setting<LogLevel>("LogLevel");
            PathToLogoImageFile = Settings.Setting<string>("PathToLogoImageFile");
        }

        /// <summary>
        /// Gets or sets a value indicating whether overwrite log file.
        /// </summary>
        public bool OverwriteLogFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log to file.
        /// </summary>
        public bool LogToFile { get; set; }

        /// <summary>
        /// Gets or sets the log title.
        /// </summary>
        public string LogTitle { get; set; }

        /// <summary>
        /// Gets or sets the log file name.
        /// </summary>
        public string LogFileName { get; set; }

        /// <summary>
        /// Gets or sets the alert interval. How many seconds is acceptable between two log entries.
        /// </summary>
        public int AlertLongInterval { get; set; }

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the path to logo image file.
        /// </summary>
        public string PathToLogoImageFile { get; set; }

        /// <summary>
        /// The settings.
        /// </summary>
        private static class Settings
        {
            /// <summary>
            /// The path to the assembly.
            /// </summary>
            public static readonly UriBuilder Uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);

            /// <summary>
            /// The configuration file for <c>this</c> <c>assemnbly</c>.
            /// </summary>
            public static readonly Configuration MyDllConfig = ConfigurationManager.OpenExeConfiguration(Uri.Path);

            /// <summary>
            /// The application settings.
            /// </summary>
            public static readonly AppSettingsSection AppSettings = (AppSettingsSection)MyDllConfig.GetSection("appSettings");

            /// <summary>
            /// The nfi.
            /// </summary>
            public static readonly NumberFormatInfo Nfi = new NumberFormatInfo()
            {
                NumberGroupSeparator = string.Empty,
                CurrencyDecimalSeparator = "."
            };

            /// <summary>
            /// The setting.
            /// </summary>
            /// <typeparam name="T">
            /// For now only Strings are supported
            /// </typeparam>
            /// <param name="name">
            /// The name of the configuration file entry.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            public static T Setting<T>(string name)
            {
                return (T)Convert.ChangeType(AppSettings.Settings[name].Value, typeof(T), Nfi);
            }
        }
    }
}
