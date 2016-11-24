using AutoMapper;
using Domain.Events;

namespace Domain.Model
{
    public class Aircraft : Entity
    {
        public string AircraftName { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }

        public void Apply(AircraftCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }
    }
}
