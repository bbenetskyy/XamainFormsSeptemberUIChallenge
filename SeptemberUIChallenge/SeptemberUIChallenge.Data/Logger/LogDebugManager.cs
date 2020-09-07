using System;
using System.Diagnostics;

namespace SeptemberUIChallenge.Data.Logger
{
    public class LogDebugManager : ILogger
    {
        //why not, it's just demo app - we could log to console only :P
        public void LogError(string message)
        {
            Debug.WriteLine(message);
        }

        public void LogError(Exception ex)
        {
            LogError(ex.Message);
            LogError(ex.StackTrace);
        }

        public void LogEvent(string message)
        {
            Debug.WriteLine(message);
        }
    }
}