using Shared;

namespace Domain.Events
{
    public class AircraftTypeCreated : IDomainEvent
    {
        public string PlaneName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }
    }
}
