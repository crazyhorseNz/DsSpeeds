using AutoMapper;
using Domain.Events.SpeedClaims;
using Domain.Model;
using Marten;
using Shared;
using System;
using System.Linq;

namespace Commands.SpeedClaims
{
    public class VerifySpeedClaimCommand : BaseCommand, ICommand
    {
        public Guid Id { get; set; }

        public DateTime SpeedVerifiedDate { get; set; }

        public Guid VerifiedById { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<SpeedClaimVerified>(this);
            
            @event.VerifiedByName = session.Query<Person>().Single(a => a.Id == VerifiedById).UserName;

            session.Events.Append(Id, @event);

            session.SaveChanges();

            return null;
        }
    }
}
