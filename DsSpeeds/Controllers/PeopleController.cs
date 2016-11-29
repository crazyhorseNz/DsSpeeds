using System;
using System.Collections.Generic;
using Marten;
using Read.Models;
using StructureMap;
using System.Linq;
using System.Web.Mvc;
using DsSpeeds.Models;

namespace DsSpeeds.Controllers
{
    public class PeopleController : BaseController
    {
        public PeopleController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: Site
        public ActionResult Index()
        {
            var allSites = DocumentSession.Query<PersonReadModel>().ToList();

            return View("Index", allSites);
        }

        public ActionResult Details(Guid id)
        {
            var personData = DocumentSession.Load<PersonReadModel>(id);

            var model = new SpeedListModel
            {
                SpeedList = personData.AllVerifiedSiteSpeeds
                    .Select(summary => new SpeedReadModel
                    {
                        Id = summary.SpeedId,
                        Date = summary.Date,
                        SpeedInMilesPerHour = summary.SpeedInMilesPerHour,
                        AircraftName = summary.AircraftName,
                        PilotName = personData.PersonName,
                        SiteName = summary.SiteName,
                        SiteLocation = summary.SiteLocation,
                        SiteCountryName = summary.SiteCountryName,
                        IsVerified = true
                    }).ToList()
            };

            return View("Details", model);
        }
    }
}