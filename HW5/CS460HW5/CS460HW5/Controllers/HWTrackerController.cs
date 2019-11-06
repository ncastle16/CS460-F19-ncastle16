using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460HW5.DAL;
using CS460HW5.Models;

namespace CS460HW5.Controllers
{
    public class HWTrackerController : Controller
    {
        private AssignmentContext db = new AssignmentContext();

        // GET: Users
        public ActionResult Index()
        {
            var Assignments = db.Assignments.OrderBy(s => s.DueDate);
            return View(Assignments.ToList());
        }

        // GET: Users/Create
        public ActionResult HWCreate()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult HWCreate([Bind(Include = "ID, PriorityOrder, DueDate, Department, DueTime, CourseID, HomeworkTitle, Notes")] Assignment user)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult HWDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment user = db.Assignments.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("HWDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment user = db.Assignments.Find(id);
            db.Assignments.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}