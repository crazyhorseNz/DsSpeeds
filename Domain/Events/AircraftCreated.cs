using Shared;

namespace Domain.Events
{
    public class AircraftCreated : IDomainEvent
    {
        public string AircraftName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }
    }
}
