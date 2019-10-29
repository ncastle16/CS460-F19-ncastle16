using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460HW4.Controllers
{
    public class InterporlatorController : Controller
    {
        // GET: Interporlator
        public ActionResult Interporlator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Interporlator(string FirstColor, string SecondColor, int? Amount)
        {
            ViewBag.FC = FirstColor;
            ViewBag.SC = SecondColor;
            ViewBag.Amount = Amount;

            return View();
        }
    }
}