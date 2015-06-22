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
    public class EffortsController : Controller
    {
        private ReferenceContext db = new ReferenceContext();

        // GET: Efforts
        public ActionResult Index()
        {
            return View(db.EffortRefList.ToList());
        }

        // GET: Efforts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effort effort = db.EffortRefList.Find(id);
            if (effort == null)
            {
                return HttpNotFound();
            }
            return View(effort);
        }

        // GET: Efforts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Efforts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EffortID,EffortName,EffortDescription,EffortCategoryID,EffortCategoryName,Added,Updated,Inactivated,IsActive")] Effort effort)
        {
            if (ModelState.IsValid)
            {
                db.EffortRefList.Add(effort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(effort);
        }

        // GET: Efforts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effort effort = db.EffortRefList.Find(id);
            if (effort == null)
            {
                return HttpNotFound();
            }
            return View(effort);
        }

        // POST: Efforts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EffortID,EffortName,EffortDescription,EffortCategoryID,EffortCategoryName,Added,Updated,Inactivated,IsActive")] Effort effort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(effort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(effort);
        }

        // GET: Efforts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effort effort = db.EffortRefList.Find(id);
            if (effort == null)
            {
                return HttpNotFound();
            }
            return View(effort);
        }

        // POST: Efforts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Effort effort = db.EffortRefList.Find(id);
            db.EffortRefList.Remove(effort);
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
