using AutoMapper;
using Domain.Events.Site;
using Marten;
using Shared;
using System;
using Data.Queries;
using Shared.Exceptions;

namespace Commands.Site
{
    public class CreateSiteCommand : BaseCommand, ICommand
    {
        public CreateSiteCommand()
        {
        }

        public CreateSiteCommand(IDocumentSession docSession) 
            : base(docSession)
        {
        }

        public string SiteName { get; set; }

        public string Location { get; set; }

        public Guid CountryId { get; set; }

        public void Validate()
        {
            if (!DocumentSession.Exists<Domain.Model.Country>(CountryId))
                throw new BusinessRuleValidationException("Country does not exit. ");
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SiteCreated>(this);

            var siteId = DocumentSession.Events.StartStream<Domain.Model.Site>(@event);

            @event.CountryName = DocumentSession.Load<Domain.Model.Country>(CountryId).CountryName;

            DocumentSession.SaveChanges();

            return siteId;
        }
    }
}
