using Marten;
using System;
using System.Linq;
using Commands.Speed;

namespace DatabaseInitialiser.SeedData
{
    public class Speeds : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var planeId = session.Query<Domain.Model.Aircraft>().First().Id;
            var pilotId = session.Query<Domain.Model.Person>().First().Id;
            var witnessId = session.Query<Domain.Model.Person>().First().Id;
            var siteId = session.Query<Domain.Model.Site>().First().Id;

            new CreateSpeedClaimCommand(session)
            {
                SpeedClaimedDate = DateTime.Today,
                Notes = "Shit that was fast",
                SpeedInMilesPerHour = 999,
                AircraftId = planeId,
                PilotId = pilotId,
                WitnessId = witnessId,
                SiteId = siteId
            }.Execute();

            new CreateSpeedClaimCommand(session)
            {
                SpeedClaimedDate = DateTime.Today,
                Notes = "You suck",
                SpeedInMilesPerHour = 99,
                AircraftId = planeId,
                PilotId = pilotId,
                WitnessId = witnessId,
                SiteId = siteId
            }.Execute();

            new CreateSpeedClaimCommand(session)
            {
                SpeedClaimedDate = DateTime.Today.AddDays(-20),
                Notes = "Cheaty cheaty",
                SpeedInMilesPerHour = 111999,
                AircraftId = planeId,
                PilotId = pilotId,
                WitnessId = witnessId,
                SiteId = siteId
            }.Execute();

        }
    }
}
