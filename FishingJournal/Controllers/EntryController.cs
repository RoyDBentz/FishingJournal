using FishingJournal.Data;
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
    [Authorize]
    public class EntryController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Entry
        public ActionResult Index()
        {
            List<EntryListItem> entries = _db.Entries.Select(e => new EntryListItem()
            {
                Species = e.Fish.Species,
                LureName = e.LuresOrBait.LureName
            }).ToList();

            var service = CreateEntryService();
            var model = service.GetEntries();
            
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            EntryCreate model = new EntryCreate();

            var fish = _db.Fishes.ToList();
            model.Species = new SelectList(fish, "FishId", "Species");

            var lures = _db.LuresOrBaits.ToList();
            model.Lures = new SelectList(lures, "LureId", "LureName");

            return View(model);
        }

        // POST: Entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntryCreate model)
        {
            if (ModelState.IsValid)
            {
                Entry entry = new Entry()
                {
                    FishId = model.FishId,
                    LureId = model.LureId
                };
                _db.Entries.Add(entry);
                _db.SaveChanges();
                // return RedirectToAction("Index");                
            }
            var service = CreateEntryService();

            if (service.CreateEntry(model))
            {
                TempData["SaveResult"] = "Your entry was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Entry could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEntryService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEntryService();
            var detail = service.GetEntryById(id);
            var model =
                    new EntryEdit
                    {
                        EntryId = detail.EntryId,
                        JournalDate = detail.JournalDate,
                        Notes = detail.Notes
                    };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEntryService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEntry (int id)
        {
            var service = CreateEntryService();
            service.DeleteEntry(id);
            TempData["SaveResult"] = "Your entry was deleted.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EntryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EntryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEntryService();

            if (service.UpdateEntry(model))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View();
        }

        private EntryService CreateEntryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EntryService(userId);
            return service;
        }
    }
}