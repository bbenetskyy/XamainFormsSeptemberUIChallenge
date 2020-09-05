using Bogus;

namespace SeptemberUIChallenge.Data.Infrastructure
{
    public static class FakeProvider
    {
        public static Faker Faker { get; }

        static FakeProvider()
        {
            Faker = new Faker();
        }
    }
}