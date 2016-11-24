using Marten;
using Shared;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Model;

namespace DsSpeeds.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IDocumentSession DocumentSession;
        protected readonly IContainer Container;

        protected BaseController(IDocumentSession session, IContainer container)
        {
            DocumentSession = session;
            Container = container;
        }

        public Guid? ExecuteCommand<T>()
            where T : class, ICommand
        {
            return Container.GetInstance<T>(nameof(T)).Execute(DocumentSession);
        }
        public Guid? ExecuteCommand<T>(T command)
            where T : class, ICommand
        {
            Container.BuildUp(command);
            return command.Execute(DocumentSession);
        }

        public Guid CurrentUser
        {
            // TODO: fix this when we get the auth going...
            get { return DocumentSession.Query<Person>().Single(p => p.UserName == "psmurf").Id; }
        }


        public TCommand CreateCommand<TCommand>()
            where TCommand : ICommand
        {
            return Container.GetInstance<TCommand>(nameof(TCommand));
        }
    }
}