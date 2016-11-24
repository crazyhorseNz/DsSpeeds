using System;
using AutoMapper;
using Data;
using Domain.Events;
using Domain.Model;
using Marten;
using Shared;

namespace Commands
{
    public class CreateSiteCommand : BaseCommand, ICommand
    {
        public string SiteName { get; set; }

        public string Location { get; set; }

      //  public Guid CountryId { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<SiteCreated>(this);

            var siteId = session.Events.StartStream<Site>(@event);

            session.SaveChanges();

            return siteId;
        }
    }
}
