using System;
using Domain.Events;
using Domain.Events.Site;
using Domain.Events.Speed;
using Domain.Model;
using Marten;
using Read.Models;

namespace Data
{
    public static class MartenDocumentStore
    {
        public static IDocumentStore Store { get; set; }

        public static void BootMartenDocumentStore()
        {
            Store = DocumentStore.For(StoreOptions);
        }


        public static Action<StoreOptions> StoreOptions
        {
            get
            {
                return store =>
                {
                    store.Connection("host=localhost;database=dsspeeds;password=Password1.;username=dsspeedsuser");
                    store.AutoCreateSchemaObjects = AutoCreate.All;

                    // Register Events
                    store.Events.AddEventType(typeof(SpeedClaimCreated));
                    store.Events.AddEventType(typeof(SpeedClaimEdited));
                    store.Events.AddEventType(typeof(SpeedClaimVerified));
                    store.Events.AddEventType(typeof(RecordedSpeedDeleted));
                    store.Events.AddEventType(typeof(AircraftCreated));
                    store.Events.AddEventType(typeof(SiteCreated));
                    store.Events.AddEventType(typeof(SiteUpdated));
                    store.Events.AddEventType(typeof(PersonCreated));

                    // Domain objects updated from Events.
                    store.Events.InlineProjections.AggregateStreamsWith<Person>();
                    store.Events.InlineProjections.AggregateStreamsWith<Site>();
                    store.Events.InlineProjections.AggregateStreamsWith<Aircraft>();
                    store.Events.InlineProjections.AggregateStreamsWith<Country>();
                    store.Events.InlineProjections.AggregateStreamsWith<Speed>();
                    
                    // Read Models updated from Events.
                    store.Events.InlineProjections.AggregateStreamsWith<SiteReadModel>();
                    store.Events.InlineProjections.AggregateStreamsWith<SpeedReadModel>();
                    store.Events.InlineProjections.AggregateStreamsWith<PersonReadModel>();
                    store.Events.InlineProjections.AggregateStreamsWith<AircraftReadModel>();
                    store.Events.InlineProjections.AggregateStreamsWith<CountryReadModel>();
                };
            }
        }

    }
}