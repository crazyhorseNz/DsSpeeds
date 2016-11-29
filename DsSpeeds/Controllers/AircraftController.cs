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

            var model = new SpeedListModel
            {
                SpeedList = aircraftReadModel.AllVerifiedSpeeds
                    .Select(summary => new SpeedReadModel
                    {
                        Id = summary.SpeedId,
                        Date = summary.Date,
                        SpeedInMilesPerHour = summary.SpeedInMilesPerHour,
                        AircraftName = aircraftReadModel.AircraftName,
                        PilotName = summary.PilotName,
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