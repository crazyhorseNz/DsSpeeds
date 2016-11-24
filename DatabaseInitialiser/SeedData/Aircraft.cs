using Commands;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Aircraft : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateAircraftCommand { IsFoam = true, AircraftName = "JW 60", PlaneManufacturer = "FlyJW", WingSpanInInches = 60 }.Execute(session);
            new CreateAircraftCommand { IsFoam = true, AircraftName = "Reaper 60", PlaneManufacturer = "Pacific Sailplanes", WingSpanInInches = 60 }.Execute(session);
            new CreateAircraftCommand { IsFoam = false, AircraftName = "AFP 70", PlaneManufacturer = "Jono Industries", WingSpanInInches = 70 }.Execute(session);
        }
    }
}
