using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_Entities.ReferenceData;

namespace MVC_Iteration1.Controllers
{
    public class TeamCategoriesController : Controller
    {
        private ReferenceContext db = new ReferenceContext();

        // GET: TeamCategories
        public ActionResult Index()
        {
            return View(db.TeamCategoryRefList.ToList());
        }

        // GET: TeamCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamCategory teamCategory = db.TeamCategoryRefList.Find(id);
            if (teamCategory == null)
            {
                return HttpNotFound();
            }
            return View(teamCategory);
        }

        // GET: TeamCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamCategoryID,TeamCategoryName,TeamCategoryDescription,Added,Updated,Inactivated,IsActive")] TeamCategory teamCategory)
        {
            if (ModelState.IsValid)
            {
                db.TeamCategoryRefList.Add(teamCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamCategory);
        }

        // GET: TeamCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamCategory teamCategory = db.TeamCategoryRefList.Find(id);
            if (teamCategory == null)
            {
                return HttpNotFound();
            }
            return View(teamCategory);
        }

        // POST: TeamCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamCategoryID,TeamCategoryName,TeamCategoryDescription,Added,Updated,Inactivated,IsActive")] TeamCategory teamCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamCategory);
        }

        // GET: TeamCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamCategory teamCategory = db.TeamCategoryRefList.Find(id);
            if (teamCategory == null)
            {
                return HttpNotFound();
            }
            return View(teamCategory);
        }

        // POST: TeamCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamCategory teamCategory = db.TeamCategoryRefList.Find(id);
            db.TeamCategoryRefList.Remove(teamCategory);
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
