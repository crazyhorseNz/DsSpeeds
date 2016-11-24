using Marten;
using Shared;
using StructureMap;
using System;
using System.Web.Mvc;

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
    }
}