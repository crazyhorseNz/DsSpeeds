using System;
using System.Collections.Generic;
using Domain.Events.Site;

namespace Read.Models
{
    public class SiteReadModel : BaseReadModel
    {
        public SiteReadModel()
        {
            AllVerifiedSiteSpeeds = new List<SiteSpeedReadModel>();
        }

        public string SiteName { get; set; }

        public string Location { get; set; }

        public string CountryName { get; set; }

        public List<SiteSpeedReadModel> AllVerifiedSiteSpeeds { get; set; }

        public void Apply(SiteCreated createdEvent)
        {
            SiteName = createdEvent.SiteName;
            Location = createdEvent.Location;
            CountryName = createdEvent.CountryName;
        }

        public void Apply(SiteUpdated updateEvent)
        {
            SiteName = updateEvent.SiteName;
            Location = updateEvent.Location;
            CountryName = updateEvent.CountryName;
        }

        public class SiteSpeedReadModel
        {
            public DateTime Date { get; set; }

            public long SpeedInMilesPerHour { get; set; }

            public string PilotName { get; set; }

            public string AircraftName { get; set; }
        }
    }
}
