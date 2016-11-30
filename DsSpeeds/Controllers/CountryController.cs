using DsSpeeds.Models.Country;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DsSpeeds.Controllers
{
    public class CountryController : BaseController
    {
        public CountryController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }
        
        public ActionResult Index()
        {
            var allCountries = DocumentSession.Query<CountryReadModel>().ToList();

            return View("Index", allCountries);
        }

        public ActionResult Details(Guid id)
        {
            var personReadModel = DocumentSession.Load<CountryReadModel>(id);

            var model = new CountryModel(personReadModel);

            return View("Details", model);
        }
    }
}