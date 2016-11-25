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
        public VerifySpeedClaimCommand()
        {
        }

        public VerifySpeedClaimCommand(IDocumentSession docSession) : base(docSession)
        {
        }

        public Guid Id { get; set; }

        public DateTime SpeedVerifiedDate { get; set; }

        public Guid VerifiedById { get; set; }

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SpeedClaimVerified>(this);
            
            @event.VerifiedByName = DocumentSession.Query<Person>().Single(a => a.Id == VerifiedById).UserName;

            DocumentSession.Events.Append(Id, @event);

            DocumentSession.SaveChanges();

            return null;
        }

    }
}
