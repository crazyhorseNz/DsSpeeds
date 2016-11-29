using AutoMapper;
using Marten;
using Shared;
using System;
using System.Linq;
using Data.Queries;
using Domain.Events.Site;
using Domain.Model;
using Read.Models;
using Shared.Exceptions;

namespace Commands.Site
{
    public class EditSiteCommand : BaseCommand, ICommand
    {
        public EditSiteCommand()
        {
        }

        public EditSiteCommand(IDocumentSession docSession) 
            : base(docSession)
        {
        }

        public Guid Id { get; set; }
        
        public string SiteName { get; set; }

        public string Location { get; set; }

        public Guid CountryId { get; set; }

        public void Validate()
        {
            if (!DocumentSession.Exists<Domain.Model.Site>(Id))
                throw new BusinessRuleValidationException("Site to update cannot be found. ");

            if (!DocumentSession.Exists<Domain.Model.Country>(Id))
                throw new BusinessRuleValidationException("Country cannot be found. ");
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SiteUpdated>(this);

            AppendUpdateSiteEvent(@event);

            PatchSpeedReadModel(@event);

            DocumentSession.SaveChanges();

            return null;
        }

        private void AppendUpdateSiteEvent(SiteUpdated @event)
        {
            @event.SiteName = SiteName;
            @event.Location = Location;
            @event.CountryName = DocumentSession.Query<Domain.Model.Country>().Single(a => a.Id == CountryId).CountryName;

            DocumentSession.Events.Append(Id, @event);
        }

        private void PatchSpeedReadModel(SiteUpdated @event)
        {
            DocumentSession.Patch<SpeedReadModel>(model => model.SiteId == Id)
                .Set(model => model.SiteName, @event.SiteName);

            DocumentSession.Patch<SpeedReadModel>(model => model.SiteId == Id)
                .Set(model => model.SiteLocation, @event.Location);

            DocumentSession.Patch<SpeedReadModel>(model => model.SiteId == Id)
                .Set(model => model.SiteCountryName, @event.CountryName);
        }
    }
}
