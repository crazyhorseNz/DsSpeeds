using Commands.Site;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DsSpeeds.ApiControllers
{
    public class SiteController : BaseApiController
    {
        public SiteController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: api/Site
        public IEnumerable<SiteReadModel> Get()
        {
            return DocumentSession.Query<SiteReadModel>().AsEnumerable();
        }

        // GET: api/Site/5
        public SiteReadModel Get(Guid id)
        {
            return DocumentSession.Load<SiteReadModel>(id);
        }

        // POST: api/Site
        public void Post([FromBody]EditSiteCommand command)
        {
            ExecuteCommand(command);
        }

        // PUT: api/Site/5
        public void Put(int id, [FromBody]CreateSiteCommand command)
        {
            ExecuteCommand(command);
        }


        // DELETE: api/Site/5
        public void Delete(Guid id)
        {
            throw new NotImplementedException("Someone implement me please...");
        }

    }
}
