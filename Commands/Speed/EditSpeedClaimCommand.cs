using System;
using System.Linq;
using AutoMapper;
using Data.Queries;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Shared;
using Shared.Exceptions;

namespace Commands.Speed
{
    public class EditSpeedClaimCommand : BaseCommand, ICommand
    {
        public EditSpeedClaimCommand()
        {
        }

        public EditSpeedClaimCommand(IDocumentSession docSession) : base(docSession)
        {
        }
        public Guid Id { get; set; }

        public DateTime SpeedClaimedDate { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public string Notes { get; set; }

        public Guid PilotId { get; set; }

        public Guid WitnessId { get; set; }

        public Guid SiteId { get; set; }

        public Guid AircraftId { get; set; }

        public void Validate()

        {
            if (!DocumentSession.Exists<Domain.Model.Speed>(Id))
                throw new BusinessRuleValidationException("Speed cannot be found. ");

            if (!DocumentSession.Exists<Person>(PilotId))
                throw new BusinessRuleValidationException("Pilot cannot be found. ");

            if (!DocumentSession.Exists<Person>(WitnessId))
                throw new BusinessRuleValidationException("Witness cannot be found. ");

            if (!DocumentSession.Exists<Domain.Model.Site>(SiteId))
                throw new BusinessRuleValidationException("Site cannot be found. ");

            if (!DocumentSession.Exists<Domain.Model.Aircraft>(AircraftId))
                throw new BusinessRuleValidationException("Airctaft cannot be found. ");

            if (DocumentSession.Load<Domain.Model.Speed>(Id).IsVerified)
                throw new BusinessRuleValidationException("Cannot edit a verified speed. ");
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SpeedClaimEdited>(this);

            @event.PilotName = DocumentSession.Query<Person>().Single(a => a.Id == PilotId).UserName;
            @event.WitnessName = DocumentSession.Query<Person>().Single(a => a.Id == WitnessId).UserName;
            @event.AircraftName = DocumentSession.Query<Domain.Model.Aircraft>().Single(a => a.Id == AircraftId).AircraftName;

            var site = DocumentSession.Query<Domain.Model.Site>().Single(a => a.Id == SiteId);
            @event.SiteName = site.SiteName;
            @event.SiteLocation = site.Location;
            @event.SiteCountryName = DocumentSession.Query<Domain.Model.Country>().Single(a => a.Id == site.CountryId).CountryName;

            DocumentSession.Events.Append(Id, @event);

            DocumentSession.SaveChanges();

            return null;
        }

    }
}
