using AutoMapper;
using Domain.Events;

namespace Domain.Model
{
    public class Site : Entity
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

      //  public Country Country { get; set; }

        public void Apply(SiteCreated createdEvent)
        {
            Mapper.Map(createdEvent, this);
        }

    }
}
