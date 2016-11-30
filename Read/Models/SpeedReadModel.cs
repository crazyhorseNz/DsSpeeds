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

        public Guid PilotId { get; set; }

        public string PilotName { get; set; }

        public string WitnessName { get; set; }

        public Guid SiteId { get; set; }

        public string SiteName { get; set; }

        public string SiteLocation { get; set; }

        public Guid CountryId { get; set; }

        public string SiteCountryName { get; set; }

        public Guid AircraftId { get; set; }

        public string AircraftName { get; set; }

        public void Apply(SpeedClaimCreated speedClaimCreatedEvent)
        {
            SiteId = speedClaimCreatedEvent.SiteId;
            Date = speedClaimCreatedEvent.SpeedClaimedDate;
            SpeedInMilesPerHour = speedClaimCreatedEvent.SpeedInMilesPerHour;
            Notes = speedClaimCreatedEvent.Notes;
            WitnessName = speedClaimCreatedEvent.WitnessName;
            PilotId = speedClaimCreatedEvent.PilotId;
            PilotName = speedClaimCreatedEvent.PilotName;
            SiteName = speedClaimCreatedEvent.SiteName; 
            SiteLocation = speedClaimCreatedEvent.SiteLocation;
            SiteCountryName = speedClaimCreatedEvent.SiteCountryName;
            AircraftName = speedClaimCreatedEvent.AircraftName;
            AircraftId = speedClaimCreatedEvent.AircraftId;
            CountryId = speedClaimCreatedEvent.CountryId;
        }

        public void Apply(SpeedClaimVerified speedClaimVerifiedEvent)
        {
            VerifiedDate = speedClaimVerifiedEvent.SpeedVerifiedDate;
            IsVerified = true;
        }

        public void Apply(SpeedClaimEdited speedClaimEditedEvent)
        {
            SiteId = speedClaimEditedEvent.SiteId;
            Date = speedClaimEditedEvent.SpeedClaimedDate;
            SpeedInMilesPerHour = speedClaimEditedEvent.SpeedInMilesPerHour;
            Notes = speedClaimEditedEvent.Notes;
            WitnessName = speedClaimEditedEvent.WitnessName;
            PilotId = speedClaimEditedEvent.PilotId;
            PilotName = speedClaimEditedEvent.PilotName;
            SiteName = speedClaimEditedEvent.SiteName;
            SiteLocation = speedClaimEditedEvent.SiteLocation;
            SiteCountryName = speedClaimEditedEvent.SiteCountryName;
            AircraftName = speedClaimEditedEvent.AircraftName;
            AircraftId = speedClaimEditedEvent.AircraftId;
            CountryId = speedClaimEditedEvent.CountryId;
        }

    }
}
