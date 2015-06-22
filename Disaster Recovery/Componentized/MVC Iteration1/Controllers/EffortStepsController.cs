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
    public class EffortStepsController : Controller
    {
        private ReferenceContext db = new ReferenceContext();

        // GET: EffortSteps
        public ActionResult Index()
        {
            return View(db.EffortStepsRefList.ToList());
        }

        // GET: EffortSteps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortSteps effortSteps = db.EffortStepsRefList.Find(id);
            if (effortSteps == null)
            {
                return HttpNotFound();
            }
            return View(effortSteps);
        }

        // GET: EffortSteps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EffortSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EffortStepID,EffortStepName,EffortStepDescription,EffortStepSequence,EffortID,EffortName,Added,Updated,Inactivated,IsActive")] EffortSteps effortSteps)
        {
            if (ModelState.IsValid)
            {
                db.EffortStepsRefList.Add(effortSteps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(effortSteps);
        }

        // GET: EffortSteps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortSteps effortSteps = db.EffortStepsRefList.Find(id);
            if (effortSteps == null)
            {
                return HttpNotFound();
            }
            return View(effortSteps);
        }

        // POST: EffortSteps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EffortStepID,EffortStepName,EffortStepDescription,EffortStepSequence,EffortID,EffortName,Added,Updated,Inactivated,IsActive")] EffortSteps effortSteps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(effortSteps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(effortSteps);
        }

        // GET: EffortSteps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EffortSteps effortSteps = db.EffortStepsRefList.Find(id);
            if (effortSteps == null)
            {
                return HttpNotFound();
            }
            return View(effortSteps);
        }

        // POST: EffortSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EffortSteps effortSteps = db.EffortStepsRefList.Find(id);
            db.EffortStepsRefList.Remove(effortSteps);
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
