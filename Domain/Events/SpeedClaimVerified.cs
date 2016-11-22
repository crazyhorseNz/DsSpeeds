using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Domain.Events
{
    public class SpeedClaimVerified : IDomainEvent
    {
        public DateTime SpeedVerifiedDate { get; set; }

        public Guid VerifiedById { get; set; }
    }
}
