using Xamarin.Essentials;

namespace SeptemberUIChallenge.Services
{
    public class ConnectionManager : IConnectionManager
    {
        public bool HasInternetAccess() => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}