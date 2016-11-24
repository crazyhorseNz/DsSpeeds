using System;
using AutoMapper;
using Data;
using Domain.Events;
using Domain.Model;
using Marten;
using Shared;

namespace Commands
{
    public class CreateCountryCommand : BaseCommand, ICommand
    {
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
