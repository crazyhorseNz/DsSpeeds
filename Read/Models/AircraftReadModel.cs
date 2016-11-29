using Domain.Events;
using System;
using System.Collections.Generic;

namespace Read.Models
{
    public class AircraftReadModel : BaseReadModel
    {
        public AircraftReadModel()
        {
            AllVerifiedSpeeds = new List<AircraftSpeedReadModel>();
        }

        public string AircraftName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }

        public List<AircraftSpeedReadModel> AllVerifiedSpeeds { get; set; }

        public void Apply(AircraftCreated createdEvent)
        {
            AircraftName = createdEvent.AircraftName;
            WingSpanInInches = createdEvent.WingSpanInInches;
            PlaneManufacturer = createdEvent.PlaneManufacturer;
            IsFoam = createdEvent.IsFoam;
        }


        public class AircraftSpeedReadModel
        {
            public Guid SpeedId { get; set; }

            public DateTime Date { get; set; }

            public long SpeedInMilesPerHour { get; set; }

            public string PilotName { get; set; }

            public string SiteName { get; set; }

            public string SiteLocation { get; set; }

            public string SiteCountryName { get; set; }
        }
    }
}
