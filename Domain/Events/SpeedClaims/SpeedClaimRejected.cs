using System;
using Shared;

namespace Domain.Events.SpeedClaims
{
    public class SpeedClaimRejected : IDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime SpeedRejectionDate { get; set; }

        public Guid RejectedById { get; set; }

        public string RejectedByName { get; set; }
    }
    
}
