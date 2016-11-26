using AutoMapper;
using Commands.Site;
using Commands.Speed;
using Domain.Events;
using Domain.Events.Site;
using Domain.Events.Speed;

namespace Commands.AutoMapper
{
    public class CommandsToEvents : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreatePersonCommand, PersonCreated>();
            CreateMap<CreateAircraftCommand, AircraftCreated>();
            CreateMap<CreateSiteCommand, SiteCreated>();
            CreateMap<CreateCountryCommand, CountryCreated>();

            CreateMap<CreateSpeedClaimCommand, SpeedClaimCreated>();
            CreateMap<VerifySpeedClaimCommand, SpeedClaimVerified>();
            CreateMap<DeleteRecordedSpeedCommand, RecordedSpeedDeleted>();
        }
    }
}