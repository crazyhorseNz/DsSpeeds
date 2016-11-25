using System;
using System.Linq;
using AutoMapper;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Read.Models;
using Shared;

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
