using AutoMapper;
using Domain.Events.Site;
using System;

namespace Domain.Model
{
    public class Site : Entity
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

        public Guid CountryId { get; set; }

        public void Apply(SiteCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }

        public void Apply(SiteUpdated updatedEvent)
        {
            Mapper.Map(updatedEvent, this);
            //SiteName = updatedEvent.SiteName;
            //Location = updatedEvent.Location;
            //CountryId = updatedEvent.CountryId;
        }

    }
}
