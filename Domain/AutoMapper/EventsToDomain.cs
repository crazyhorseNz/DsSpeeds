using AutoMapper;
using Domain.Events;
using Domain.Events.SpeedClaims;
using Domain.Model;

namespace Domain.AutoMapper
{
    public class EventsToDomain : Profile
    {
        protected override void Configure()
        {
            CreateMap<PersonCreated, Person>();
            CreateMap<AircraftCreated, Aircraft>();
            CreateMap<SiteCreated, Site>();
            CreateMap<SpeedClaimCreated, SpeedClaimCreated>();
            CreateMap<CountryCreated, Country>();
        }
    }
}