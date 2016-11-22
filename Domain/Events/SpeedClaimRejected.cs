using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Domain.Events
{
    public class SpeedClaimRejected : IDomainEvent
    {
        public DateTime SpeedRejectionDate { get; set; }

        public Guid RejectedById { get; set; }
    }
}
