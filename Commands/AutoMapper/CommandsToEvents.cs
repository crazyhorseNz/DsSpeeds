using System;
using AutoMapper;
using Commands.Aircraft;
using Commands.Country;
using Commands.People;
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
            Person();
            Aircraft();
            Site();
            Country();
            Speed();
        }

        private void Speed()
        {
            CreateMap<CreateSpeedClaimCommand, SpeedClaimCreated>()
                .ForMember(e => e.PilotName, opt => opt.Ignore())
                .ForMember(e => e.WitnessName, opt => opt.Ignore())
                .ForMember(e => e.SiteName, opt => opt.Ignore())
                .ForMember(e => e.SiteLocation, opt => opt.Ignore())
                .ForMember(e => e.SiteCountryName, opt => opt.Ignore())
                .ForMember(e => e.AircraftName, opt => opt.Ignore());

            CreateMap<EditSpeedClaimCommand, SpeedClaimEdited>()
                .ForMember(e => e.PilotName, opt => opt.Ignore())
                .ForMember(e => e.WitnessName, opt => opt.Ignore())
                .ForMember(e => e.SiteName, opt => opt.Ignore())
                .ForMember(e => e.SiteLocation, opt => opt.Ignore())
                .ForMember(e => e.SiteCountryName, opt => opt.Ignore())
                .ForMember(e => e.AircraftName, opt => opt.Ignore());

            CreateMap<VerifySpeedClaimCommand, SpeedClaimVerified>();

            CreateMap<DeleteRecordedSpeedCommand, RecordedSpeedDeleted>()
                .ForMember(e => e.SpeedDeletionDate, opt => opt.ResolveUsing(command => DateTime.Today))
                .ForMember(e => e.DeletedById, opt => opt.Ignore())
                .ForMember(e => e.DeletedByName, opt => opt.Ignore());

        }

        private void Country()
        {
            CreateMap<CreateCountryCommand, CountryCreated>();
        }

        private void Site()
        {
            CreateMap<CreateSiteCommand, SiteCreated>()
                .ForMember(e => e.CountryName, opt => opt.Ignore());

            CreateMap<EditSiteCommand, SiteUpdated>()
                .ForMember(e => e.CountryName, opt => opt.Ignore());
        }

        private void Aircraft()
        {
            CreateMap<CreateAircraftCommand, AircraftCreated>();
        }

        private void Person()
        {
            CreateMap<CreatePersonCommand, PersonCreated>();
        }
    }
}