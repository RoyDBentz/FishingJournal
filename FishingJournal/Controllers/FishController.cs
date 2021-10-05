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
    }
}