using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingJournal.Controllers
{
    public class LuresOrBaitController : Controller
    {
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
    }
}