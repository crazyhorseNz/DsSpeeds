using Commands.SpeedClaims;
using DsSpeeds.Models.SpeedClaims;
using Marten;
using Read.Models;
using StructureMap;
using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Model;
using DsSpeeds.Models;

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
            var model = new SpeedListModel
            {
                SpeedList = DocumentSession.Query<RecordedSpeedReadModel>().Where(speed => speed.IsVerified && !speed.IsDeleted).ToList()
            };

            return View("Index", model);
        }


        [HttpGet]
        public ActionResult AllUnverified()
        {
            ViewBag.Title = "All Unverified Speeds";

            var model = new SpeedListModel
            {
                SpeedList = DocumentSession.Query<RecordedSpeedReadModel>().Where(speed => !speed.IsVerified && !speed.IsDeleted).ToList()
            };

            return View("UnverifiedIndex", model);
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

            return View("Create", new CreateSpeedClaimCommand(DocumentSession));
        }

        [HttpPost]
        public ActionResult Create(CreateSpeedClaimCommand speedClaim)
        {
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

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var command = new DeleteRecordedSpeedCommand(DocumentSession)
            {
                Id = id,
                SpeedDeletionDate = DateTime.Today,
                DeletedById = CurrentUser
            };

            ExecuteCommand(command);

            return RedirectToAction("AllVerified");
        }

        [HttpPost]
        public ActionResult Verify(Guid id)
        {
            var command = CreateCommand<VerifySpeedClaimCommand>();
            command.Id = id;
            command.SpeedVerifiedDate = DateTime.Today;
            command.VerifiedById = CurrentUser;

            ExecuteCommand(command);

            return RedirectToAction("AllVerified");
        }

    }
}