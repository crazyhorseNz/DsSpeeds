using Marten;
using System;
using System.Linq;
using Commands.Speed;
using Domain.Model;

namespace DatabaseInitialiser.SeedData
{
    public class EditSpeeds : ISeed
    {
        public void Run(IDocumentSession session)
        {
            var pilotId = session.Query<Person>().First().Id;
            var speed = session.Query<Speed>().First(s => s.PilotId == pilotId);

            var planeId = session.Query<Domain.Model.Aircraft>().First().Id;
            var witnessId = session.Query<Person>().First().Id;
            var ngaio = session.Query<Site>().Single(s => s.SiteName == "Long Gully").Id;

            new EditSpeedClaimCommand(session)
            {
                Id = speed.Id,
                SpeedClaimedDate = DateTime.Today.AddYears(-16),
                Notes = "Im gunna update these notes!",
                SpeedInMilesPerHour = 666,
                AircraftId = planeId,
                PilotId = pilotId,
                WitnessId = witnessId,
                SiteId = ngaio
            }.Execute();



        }
    }
}
