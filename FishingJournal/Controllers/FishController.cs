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
    public class FishController : Controller
    {
        [Authorize]
        // GET: Fish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fish
        public ActionResult Create()
        {
            return View();
        }

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FishCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFishService();

            if (service.CreateFishService(model))
            {
                TempData["SaveResult"] = "Your entry was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Entry could not be created");

            return View(model);
        } */

        private FishService CreateFishService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FishService(userId);
            return service;
        }
    }
}