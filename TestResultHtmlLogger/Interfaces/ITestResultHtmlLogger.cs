using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public enum LogLevel {
        Error,
        Warning,
        Info,
        Debug,
        Trace,
        Internal,

        // some internal loglevels
        Header,
        SubHeader,

        // TestResults
        Pass,
        Fail,

        // Level used to log keyvalues like OS, URL, VersionInfo etc...
        KeyValue
    }
}
