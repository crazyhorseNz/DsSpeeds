using AutoMapper;
using Domain.Events;
using Domain.Events.Speed;
using Domain.Model;
using Domain.Events.Site;

namespace Domain.AutoMapper
{
    public class EventsToDomain : Profile
    {
        protected override void Configure()
        {
            CreateMap<PersonCreated, Person>();
            CreateMap<AircraftCreated, Aircraft>();

            CreateMap<SiteCreated, Site>();
            CreateMap<SiteUpdated, Site>();

            CreateMap<SpeedClaimCreated, Speed>();
            CreateMap<CountryCreated, Country>();
        }
    }
}