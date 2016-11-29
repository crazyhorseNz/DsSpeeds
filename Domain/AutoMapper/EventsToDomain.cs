using AutoMapper;
using Domain.Events;
using Domain.Events.Speed;
using Domain.Model;
using Domain.Events.Site;
using Shared;

namespace Domain.AutoMapper
{
    public class EventsToDomain : Profile
    {
        protected override void Configure()
        {
            Person();
            Aircraft();
            Site();
            Speed();
            Country();
        }

        private void Person()
        {
            CreateMap<PersonCreated, Person>()
                .ForMember(dom => dom.Id, opt => opt.Ignore());
        }

        private void Aircraft()
        {
            CreateMap<AircraftCreated, Aircraft>()
                .ForMember(dom => dom.Id, opt => opt.Ignore());
        }

        private void Site()
        {
            CreateMap<SiteCreated, Site>()
                .ForMember(dom => dom.Id, opt => opt.Ignore());

            CreateMap<SiteUpdated, Site>();
        }

        private void Country()
        {
            CreateMap<CountryCreated, Country>()
                .ForMember(dom => dom.Id, opt => opt.Ignore());
        }

        private void Speed()
        {
            CreateMap<SpeedClaimCreated, Speed>()
                .ForMember(dom => dom.Id, opt => opt.Ignore())
                .ForMember(dom => dom.DeletedById, opt => opt.Ignore())
                .ForMember(dom => dom.VerifiedById, opt => opt.Ignore())
                .ForMember(dom => dom.Date, opt => opt.MapFrom(e => e.SpeedClaimedDate))
                .ForMember(dom => dom.IsDeleted, opt => opt.UseValue(false))
                .ForMember(dom => dom.IsVerified, opt => opt.UseValue(false));

            CreateMap<SpeedClaimEdited, Speed>()
                .ForMember(dom => dom.DeletedById, opt => opt.Ignore())
                .ForMember(dom => dom.VerifiedById, opt => opt.Ignore())
                .ForMember(dom => dom.Date, opt => opt.MapFrom(e => e.SpeedClaimedDate))
                .ForMember(dom => dom.IsDeleted, opt => opt.Ignore())
                .ForMember(dom => dom.IsVerified, opt => opt.Ignore());

            CreateMap<SpeedClaimVerified, Speed>()
                .ForMember(dom => dom.VerifiedById, opt => opt.MapFrom(e => e.VerifiedById))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<RecordedSpeedDeleted, Speed>()
                .ForMember(dom => dom.DeletedById, opt => opt.MapFrom(e => e.DeletedById))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}