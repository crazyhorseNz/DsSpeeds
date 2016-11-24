using AutoMapper;
using Commands.AutoMapper;
using Data;
using DatabaseInitialiser.SeedData;
using Domain.AutoMapper;

namespace DatabaseInitialiser
{
    public static class Program
    {
        public static void Main()
        {
            Mapper.Initialize(mapper =>
                mapper.AddProfiles(
                    typeof(CommandsToEvents),
                    typeof(EventsToDomain)));

            MartenDocumentStore.BootMartenDocumentStore();

            MartenDocumentStore.Store.Advanced.Clean.CompletelyRemoveAll();

            var allSeeds = new ISeed[]
            {
                new Sites(),
                new Aircraft(),
                new Countries(),
                new People(),
                new CreateSpeedClaims(),
                new VerifyAndRejectSpeedClaims(), 
            };

            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                foreach (var seed in allSeeds)
                {
                    seed.Run(MartenDocumentStore.Store.LightweightSession());
                    session.SaveChanges();
                }


            }

        }
    }
}
