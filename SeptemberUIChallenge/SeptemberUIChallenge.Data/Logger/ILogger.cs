using System;

namespace SeptemberUIChallenge.Data.Logger
{
    public interface ILogger
    {
        void LogError(string message);
        void LogError(Exception ex);
        void LogEvent(string message);
    }
}