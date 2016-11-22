using System;
using Domain.Events;

namespace Domain.Model
{
    public class RecordedSpeed : Entity
    {
        public DateTime Date { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public Person Pilot { get; set; }

        public Person Witness { get; set; }

        public Site Site { get; set; }


        public void Apply(SpeedClaimCreated createdEvent)
        {

        }
    }
}
