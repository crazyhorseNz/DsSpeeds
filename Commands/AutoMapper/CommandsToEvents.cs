using AutoMapper;
using Commands.SpeedClaims;
using Domain.Events;
using Domain.Events.SpeedClaims;

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
            CreateMap<RejectSpeedClaimCommand, SpeedClaimRejected>();
        }
    }
}