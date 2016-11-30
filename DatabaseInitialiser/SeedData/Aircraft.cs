using Commands;
using Commands.Aircraft;
using Marten;

namespace DatabaseInitialiser.SeedData
{
    public class Aircraft : ISeed
    {
        public void Run(IDocumentSession session)
        {
            new CreateAircraftCommand(session) { IsFoam = true, AircraftName = "JW 60", PlaneManufacturer = "FlyJW", WingSpanInInches = 60 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = true, AircraftName = "Reaper 60", PlaneManufacturer = "Pacific Sailplanes", WingSpanInInches = 60 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = false, AircraftName = "AFP 70", PlaneManufacturer = "Jono Industries", WingSpanInInches = 70 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = false, AircraftName = "AFP 60", PlaneManufacturer = "Jono Industries", WingSpanInInches = 60 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = false, AircraftName = "Scratcho", PlaneManufacturer = "AVB inc", WingSpanInInches = 60 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = false, AircraftName = "K2m", PlaneManufacturer = "FlyKinetic.com", WingSpanInInches = 80 }.Execute();
            new CreateAircraftCommand(session) { IsFoam = false, AircraftName = "WeeBee", PlaneManufacturer = "WeeBee ltd", WingSpanInInches = 20 }.Execute();
        }
    }
}
