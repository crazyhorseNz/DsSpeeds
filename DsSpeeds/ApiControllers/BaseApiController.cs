using Domain.Model;
using Marten;
using StructureMap;
using System;
using System.Linq;
using System.Web.Http;
using Shared;

namespace DsSpeeds.ApiControllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IDocumentSession DocumentSession;
        protected readonly IContainer Container;

        protected BaseApiController(IDocumentSession session, IContainer container)
        {
            DocumentSession = session;
            Container = container;
        }

        public Guid CurrentUser
        {
            // TODO: fix this when we get the auth going...
            get { return DocumentSession.Query<Person>().Single(p => p.UserName == "psmurf").Id; }
        }

        public Guid? ExecuteCommand<T>(T command)
            where T : ICommand
        {
            Container.BuildUp(command);
            command.Validate();
            return command.Execute();
        }

        public TCommand CreateCommand<TCommand>()
            where TCommand : class, ICommand
        {
            return Container.GetInstance<ICommand>(typeof(TCommand).Name) as TCommand;
        }
    }
}