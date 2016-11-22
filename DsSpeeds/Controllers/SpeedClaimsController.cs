using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Events;
using DsSpeeds.Models.SpeedClaims;

namespace DsSpeeds.Controllers
{
    public class SpeedClaimsController : Controller
    {
        // GET: SpeedClaims
        public ActionResult AllVerified()
        {
            ViewBag.Title = "All Verified Speeds";

            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                var all = session.Query<SpeedClaimModel>()
                    .Where(rs => rs.IsVerified)
                    .OrderByDescending(rs => rs.SpeedInMilesPerHour)
                    .ToList();

                return View("Index", all);
            }
        }

        // GET: SpeedClaims
        public ActionResult AllUnverified()
        {
            ViewBag.Title = "All Unverified Speeds";

            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                var all = session.Query<SpeedClaimModel>()
                    .Where(rs => rs.IsVerified == false)
                    .OrderByDescending(rs => rs.SpeedInMilesPerHour)
                    .ToList();

                return View("UnverifiedIndex", all);
            }
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Details(string id)
        {
            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                var recSpeed = session.Load<SpeedClaimModel>(id);

                return View("Details", recSpeed);
            }

        }

        [HttpPost]
        public ActionResult Create(SpeedClaimModel speed)
        {
            //speed.LastUpdatedBy = User.Identity.Name;
            //speed.LastUpdatedOn = DateTime.Now;
            //speed.ReportingUserName = User.Identity.Name;
            ////DocumentSession.Store(speed);
            /// 

            using (var session = MartenDocumentStore.Store.LightweightSession())
            {
                session.Events.StartStream<SpeedClaimCreated>();
                session.Events.Append();
            }




            return RedirectToAction("AllUnverified");
        }


        public ActionResult Edit(string id)
        {
            //var recSpeed = DocumentSession.Load<RecordedSpeed>(id);

            //return View("Edit", recSpeed);
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Edit(SpeedClaimModel speed)
        {
            speed.LastUpdatedBy = User.Identity.Name;
            speed.LastUpdatedOn = DateTime.Now;

            //DocumentSession.Store(speed);

            return RedirectToAction("AllVerified");
        }

        public ActionResult Delete(string id)
        {
            //var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
            //DocumentSession.Delete<RecordedSpeed>(recSpeed);

            return RedirectToAction("AllVerified");
        }

        public ActionResult DeleteUnverified(string id)
        {
           // var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
           // DocumentSession.Delete<RecordedSpeed>(recSpeed);

            return RedirectToAction("AllUnverified");
        }

        public ActionResult Verify(string id)
        {
            //var recSpeed = DocumentSession.Load<RecordedSpeed>(id);
            //recSpeed.IsVerified = true;
            //recSpeed.VerifyingUserName = User.Identity.Name;
            //recSpeed.LastUpdatedBy = User.Identity.Name;
            //recSpeed.LastUpdatedOn = DateTime.Now;

            //DocumentSession.Store(recSpeed);

            return RedirectToAction("Details", new { id });
        }
    }
}