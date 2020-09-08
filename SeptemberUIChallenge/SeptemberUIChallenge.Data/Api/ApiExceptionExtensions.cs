using Newtonsoft.Json.Linq;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public static class ApiExceptionExtensions
    {
        public static string GetContentErrorString(this ApiException exception)
        {
            try
            {
                return JObject.Parse(exception.Content).First.First.Value<string>();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}