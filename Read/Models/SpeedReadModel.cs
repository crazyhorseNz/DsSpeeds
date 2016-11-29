using System;
using Domain.Events.Speed;

namespace Read.Models
{
    public class SpeedReadModel : BaseReadModel
    {
        public DateTime Date { get; set; }

        public DateTime? VerifiedDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public bool IsVerified { get; set; }

        public string Notes { get; set; }

        public string PilotName { get; set; }

        public string WitnessName { get; set; }

        public string VerifiedByName { get; set; }

        public Guid SiteId { get; set; }

        public string SiteName { get; set; }

        public string SiteLocation { get; set; }

        public string SiteCountryName { get; set; }

        public string AircraftName { get; set; }


        public void Apply(SpeedClaimCreated speedClaimCreatedEvent)
        {
            SiteId = speedClaimCreatedEvent.SiteId;
            Date = speedClaimCreatedEvent.SpeedClaimedDate;
            SpeedInMilesPerHour = speedClaimCreatedEvent.SpeedInMilesPerHour;
            Notes = speedClaimCreatedEvent.Notes;
            WitnessName = speedClaimCreatedEvent.WitnessName;
            PilotName = speedClaimCreatedEvent.PilotName;
            SiteName = speedClaimCreatedEvent.SiteName; 
            SiteLocation = speedClaimCreatedEvent.SiteLocation;
            SiteCountryName = speedClaimCreatedEvent.SiteCountryName;
            AircraftName = speedClaimCreatedEvent.AircraftName;
        }

        public void Apply(SpeedClaimVerified speedClaimVerifiedEvent)
        {
            VerifiedDate = speedClaimVerifiedEvent.SpeedVerifiedDate;
            VerifiedByName = speedClaimVerifiedEvent.VerifiedByName;
            IsVerified = true;
        }

        public void Apply(SpeedClaimEdited editedEvent)
        {
            SiteId = editedEvent.SiteId;
            Date = editedEvent.SpeedClaimedDate;
            SpeedInMilesPerHour = editedEvent.SpeedInMilesPerHour;
            Notes = editedEvent.Notes;
            WitnessName = editedEvent.WitnessName;
            PilotName = editedEvent.PilotName;
            SiteName = editedEvent.SiteName;
            SiteLocation = editedEvent.SiteLocation;
            SiteCountryName = editedEvent.SiteCountryName;
            AircraftName = editedEvent.AircraftName;
        }

    }
}
