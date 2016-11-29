using System;
using Shared;

namespace Domain.Events.Speed
{
    public class SpeedClaimVerified : IDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime SpeedVerifiedDate { get; set; }

    }
}
