using System;
using System.Linq;
using AutoMapper;
using Domain.Events.SpeedClaims;
using Domain.Model;
using Marten;
using Shared;

namespace Commands.SpeedClaims
{
    public class CreateSpeedClaimCommand : BaseCommand, ICommand
    {
        public DateTime SpeedClaimedDate { get; set; }

        public long SpeedInMilesPerHour { get; set; }

        public string Notes { get; set; }

        public Guid PilotId { get; set; }

        public Guid WitnessId { get; set; }

        public Guid SiteId { get; set; }

        public Guid AircraftId { get; set; }

        public void Validate(IDocumentSession session)
        {
        }

        public Guid? Execute(IDocumentSession session)
        {
            var @event = Mapper.Map<SpeedClaimCreated>(this);

            @event.PilotName = session.Query<Person>().Single(a => a.Id == PilotId).UserName;
            @event.WitnessName = session.Query<Person>().Single(a => a.Id == WitnessId).UserName;
            @event.SiteName = session.Query<Site>().Single(a => a.Id == SiteId).SiteName;
            @event.AircraftName = session.Query<Aircraft>().Single(a => a.Id == AircraftId).AircraftName;

            var speedRecordId = session.Events.StartStream<RecordedSpeed>(@event);

            session.SaveChanges();

            return speedRecordId;
        }
    }
}
