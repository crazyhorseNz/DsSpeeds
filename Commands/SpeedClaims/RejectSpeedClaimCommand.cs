using AutoMapper;
using Domain.Events.SpeedClaims;
using Domain.Model;
using Marten;
using Shared;
using System;
using System.Linq;

namespace Commands.SpeedClaims
{
    public class RejectSpeedClaimCommand : BaseCommand, ICommand
    {
        public Guid Id { get; set; }

        public DateTime SpeedRejectionDate { get; set; }

        public Guid RejectedById { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<SpeedClaimRejected>(this);

            @event.RejectedByName = session.Query<Person>().Single(a => a.Id == RejectedById).UserName;

            var speedRecordId = session.Events.StartStream<RecordedSpeed>(@event);

            session.SaveChanges();

            return speedRecordId;
        }
    }
}
