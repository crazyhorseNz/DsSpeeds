﻿using System;
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
            var model = new SpeedListModel
            {
                SpeedList = DocumentSession.Query<SpeedReadModel>().Where(s => s.SiteId == id).ToList()
            };

            return View("Details", model);
        }
    }
}