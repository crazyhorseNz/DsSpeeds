using System;
using Shared;

namespace Domain.Events.Speed
{
    public class RecordedSpeedDeleted : IDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime SpeedDeletionDate { get; set; }

        public Guid DeletedById { get; set; }

        public string DeletedByName { get; set; }
    }
    
}
