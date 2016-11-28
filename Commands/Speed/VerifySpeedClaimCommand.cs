using System;
using System.Linq;
using AutoMapper;
using Data.Queries;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Shared;
using Shared.Exceptions;

namespace Commands.Speed
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
            if (!DocumentSession.Exists<Domain.Model.Speed>(Id))
                throw new BusinessRuleValidationException("Speed to verify cannot be found. ");

            if (!DocumentSession.Exists<Person>(VerifiedById))
                throw new BusinessRuleValidationException("Verifying person cannot be found. ");

            var speedClaim = DocumentSession.Load<Domain.Model.Speed>(Id);
            if (speedClaim.PilotId == VerifiedById)
                throw new BusinessRuleValidationException("A speed claim must be verified by someone other than the pilot.");
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
