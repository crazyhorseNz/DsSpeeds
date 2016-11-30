using DsSpeeds.Models.People;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DsSpeeds.Controllers
{
    public class PeopleController : BaseController
    {
        public PeopleController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }
        
        public ActionResult Index()
        {
            var allSites = DocumentSession.Query<PersonReadModel>().ToList();

            return View("Index", allSites);
        }

        public ActionResult Details(Guid id)
        {
            var personReadModel = DocumentSession.Load<PersonReadModel>(id);

            var model = new PersonModel(personReadModel);

            return View("Details", model);
        }
    }
}