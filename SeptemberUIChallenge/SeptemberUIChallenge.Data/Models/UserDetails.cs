using System;
using Realms;
using SeptemberUIChallenge.Data.Api;
using static SeptemberUIChallenge.Data.Infrastructure.FakeProvider;

namespace SeptemberUIChallenge.Data.Models
{
    public class UserDetails: RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }//GUID is not supported now
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }

        public static implicit operator UserDetails(UserDetailsResponse response) => new UserDetails
        {
            Id = Guid.NewGuid().ToString(),
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Avatar = response.Avatar,
            Details = Faker.Lorem.Paragraph(),
            Tags = string.Join(",", new []
            {
                Faker.Hacker.Adjective(), Faker.Hacker.Adjective(), Faker.Hacker.Adjective(),
                Faker.Hacker.Adjective(), Faker.Hacker.Adjective(), Faker.Hacker.Adjective()
            })
        };

    }
}