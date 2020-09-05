using System.Threading.Tasks;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public interface IUserApi
    {
        [Get("/api/users")]
        Task<UsersResponse> GetUsers([Query] int page = 1, int delay = 3);
    }
}