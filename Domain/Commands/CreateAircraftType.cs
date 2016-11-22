using Shared;

namespace Domain.Commands
{
    public class CreateAircraftType : ICommand
    {
        public string PlaneName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }
    }
}
