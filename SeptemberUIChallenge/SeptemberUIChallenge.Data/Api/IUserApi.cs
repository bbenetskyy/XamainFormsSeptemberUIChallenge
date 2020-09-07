using System.Threading.Tasks;
using Refit;

namespace SeptemberUIChallenge.Data.Api
{
    public interface IUserApi
    {
        [Get("/api/users")]
        Task<UsersResponse> GetUsers([Query] int delay = 3,[Query][AliasAs("per_page")] int perPage = 100);
        //API has only 12 records, so far it's now points to make infinitive loading and pagination
    }
}