using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    static class Settings
    {
        static UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
        static System.Configuration.Configuration myDllConfig = ConfigurationManager.OpenExeConfiguration(uri.Path);
        static AppSettingsSection AppSettings = (AppSettingsSection)myDllConfig.GetSection("appSettings");
        static NumberFormatInfo nfi = new NumberFormatInfo()
        {
            NumberGroupSeparator = "",
            CurrencyDecimalSeparator = "."
        };

        public static T Setting<T>(string name)
        {
            return (T)Convert.ChangeType(AppSettings.Settings[name].Value, typeof(T), nfi);
        }
    }

    public class LogConfiguration
    {

        public Boolean OverwriteLogFile { get; set; }
        public Boolean LogToFile { get; set; }
        public String LogTitle { get; set; }
        public String LogFileName { get; set; }
        public int AlertLongInterval { get; set; }
        public LogLevel LogLevel { get; set; }
        public String PathToLogoImageFile { get; set; }

        /// <summary>
        /// Standard constructor - sets up default configuration... 
        /// TODO:Later YACF kicks in..
        /// </summary>
        public LogConfiguration()
        {
            OverwriteLogFile = Settings.Setting<Boolean>("OverwriteLogFile");
            LogToFile = Settings.Setting<Boolean>("LogToFile");
            LogTitle = Settings.Setting<String>("LogTitle");
            LogFileName = Settings.Setting<String>("LogFileName"); 
            AlertLongInterval = Settings.Setting<int>("AlertLongInterval");
            LogLevel = LogLevel.Info; //TODO: Settings.Setting<LogLevel>("LogLevel");
            PathToLogoImageFile = Settings.Setting<String>("PathToLogoImageFile");
        }
    }
}
