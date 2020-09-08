namespace SeptemberUIChallenge.Services
{
    public interface IConnectionManager
    {
        bool HasInternetAccess();
        bool TerminateIfNoInternetAccess(bool forceTerminate = false);
    }
}