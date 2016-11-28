using System;
using Shared;

namespace Domain.Events.Speed
{
    public class SpeedClaimCreated : IDomainEvent
    {
        public DateTime SpeedClaimedDate { get; set; }
       
        public long SpeedInMilesPerHour { get; set; }

        public string Notes { get; set; }

        public Guid PilotId { get; set; }

        public string PilotName { get; set; }

        public Guid WitnessId { get; set; }

        public string WitnessName { get; set; }

        public Guid SiteId { get; set; }

        public Guid AircraftId { get; set; }

        public string SiteName { get; set; }

        public string SiteLocation { get; set; }

        public string SiteCountryName { get; set; }

        public string AircraftName { get; set; }
    }
}
