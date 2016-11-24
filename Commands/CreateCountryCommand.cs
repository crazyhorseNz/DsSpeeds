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

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<CountryCreated>(this);

            var countryId = session.Events.StartStream<Country>(@event);

            session.SaveChanges();

            return countryId;
        }
    }
}
