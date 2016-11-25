using AutoMapper;
using Domain.Events;
using Domain.Model;
using Marten;
using Shared;
using System;

namespace Commands
{
    public class CreateCountryCommand : BaseCommand, ICommand
    {
        public CreateCountryCommand()
        {
        }

        public CreateCountryCommand(IDocumentSession docSession) 
            : base(docSession)
        {
        }

        public string CountryName { get; set; }

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<CountryCreated>(this);

            var countryId = DocumentSession.Events.StartStream<Country>(@event);

            DocumentSession.SaveChanges();

            return countryId;
        }
    }
}
