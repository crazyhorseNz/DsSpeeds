using Domain.Events.Site;

namespace Read.Models
{
    public class SiteReadModel : BaseReadModel
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        public string CountryName { get; set; }

        public void Apply(SiteCreated createdEvent)
        {
            SiteName = createdEvent.SiteName;
            Location = createdEvent.Location;
        }
    }
}
