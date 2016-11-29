using Commands.Aircraft;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DsSpeeds.ApiControllers
{
    public class AircraftController : BaseApiController
    {
        public AircraftController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: api/Aircraft
        public IEnumerable<AircraftReadModel> Get()
        {
            return DocumentSession.Query<AircraftReadModel>().AsEnumerable();
        }

        // GET: api/Aircraft/5
        public AircraftReadModel Get(Guid id)
        {
            return DocumentSession.Load<AircraftReadModel>(id);
        }

        //// POST: api/Aircraft
        //public void Post([FromBody]EditPersonCommand command)
        //{
        //    throw new NotImplementedException("Someone implement me please...");
        //}

        // PUT: api/Aircraft/5
        public void Put(int id, [FromBody]CreateAircraftCommand command)
        {
            ExecuteCommand(command);
        }


        // DELETE: api/Aircraft/5
        public void Delete(Guid id)
        {
            throw new NotImplementedException("Someone implement me please...");
        }

    }
}
