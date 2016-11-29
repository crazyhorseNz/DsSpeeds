using AutoMapper;
using Commands.AutoMapper;
using Data;
using DatabaseInitialiser.SeedData;
using Domain.AutoMapper;
using System;

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
                new Countries(),
                new Sites(),
                new Aircraft(),
                new People(),
                new Speeds(),
                new VerifyAndRejectSpeedClaims(), 
                new UpdateASite(), 
                new EditSpeeds(), 
            };

            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                foreach (var seed in allSeeds)
                {
                    Console.WriteLine($"Running DB Seed {seed.GetType().Name}");
                    seed.Run(MartenDocumentStore.Store.LightweightSession());
                    session.SaveChanges();
                }

                Console.WriteLine($"Finished running DB Seed...");
            }

        }
    }
}
