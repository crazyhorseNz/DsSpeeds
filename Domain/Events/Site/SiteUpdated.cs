using Shared;
using System;

namespace Domain.Events.Site
{
    public class SiteUpdated : IDomainEvent
    {
        public Guid Id { get; set; }

        public string SiteName { get; set; }

        public string Location { get; set; }

        //public Guid CountryId { get; set; }

    }
}
