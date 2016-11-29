using System.Collections.Generic;
using Domain.Events.Site;

namespace Read.Models
{
    public class SiteReadModel : BaseReadModel
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        public string CountryName { get; set; }

        public List<SpeedReadModel> AllVerifiedSiteSpeeds { get; set; }

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
    }
}
