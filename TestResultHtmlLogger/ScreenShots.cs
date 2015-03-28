using System;
using Stf.Utilities.TestResultHtmlLogger.Interfaces;

namespace Stf.Utilities.TestResultHtmlLogger
{
    public partial class TestResultHtmlLogger : IScreenshots
    {
        // =============================================================
        //
        // scrrenshots - used by testscripts
        //
        // =============================================================
        int IScreenshots.LogAllWindows(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        int IScreenshots.LogScreenshot(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        int IScreenshots.LogImage(LogLevel logLevel, string imageFile, string message)
        {
            throw new NotImplementedException();

          //            messageIdString = GetNextMessageId();

//      <div onclick="sa('m413')" id="m413" class="line info image">
//          <div class="el time">17:11:56</div>
//          <div class="el level">info</div>
//          <div class="el msg">Billede: Waited for this testobject to appear For [0] seconds. TypeName[Step] micclass[Page]</div>
//          <p><img  onclick="showImage(this)" class="embeddedimage" alt="Waited for this testobject to appear For [0] seconds. TypeName[Step] micclass[Page]" src="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAB4AAAAPpCAAAAADRfW+bAAAABGdBTUEAA
//      </div>
        }
    }
}
