using DsSpeeds.Models.RecordedSpeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DsSpeeds.Controllers
{
    public class RecordedSpeedsController : RavenDbController
    {
        // GET: RecordedSpeeds
        public ActionResult AllVerified()
        {
            var all = DocumentSession.Query<RecordedSpeed>()
                .Where(rs => rs.IsVerified)
                .OrderByDescending(rs => rs.SpeedInMilesPerHour)
                .ToList();

            ViewBag.Title = "All Verified Speeds";

            return View("Index", all);
        }

        // GET: RecordedSpeeds
        public ActionResult AllUnverified()
        {
            var all = DocumentSession.Query<RecordedSpeed>()
                .Where(rs => rs.IsVerified == false)
                .OrderByDescending(rs => rs.SpeedInMilesPerHour)
                .ToList();

            ViewBag.Title = "All Unverified Speeds";

            return View("UnverifiedIndex", all);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Details(string id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeed>(id);

            return View("Details", recSpeed);
        }

        [HttpPost]
        public ActionResult Create(RecordedSpeed speed)
        {
            speed.LastUpdatedBy = User.Identity.Name;
            speed.LastUpdatedOn = DateTime.Now;
            speed.ReportingUserName = User.Identity.Name;
            DocumentSession.Store(speed);

            return RedirectToAction("AllUnverified");
        }


        public ActionResult Edit(string id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeed>(id);

            return View("Edit", recSpeed);
        }

        [HttpPost]
        public ActionResult Edit(RecordedSpeed speed)
        {
            speed.LastUpdatedBy = User.Identity.Name;
            speed.LastUpdatedOn = DateTime.Now;

            DocumentSession.Store(speed);

            return RedirectToAction("AllVerified");
        }

        public ActionResult Delete(string id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
            DocumentSession.Delete<RecordedSpeed>(recSpeed);

            return RedirectToAction("AllVerified");
        }

        public ActionResult DeleteUnverified(string id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
            DocumentSession.Delete<RecordedSpeed>(recSpeed);

            return RedirectToAction("AllUnverified");
        }

        public ActionResult Verify(string id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
            recSpeed.IsVerified = true;
            recSpeed.VerifyingUserName = User.Identity.Name;
            recSpeed.LastUpdatedBy = User.Identity.Name;
            recSpeed.LastUpdatedOn = DateTime.Now;

            DocumentSession.Store(recSpeed);

            return RedirectToAction("Details", new { id });
        }
    }
}