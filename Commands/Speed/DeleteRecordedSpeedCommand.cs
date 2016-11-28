using System;
using System.Linq;
using AutoMapper;
using Data.Queries;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Read.Models;
using Shared;
using Shared.Exceptions;

namespace Commands.Speed
{
    public class DeleteRecordedSpeedCommand : BaseCommand, ICommand
    {
        public DeleteRecordedSpeedCommand()
        {
        }

        public DeleteRecordedSpeedCommand(IDocumentSession docSession) : base(docSession)
        {
        }

        public Guid Id { get; set; }

        public DateTime SpeedDeletionDate { get; set; }

        public Guid DeletedById { get; set; }

        public void Validate()
        {
            if (!DocumentSession.Exists<Domain.Model.Speed>(Id))
                throw new BusinessRuleValidationException("Speed to delete cannot be found. ");

            if (!DocumentSession.Exists<Person>(DeletedById))
                throw new BusinessRuleValidationException("Deleting person cannot be found. ");
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<RecordedSpeedDeleted>(this);

            @event.DeletedByName = DocumentSession.Query<Person>().Single(a => a.Id == DeletedById).UserName;

            DocumentSession.Events.Append(Id, @event);

            DocumentSession.Delete<SpeedReadModel>(@event.Id);

            DocumentSession.SaveChanges();

            return null;
        }

    }
}
