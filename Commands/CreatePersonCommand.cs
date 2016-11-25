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

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<PersonCreated>(this);
        
            var personId = DocumentSession.Events.StartStream<Person>(@event);

            DocumentSession.SaveChanges();

            return personId;

        }
    }
}
