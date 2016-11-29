using System;
using AutoMapper;
using Domain.Events;
using Marten;
using Shared;

namespace Commands.Country
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

            var countryId = DocumentSession.Events.StartStream<Domain.Model.Country>(@event);

            DocumentSession.SaveChanges();

            return countryId;
        }
    }
}
