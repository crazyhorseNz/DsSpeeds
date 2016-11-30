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
            PatchAircraftSpeeds();
            PatchCountrySpeeds();

            DocumentSession.SaveChanges();

            return null;
        }

        private void PatchSiteSpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var siteSpeedModel = new SiteReadModel.SiteSpeedReadModel
            {
                SpeedId = Id,
                Date = speedReadModel.Date,
                AircraftName = speedReadModel.AircraftName,
                PilotName = speedReadModel.PilotName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour
            };

            DocumentSession.Patch<SiteReadModel>(speedReadModel.SiteId)
                .Append(siteReadModel => siteReadModel.AllVerifiedSpeeds, siteSpeedModel);
        }

        private void PatchPersonSpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var personSpeedModel = new PersonReadModel.PersonSpeedReadModel
            {
                SpeedId = Id,
                Date = speedReadModel.Date,
                AircraftName = speedReadModel.AircraftName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour,
                SiteName = speedReadModel.SiteName,
                SiteLocation = speedReadModel.SiteLocation,
                SiteCountryName = speedReadModel.SiteCountryName,
            };

            DocumentSession.Patch<PersonReadModel>(speedReadModel.PilotId)
                .Append(personReadModel => personReadModel.AllVerifiedSpeeds, personSpeedModel);
        }
        private void PatchAircraftSpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var aircraftSpeedModel = new AircraftReadModel.AircraftSpeedReadModel
            {
                SpeedId = Id,
                Date = speedReadModel.Date,
                PilotName = speedReadModel.PilotName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour,
                SiteName = speedReadModel.SiteName,
                SiteLocation = speedReadModel.SiteLocation,
                SiteCountryName = speedReadModel.SiteCountryName,
            };

            DocumentSession.Patch<AircraftReadModel>(speedReadModel.AircraftId)
                .Append(aircraftReadModel => aircraftReadModel.AllVerifiedSpeeds, aircraftSpeedModel);
        }

        private void PatchCountrySpeeds()
        {
            var speedReadModel = DocumentSession.Load<SpeedReadModel>(Id);

            var countrySpeedToAdd = new CountryReadModel.CountrySpeedReadModel
            {
                SpeedId = Id,
                Date = speedReadModel.Date,
                PilotName = speedReadModel.PilotName,
                SpeedInMilesPerHour = speedReadModel.SpeedInMilesPerHour,
                SiteName = speedReadModel.SiteName,
                SiteLocation = speedReadModel.SiteLocation,
                AircraftName = speedReadModel.AircraftName,
            };

            DocumentSession.Patch<CountryReadModel>(speedReadModel.CountryId)
                .Append(countryReadModel => countryReadModel.AllVerifiedSpeeds, countrySpeedToAdd);
        }
    }
}
