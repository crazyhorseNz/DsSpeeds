using System;
using AutoMapper;
using Domain.Events.Speed;

namespace Domain.Model
{
    public class Speed : Entity
    {
        public DateTime Date { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public bool IsVerified { get; set; }

        public bool IsDeleted { get; set; }

        public string Notes { get; set; }

        public Guid PilotId { get; set; }

        public Guid WitnessId { get; set; }

        public Guid DeletedById { get; set; }

        public Guid VerifiedById { get; set; }

        public Guid SiteId { get; set; }

        public Guid AircraftId { get; set; }

        public void Apply(SpeedClaimCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }

        public void Apply(SpeedClaimVerified verifiedEvent)
        {
            Mapper.Map(verifiedEvent, this);
            IsVerified = true;
        }

        public void Apply(RecordedSpeedDeleted deletedEvent)
        {
            Mapper.Map(deletedEvent, this);
            IsDeleted = true;
        }
    }
}
