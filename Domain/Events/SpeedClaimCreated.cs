﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Domain.Events
{
    public class SpeedClaimCreated : IDomainEvent
    {
        public DateTime SpeedClaimedDate { get; set; }
        
        public long SpeedInMilesPerHour { get; set; }

        public Guid PilotId { get; set; }

        public Guid WitnessId { get; set; }

        public Guid SiteId { get; set; }
    }
}
