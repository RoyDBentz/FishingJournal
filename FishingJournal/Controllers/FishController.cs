using FishingJournal.Models;
using FishingJournal.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingJournal.Controllers
{
    [Authorize]
    public class FishController : Controller
    {        
        // GET: Fish
        public ActionResult Index()
        {
            var service = CreateFishService();
            var fish = service.GetFishes();

            return View(fish);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FishCreate fish)
        {
            if (!ModelState.IsValid) return View(fish);

            var service = CreateFishService();

            if (service.CreateFish(fish))
            {
                TempData["SaveResult"] = "Your entry was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Entry could not be created");

            return View(fish);
        }       

        public ActionResult Details(int id)
        {
            var svc = CreateFishService();
            var fish = svc.GetFishById(id);

            return View(fish);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFishService();
            var detail = service.GetFishById(id);
            var fish =
                    new FishEdit
                    {FishId = detail.FishId,
                        Species = detail.Species,
                        AverageSize = detail.AverageSize,
                        AverageWeight = detail.AverageWeight,
                    };

            return View(fish);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFishService();
            var fish = svc.GetFishById(id);

            return View(fish);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFish(int id)
        {
            var service = CreateFishService();
            service.DeleteFish(id);
            TempData["SaveResult"] = "Your entry was deleted.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FishEdit fish)
        {
            if (!ModelState.IsValid) return View(fish);

            if (fish.FishId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(fish);
            }

            var service = CreateFishService();

            if (service.UpdateFish(fish))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View();
        }

        private FishService CreateFishService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FishService(userId);
            return service;
        }
    }
}