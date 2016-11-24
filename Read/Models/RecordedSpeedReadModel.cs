using Domain.Events.SpeedClaims;
using System;

namespace Read.Models
{
    public class RecordedSpeedReadModel : BaseReadModel
    {
        public DateTime Date { get; set; }

        public DateTime? VerifiedDate { get; set; }

        public DateTime? RejectedDate { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public bool IsVerified { get; set; }

        public bool IsRejected { get; set; }

        public string Notes { get; set; }

        public string PilotName { get; set; }

        public string WitnessName { get; set; }

        public string VerifiedByName { get; set; }

        public string RejectedByName { get; set; }

        public string SiteName { get; set; }

        public string AircraftName { get; set; }


        public void Apply(SpeedClaimCreated speedClaimCreatedEvent)
        {
            Date = speedClaimCreatedEvent.SpeedClaimedDate;
            SpeedInMilesPerHour = speedClaimCreatedEvent.SpeedInMilesPerHour;
            Notes = speedClaimCreatedEvent.Notes;
            IsVerified = false;
            WitnessName = speedClaimCreatedEvent.WitnessName;
            PilotName = speedClaimCreatedEvent.PilotName;
            SiteName = speedClaimCreatedEvent.SiteName;
            AircraftName = speedClaimCreatedEvent.AircraftName;
        }

        public void Apply(SpeedClaimVerified speedClaimVerifiedEvent)
        {
            VerifiedDate = speedClaimVerifiedEvent.SpeedVerifiedDate;
            VerifiedByName = speedClaimVerifiedEvent.VerifiedByName;
            IsVerified = true;
            IsRejected = false;
        }

        public void Apply(SpeedClaimRejected speedClaimRejectedEvent)
        {
            RejectedDate = speedClaimRejectedEvent.SpeedRejectionDate;
            RejectedByName = speedClaimRejectedEvent.RejectedByName;
            IsVerified = false;
            IsRejected = true;
        }

    }
}
