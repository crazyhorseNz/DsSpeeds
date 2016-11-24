using System;
using Shared;

namespace Domain.Events.SpeedClaims
{
    public class SpeedClaimVerified : IDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime SpeedVerifiedDate { get; set; }

        public Guid VerifiedById { get; set; }

        public string VerifiedByName { get; set; }
    }
}
