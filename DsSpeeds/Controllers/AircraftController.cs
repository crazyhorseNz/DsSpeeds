using DsSpeeds.Models.Aircraft;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DsSpeeds.Controllers
{
    public class AircraftController : BaseController
    {
        public AircraftController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: Site
        public ActionResult Index()
        {
            var allSites = DocumentSession.Query<AircraftReadModel>().ToList();

            return View("Index", allSites);
        }

        public ActionResult Details(Guid id)
        {
            var aircraftReadModel = DocumentSession.Load<AircraftReadModel>(id);

            var model = new AircraftModel(aircraftReadModel);

            return View("Details", model);
        }
    }
}