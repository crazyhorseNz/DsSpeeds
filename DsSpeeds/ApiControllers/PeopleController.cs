using Commands;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Commands.People;

namespace DsSpeeds.ApiControllers
{
    public class PeopleController : BaseApiController
    {
        public PeopleController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: api/Person
        public IEnumerable<PersonReadModel> Get()
        {
            return DocumentSession.Query<PersonReadModel>().AsEnumerable();
        }

        // GET: api/Person/5
        public PersonReadModel Get(Guid id)
        {
            return DocumentSession.Load<PersonReadModel>(id);
        }

        //// POST: api/Person
        //public void Post([FromBody]EditPersonCommand command)
        //{
        //    throw new NotImplementedException("Someone implement me please...");
        //}

        // PUT: api/Person/5
        public void Put(int id, [FromBody]CreatePersonCommand command)
        {
            ExecuteCommand(command);
        }


        // DELETE: api/Person/5
        public void Delete(Guid id)
        {
            throw new NotImplementedException("Someone implement me please...");
        }

    }
}
