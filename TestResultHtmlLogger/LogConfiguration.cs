using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    static class Settings
    {
        static readonly UriBuilder Uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
        static readonly Configuration MyDllConfig = ConfigurationManager.OpenExeConfiguration(Uri.Path);
        static readonly AppSettingsSection AppSettings = (AppSettingsSection)MyDllConfig.GetSection("appSettings");
        static readonly NumberFormatInfo Nfi = new NumberFormatInfo()
        {
            NumberGroupSeparator = "",
            CurrencyDecimalSeparator = "."
        };

        public static T Setting<T>(string name)
        {
            return (T)Convert.ChangeType(AppSettings.Settings[name].Value, typeof(T), Nfi);
        }
    }

    public class LogConfiguration
    {

        public bool OverwriteLogFile { get; set; }
        public bool LogToFile { get; set; }
        public string LogTitle { get; set; }
        public string LogFileName { get; set; }
        public int AlertLongInterval { get; set; }
        public LogLevel LogLevel { get; set; }
        public string PathToLogoImageFile { get; set; }

        /// <summary>
        /// Standard constructor - sets up default configuration... 
        /// TODO:Later YACF kicks in..
        /// </summary>
        public LogConfiguration()
        {
            OverwriteLogFile = Settings.Setting<bool>("OverwriteLogFile");
            LogToFile = Settings.Setting<bool>("LogToFile");
            LogTitle = Settings.Setting<string>("LogTitle");
            LogFileName = Settings.Setting<string>("LogFileName"); 
            AlertLongInterval = Settings.Setting<int>("AlertLongInterval");
            LogLevel = LogLevel.Info; //TODO: Settings.Setting<LogLevel>("LogLevel");
            PathToLogoImageFile = Settings.Setting<string>("PathToLogoImageFile");
        }
    }
}
