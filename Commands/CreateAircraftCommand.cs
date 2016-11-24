using AutoMapper;
using Domain.Events;
using Domain.Model;
using Marten;
using Shared;
using System;

namespace Commands
{
    public class CreateAircraftCommand : BaseCommand, ICommand
    {
        public string AircraftName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<AircraftCreated>(this);

            var id = session.Events.StartStream<Aircraft>(@event);

            session.SaveChanges();

            return id;
        }
    }
}
