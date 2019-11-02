using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460HW5.Controllers
{
    public class HWTrackerController : Controller
    {

        // GET: HWTracker
        public ActionResult HWCreate()
        {
            return View();
        }
    }
}