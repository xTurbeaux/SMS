using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.DATA.EF;

namespace SMS.UI.MVC.Controllers
{
    public class LessonsViewedController : Controller
    {
        private SMSEntities db = new SMSEntities();

        // GET: LessonsViewed
        public ActionResult Index()
        {
            var lessonsVieweds = db.LessonsVieweds.Include(l => l.Lesson).Include(l => l.UserDetail);
            return View(lessonsVieweds.ToList());
        }

        // GET: LessonsViewed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LessonsViewed lessonsViewed = db.LessonsVieweds.Find(id);
            if (lessonsViewed == null)
            {
                return HttpNotFound();
            }
            return View(lessonsViewed);
        }

        // GET: LessonsViewed/Create
        public ActionResult Create()
        {
            ViewBag.LessonID = new SelectList(db.Lessons1, "LessonID", "LessonTitle");
            ViewBag.UserID = new SelectList(db.UserDetails1, "UserID", "FirstName");
            return View();
        }

        // POST: LessonsViewed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonViewID,UserID,LessonID,DateViewed")] LessonsViewed lessonsViewed)
        {
            if (ModelState.IsValid)
            {
                db.LessonsVieweds.Add(lessonsViewed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LessonID = new SelectList(db.Lessons1, "LessonID", "LessonTitle", lessonsViewed.LessonID);
            ViewBag.UserID = new SelectList(db.UserDetails1, "UserID", "FirstName", lessonsViewed.UserID);
            return View(lessonsViewed);
        }

        // GET: LessonsViewed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LessonsViewed lessonsViewed = db.LessonsVieweds.Find(id);
            if (lessonsViewed == null)
            {
                return HttpNotFound();
            }
            ViewBag.LessonID = new SelectList(db.Lessons1, "LessonID", "LessonTitle", lessonsViewed.LessonID);
            ViewBag.UserID = new SelectList(db.UserDetails1, "UserID", "FirstName", lessonsViewed.UserID);
            return View(lessonsViewed);
        }

        // POST: LessonsViewed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonViewID,UserID,LessonID,DateViewed")] LessonsViewed lessonsViewed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lessonsViewed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LessonID = new SelectList(db.Lessons1, "LessonID", "LessonTitle", lessonsViewed.LessonID);
            ViewBag.UserID = new SelectList(db.UserDetails1, "UserID", "FirstName", lessonsViewed.UserID);
            return View(lessonsViewed);
        }

        // GET: LessonsViewed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LessonsViewed lessonsViewed = db.LessonsVieweds.Find(id);
            if (lessonsViewed == null)
            {
                return HttpNotFound();
            }
            return View(lessonsViewed);
        }

        // POST: LessonsViewed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LessonsViewed lessonsViewed = db.LessonsVieweds.Find(id);
            db.LessonsVieweds.Remove(lessonsViewed);
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
