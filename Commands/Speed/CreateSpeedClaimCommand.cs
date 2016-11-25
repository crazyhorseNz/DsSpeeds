using System;
using System.Linq;
using AutoMapper;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Shared;

namespace Commands.Speed
{
    public class CreateSpeedClaimCommand : BaseCommand, ICommand
    {
        public CreateSpeedClaimCommand()
        {
        }

        public CreateSpeedClaimCommand(IDocumentSession docSession) : base(docSession)
        {
        }

        public DateTime SpeedClaimedDate { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public string Notes { get; set; }

        public Guid PilotId { get; set; }

        public Guid WitnessId { get; set; }

        public Guid SiteId { get; set; }

        public Guid AircraftId { get; set; }

        public void Validate()
        {
        }

        public Guid? Execute()
        {
            var @event = Mapper.Map<SpeedClaimCreated>(this);

            @event.PilotName = DocumentSession.Query<Person>().Single(a => a.Id == PilotId).UserName;
            @event.WitnessName = DocumentSession.Query<Person>().Single(a => a.Id == WitnessId).UserName;
            @event.SiteName = DocumentSession.Query<Site>().Single(a => a.Id == SiteId).SiteName;
            @event.AircraftName = DocumentSession.Query<Aircraft>().Single(a => a.Id == AircraftId).AircraftName;

            var speedRecordId = DocumentSession.Events.StartStream<Domain.Model.Speed>(@event);

            DocumentSession.SaveChanges();

            return speedRecordId;
        }

    }
}
