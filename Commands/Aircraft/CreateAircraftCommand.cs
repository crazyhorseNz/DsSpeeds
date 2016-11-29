using System;
using AutoMapper;
using Domain.Events;
using Marten;
using Shared;

namespace Commands.Aircraft
{
    public class CreateAircraftCommand : BaseCommand, ICommand
    {
        public CreateAircraftCommand()
        {
        }

        public CreateAircraftCommand(IDocumentSession docSession) 
            : base(docSession)
        {
        }

        public string AircraftName { get; set; }

        public string PlaneManufacturer { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<AircraftCreated>(this);

            var id = DocumentSession.Events.StartStream<Domain.Model.Aircraft>(@event);

            DocumentSession.SaveChanges();

            return id;
        }

    }
}
