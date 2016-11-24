using Commands.SpeedClaims;
using DsSpeeds.Models.SpeedClaims;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Model;

namespace DsSpeeds.Controllers
{
    public class SpeedClaimsController : BaseController
    {
        public SpeedClaimsController(IDocumentSession session, IContainer container) : base(session, container)
        {
        }


        [HttpGet]
        public ActionResult AllVerified()
        {
            ViewBag.Title = "All Verified Speeds";
                
            var allVerified = DocumentSession.Query<RecordedSpeedReadModel>().Where(speed => speed.IsVerified).ToList();

            return View("Index", allVerified);
        }


        [HttpGet]
        public ActionResult AllUnverified()
        {
            ViewBag.Title = "All Unverified Speeds";

            var allUnverified = DocumentSession.Query<RecordedSpeedReadModel>().Where(speed => speed.IsVerified == false).ToList();

            return View("UnverifiedIndex", allUnverified);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var recSpeed = DocumentSession.Load<RecordedSpeedReadModel>(id);

            return View("Details", recSpeed);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.People = DocumentSession.Query<Person>().Select(p => new SelectListItem { Text = p.UserName, Value = p.Id.ToString() }).ToList();
            ViewBag.Aircraft = DocumentSession.Query<Aircraft>().Select(p => new SelectListItem { Text = p.AircraftName, Value = p.Id.ToString() }).ToList();
            ViewBag.Sites = DocumentSession.Query<Site>().Select(p => new SelectListItem { Text = p.SiteName, Value = p.Id.ToString() }).ToList();

            return View("Create", new CreateSpeedClaimCommand());
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