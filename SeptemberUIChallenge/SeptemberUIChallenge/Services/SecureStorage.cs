using System.Threading.Tasks;

namespace SeptemberUIChallenge.Services
{
    public class SecureStorage : ISecureStorage
    {
        public  Task SetAsync(string key, string value)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync(key, value);
        }
    }
}