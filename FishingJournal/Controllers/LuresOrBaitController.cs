using FishingJournal.Models;
using FishingJournal.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingJournal.Controllers
{
    public class LuresOrBaitController : Controller
    {
        [Authorize]
        // GET: LuresOrBait
        public ActionResult Index()
        {
            return View();
        }

        // GET: LuresOrBait
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LuresOrBaitCreate lure)
        {
            if (!ModelState.IsValid) return View(lure);

            var service = CreateLuresOrBaitService();

            if (service.CreateLure(lure))
            {
                TempData["SaveResult"] = "Your entry was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Entry could not be created");

            return View(lure);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLuresOrBaitService();
            var lure = svc.GetLuresById(id);

            return View(lure);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLuresOrBaitService();
            var detail = service.GetLuresById(id);
            var lure =
                    new LuresOrBaitEdit
                    {
                        LureId = detail.LureId,
                        LureName = detail.LureName
                    };

            return View(lure);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLuresOrBaitService();
            var lure = svc.GetLuresById(id);

            return View(lure);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLuresOrBait(int id)
        {
            var service = CreateLuresOrBaitService();
            service.DeleteLure(id);
            TempData["SaveResult"] = "Your entry was deleted.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LuresOrBaitEdit lure)
        {
            if (!ModelState.IsValid) return View(lure);

            if (lure.LureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(lure);
            }

            var service = CreateLuresOrBaitService();

            if (service.UpdateLure(lure))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View();
        }

        private LuresOrBaitService CreateLuresOrBaitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LuresOrBaitService(userId);
            return service;
        }
    }
}