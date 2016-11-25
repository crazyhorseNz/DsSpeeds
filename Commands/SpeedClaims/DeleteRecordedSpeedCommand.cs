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

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<RecordedSpeedDeleted>(this);

            @event.DeletedByName = session.Query<Person>().Single(a => a.Id == DeletedById).UserName;

            session.Events.Append(Id, @event);

            session.Delete<RecordedSpeedReadModel>(@event.Id);

            session.SaveChanges();

            return null;
        }

    }
}
