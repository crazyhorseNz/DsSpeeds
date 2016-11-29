using Commands.Speed;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DsSpeeds.ApiControllers
{
    public class SpeedController : BaseApiController
    {
        public SpeedController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: api/Speed
        public IEnumerable<SpeedReadModel> Get()
        {
            return DocumentSession.Query<SpeedReadModel>().AsEnumerable();
        }

        // GET: api/Speed/5
        public SpeedReadModel Get(Guid id)
        {
            return DocumentSession.Load<SpeedReadModel>(id);
        }

        // POST: api/Speed
        public void Post([FromBody]EditSpeedClaimCommand command)
        {
            ExecuteCommand(command);
        }

        // PUT: api/Speed/5
        public void Put(int id, [FromBody]CreateSpeedClaimCommand command)
        {
            ExecuteCommand(command);
        }

        // PUT: api/Speed/5
        public void Put(int id, [FromBody]VerifySpeedClaimCommand command)
        {
            ExecuteCommand(command);
        }

        // DELETE: api/Speed/5
        public void Delete(Guid id)
        {
            var command = CreateCommand<DeleteRecordedSpeedCommand>();
            command.DeletedById = CurrentUser;
            command.Id = id;

            ExecuteCommand(command);
        }

    }
}
