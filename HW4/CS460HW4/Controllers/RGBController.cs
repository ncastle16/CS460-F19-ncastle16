using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460HW4.Controllers
{
    public class RGBController : Controller
    {
        // GET: RGB
        public ActionResult RGB()
        {
            string red = Request["Red"];
            string green = Request["Green"];
            string blue = Request["Blue"];
            ViewBag.red = red;
            ViewBag.green = green;
            ViewBag.blue = blue;
            return View();
        }


        [HttpPost]
        public ActionResult RGB(int Red, int Green, int Blue)
        {
            return View();
        }
    }
}