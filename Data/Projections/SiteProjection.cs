//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Domain.Events.Site;
//using Domain.Events.Speed;
//using Marten;
//using Marten.Events;
//using Marten.Events.Projections;
//using Marten.Events.Projections.Async;
//using Read.Models;

//namespace Data.Projections
//{
//    public class SiteProjection : IProjection
//    {
//        public void Apply(IDocumentSession session, EventStream[] streams)
//        {
//            foreach (var stream in streams)
//            {

//            }
//        }

//        public Type[] Consumes => new[] { typeof(SiteUpdated) };

//        public Type Produces => typeof (SpeedReadModel);

//        public AsyncOptions AsyncOptions { get; }
    

//        public Task ApplyAsync(IDocumentSession session, EventStream[] streams, System.Threading.CancellationToken token)
//        {
//            return Task.CompletedTask;
//        }
//    }
//}
