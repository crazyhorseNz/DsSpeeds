using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Aircraft : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateAircraftCommand { IsFoam = true, PlaneName = "JW 60", PlaneManufacturer = "FlyJW", WingSpanInInches = 60 }.Execute(session);
            new CreateAircraftCommand { IsFoam = true, PlaneName = "Reaper 60", PlaneManufacturer = "Pacific Sailplanes", WingSpanInInches = 60 }.Execute(session);
            new CreateAircraftCommand { IsFoam = false, PlaneName = "AFP 70", PlaneManufacturer = "Jono Industries", WingSpanInInches = 70 }.Execute(session);
        }
    }
}
