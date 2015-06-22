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
    public class EffortCategoriesController : Controller
    {
        private ReferenceContext db = new ReferenceContext();

        // GET: EffortCategories
        public ActionResult Index()
        {
            return View(db.EffortCategoryRefList.ToList());
        }

        // GET: EffortCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortCategory effortCategory = db.EffortCategoryRefList.Find(id);
            if (effortCategory == null)
            {
                return HttpNotFound();
            }
            return View(effortCategory);
        }

        // GET: EffortCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EffortCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EffortCategoryID,EffortCategoryName,EffortCategoryDescription,Added,Updated,Inactivated,IsActive")] EffortCategory effortCategory)
        {
            if (ModelState.IsValid)
            {
                db.EffortCategoryRefList.Add(effortCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(effortCategory);
        }

        // GET: EffortCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortCategory effortCategory = db.EffortCategoryRefList.Find(id);
            if (effortCategory == null)
            {
                return HttpNotFound();
            }
            return View(effortCategory);
        }

        // POST: EffortCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EffortCategoryID,EffortCategoryName,EffortCategoryDescription,Added,Updated,Inactivated,IsActive")] EffortCategory effortCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(effortCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(effortCategory);
        }

        // GET: EffortCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortCategory effortCategory = db.EffortCategoryRefList.Find(id);
            if (effortCategory == null)
            {
                return HttpNotFound();
            }
            return View(effortCategory);
        }

        // POST: EffortCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EffortCategory effortCategory = db.EffortCategoryRefList.Find(id);
            db.EffortCategoryRefList.Remove(effortCategory);
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
