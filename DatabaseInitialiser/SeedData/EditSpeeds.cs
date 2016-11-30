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
            var longGully = session.Query<Site>().Single(s => s.SiteName == "Long Gully").Id;

            new EditSpeedClaimCommand(session)
            {
                Id = speed.Id,
                SpeedClaimedDate = DateTime.Today.AddYears(-16), // change the claimed date
                Notes = "Im gunna update these notes!", // change the notes.
                SpeedInMilesPerHour = speed.SpeedInMilesPerHour,
                AircraftId = speed.AircraftId,
                PilotId = speed.PilotId,
                WitnessId = speed.WitnessId,
                SiteId = longGully // change the location to Long Gully.
            }.Execute();
        }
    }
}
