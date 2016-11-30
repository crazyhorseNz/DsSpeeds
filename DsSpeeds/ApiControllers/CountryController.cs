using Commands.Country;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DsSpeeds.ApiControllers
{
    public class CountryController : BaseApiController
    {
        public CountryController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }


        public IEnumerable<CountryReadModel> Get()
        {
            return DocumentSession.Query<CountryReadModel>().AsEnumerable();
        }

        public CountryReadModel Get(Guid id)
        {
            return DocumentSession.Load<CountryReadModel>(id);
        }

        //// POST: api/Aircraft
        //public void Post([FromBody]EditPersonCommand command)
        //{
        //    throw new NotImplementedException("Someone implement me please...");
        //}

        public void Put(int id, [FromBody]CreateCountryCommand command)
        {
            ExecuteCommand(command);
        }


        public void Delete(Guid id)
        {
            throw new NotImplementedException("Someone implement me please...");
        }

    }
}
