using Commands;
using Data;
using DsSpeeds.Models.SpeedClaims;
using Read.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Commands.SpeedClaims;
using Marten;
using StructureMap;

namespace DsSpeeds.Controllers
{
    public class SpeedClaimsController : BaseController
    {
        public SpeedClaimsController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }

        // GET: SpeedClaims
        public ActionResult AllVerified()
        {
            ViewBag.Title = "All Verified Speeds";
                
            var allVerified = MartenSession.Query<RecordedSpeedReadModel>().Where(speed => speed.IsVerified).ToList();

            return View("Index", allVerified);

        }

        // GET: SpeedClaims
        public ActionResult AllUnverified()
        {
            ViewBag.Title = "All Unverified Speeds";

            var allUnverified = MartenSession.Query<RecordedSpeedReadModel>().Where(speed => speed.IsVerified == false).ToList();

            return View("UnverifiedIndex", allUnverified);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Details(Guid id)
        {
            var recSpeed = MartenSession.Query<RecordedSpeedReadModel>().Single(speed => speed.Id == id);

            return View("Details", recSpeed);
        }

        [HttpPost]
        public ActionResult Create(CreateSpeedClaimCommand speedClaim)
        {
            //speedClaim.Execute();
            ExecuteCommand(speedClaim);

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