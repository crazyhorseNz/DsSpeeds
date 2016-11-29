using AutoMapper;
using Data.Queries;
using Domain.Events.Speed;
using Marten;
using Read.Models;
using Shared;
using Shared.Exceptions;
using System;

namespace Commands.Speed
{
    public class VerifySpeedClaimCommand : BaseCommand, ICommand
    {
        public VerifySpeedClaimCommand()
        {
        }

        public VerifySpeedClaimCommand(IDocumentSession docSession) : base(docSession)
        {
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            if (!DocumentSession.Exists<Domain.Model.Speed>(Id))
                throw new BusinessRuleValidationException("Speed to verify cannot be found. ");
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SpeedClaimVerified>(this);
            @event.SpeedVerifiedDate = DateTime.Now;

            DocumentSession.Events.Append(Id, @event);

            PatchSiteSpeeds();
            PatchPersonSpeeds();

            DocumentSession.SaveChanges();

            return null;
        }

        private void PatchSiteSpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var siteSpeedModel = new SiteReadModel.SiteSpeedReadModel
            {
                Date = speedReadModel.Date,
                AircraftName = speedReadModel.AircraftName,
                PilotName = speedReadModel.PilotName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour
            };

            DocumentSession.Patch<SiteReadModel>(speedReadModel.SiteId)
                .Append(siteReadModel => siteReadModel.AllVerifiedSiteSpeeds, siteSpeedModel);
        }

        private void PatchPersonSpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var personSpeedModel = new PersonReadModel.PersonSpeedReadModel
            {
                Date = speedReadModel.Date,
                AircraftName = speedReadModel.AircraftName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour,
                SiteName = speedReadModel.SiteName,
                SiteLocation = speedReadModel.SiteLocation,
                SiteCountryName = speedReadModel.SiteCountryName,
            };

            DocumentSession.Patch<PersonReadModel>(speedReadModel.PilotId)
                .Append(personReadModel => personReadModel.AllVerifiedSiteSpeeds, personSpeedModel);
        }
    }
}
