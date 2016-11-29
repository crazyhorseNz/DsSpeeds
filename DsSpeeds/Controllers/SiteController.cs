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
    public class SiteController : BaseController
    {
        public SiteController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: Site
        public ActionResult Index()
        {
            var allSites = DocumentSession.Query<SiteReadModel>().ToList();

            return View("Index", allSites);
        }

        public ActionResult Details(Guid id)
        {
            var siteData = DocumentSession.Load<SiteReadModel>(id);

            var model = new SpeedListModel
            {
                SpeedList = siteData.AllVerifiedSiteSpeeds
                    .Select(summary => new SpeedReadModel
                    {
                        Date = summary.Date,
                        SpeedInMilesPerHour = summary.SpeedInMilesPerHour,
                        AircraftName = summary.AircraftName,
                        PilotName = summary.PilotName,
                        SiteName = siteData.SiteName,
                        SiteLocation = siteData.Location,
                        SiteCountryName = siteData.CountryName
                    }).ToList()
            };

            return View("Details", model);
        }
    }
}