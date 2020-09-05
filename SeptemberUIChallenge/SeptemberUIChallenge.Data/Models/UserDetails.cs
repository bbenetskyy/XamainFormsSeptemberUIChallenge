using SeptemberUIChallenge.Data.Api;
using static SeptemberUIChallenge.Data.Infrastructure.FakeProvider;

namespace SeptemberUIChallenge.Data.Models
{
    public class UserDetails
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Details { get; set; }
        public string[] Tags { get; set; }

        public static implicit operator UserDetails(UserDetailsResponse response) => new UserDetails
        {
            Id = response.Id,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Avatar = response.Avatar,
            Details = Faker.Lorem.Letter(),
            Tags = new []
            {
                Faker.Hacker.Adjective(), Faker.Hacker.Adjective(), Faker.Hacker.Adjective(),
                Faker.Hacker.Adjective(), Faker.Hacker.Adjective(), Faker.Hacker.Adjective()
            }
        };

    }
}