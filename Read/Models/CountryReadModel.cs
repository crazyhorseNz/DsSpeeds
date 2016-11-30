using Domain.Events;
using System;
using System.Collections.Generic;

namespace Read.Models
{
    public class CountryReadModel : BaseReadModel
    {
        public CountryReadModel()
        {
            AllVerifiedSpeeds = new List<CountrySpeedReadModel>();
        }

        public string CountryName { get; set; }


        public List<CountrySpeedReadModel> AllVerifiedSpeeds { get; set; }

        public void Apply(CountryCreated createdEvent)
        {
            CountryName = createdEvent.CountryName;
        }


        public class CountrySpeedReadModel
        {
            public Guid SpeedId { get; set; }

            public DateTime Date { get; set; }

            public long SpeedInMilesPerHour { get; set; }

            public string PilotName { get; set; }

            public string AircraftName { get; set; }

            public string SiteName { get; set; }

            public string SiteLocation { get; set; }
        }
    }
}
