using Shared;
using System;

namespace Domain.Events.Site
{
    public class SiteCreated : IDomainEvent
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        public Guid CountryId { get; set; }

        public string CountryName { get; set; }

    }
}
