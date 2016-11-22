using Domain.Events;
using Marten;

namespace DsSpeeds
{
    public static class MartenDocumentStore
    {
        public static IDocumentStore Store { get; set; }

        public static void BootMartenDocumentStore()
        {
            Store = DocumentStore.For(store =>
            {
                store.Connection("host=localhost;database=dsspeeds;password=Password1.;username=dsspeedsuser");
                store.AutoCreateSchemaObjects = AutoCreate.All;

                store.Events.AddEventType(typeof(SpeedClaimCreated));
                store.Events.AddEventType(typeof(SpeedClaimVerified));
                store.Events.AddEventType(typeof(SpeedClaimRejected));

                store.Events.AddEventType(typeof(AircraftTypeCreated));
                store.Events.AddEventType(typeof(SiteCreated));

                
            });
        }
    }
}