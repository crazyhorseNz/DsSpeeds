using AutoMapper;
using Domain.Events;
using Domain.Model;
using Marten;
using Shared;
using System;

namespace Commands
{
    public class CreatePersonCommand : BaseCommand, ICommand
    {
        public CreatePersonCommand()
        {
        }

        public CreatePersonCommand(IDocumentSession docSession) 
            : base(docSession)
        {
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<PersonCreated>(this);
        
            var personId = session.Events.StartStream<Person>(@event);

            session.SaveChanges();

            return personId;

        }
    }
}
