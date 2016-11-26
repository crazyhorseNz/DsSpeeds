using AutoMapper;
using Marten;
using Shared;
using System;
using Domain.Events.Site;

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

      //  public Guid CountryId { get; set; }

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SiteUpdated>(this);

            DocumentSession.Events.Append(Id, @event);

            DocumentSession.SaveChanges();

            return null;
        }
    }
}
