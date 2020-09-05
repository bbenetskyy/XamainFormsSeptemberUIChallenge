using System.Threading.Tasks;
using Refit;
using SeptemberUIChallenge.Data.Models;

namespace SeptemberUIChallenge.Data.Api
{
    public interface ILoginClient
    {
        [Get("/api/users")]
        Task<UsersResponse> GetUsers([Query] int page = 1, int delay = 3);
    }
}