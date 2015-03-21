using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : ILoggingFunctions
    {
        // =============================================================
        //
        // normal logging functions - testscripts/models/adapters
        //
        // =============================================================
        int ILoggingFunctions.LogError(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Error(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Warning(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Info(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogDebug(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Debug(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogTrace(string message)
        {
            throw new NotImplementedException();
        }

        // =============================================================
        //
        // normal logging functions - models and adapters
        //
        // =============================================================
        int ILoggingFunctions.Trace(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogInternal(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Internal(string message)
        {
            throw new NotImplementedException();
        }

        // =============================================================
        //
        // used solely by Assert functions
        //
        // =============================================================
        int ILoggingFunctions.LogPass(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Pass(string testStepName, string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.LogFail(string message)
        {
            throw new NotImplementedException();
        }

        int ILoggingFunctions.Fail(string testStepName, string message)
        {
            throw new NotImplementedException();
        }
    }
}
