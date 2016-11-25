using AutoMapper;
using Domain.Events.SpeedClaims;
using Domain.Model;
using Marten;
using Shared;
using System;
using System.Linq;
using Read.Models;

namespace Commands.SpeedClaims
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
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<RecordedSpeedDeleted>(this);

            @event.DeletedByName = DocumentSession.Query<Person>().Single(a => a.Id == DeletedById).UserName;

            DocumentSession.Events.Append(Id, @event);

            DocumentSession.Delete<RecordedSpeedReadModel>(@event.Id);

            DocumentSession.SaveChanges();

            return null;
        }

    }
}
