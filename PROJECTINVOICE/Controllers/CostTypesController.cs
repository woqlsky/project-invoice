using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJECTINVOICE.Models;

namespace PROJECTINVOICE.Controllers
{
    public class CostTypesController : Controller
    {
        private miniprojektEntities db = new miniprojektEntities();

        // GET: CostTypes
        public ActionResult Index()
        {
            return View(db.CostType.ToList());
        }

        // GET: CostTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostType.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // GET: CostTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtype,typename")] CostType costType)
        {
            if (ModelState.IsValid)
            {
                db.CostType.Add(costType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costType);
        }

        // GET: CostTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostType.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // POST: CostTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtype,typename")] CostType costType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costType);
        }

        // GET: CostTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostType costType = db.CostType.Find(id);
            if (costType == null)
            {
                return HttpNotFound();
            }
            return View(costType);
        }

        // POST: CostTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CostType costType = db.CostType.Find(id);
            db.CostType.Remove(costType);
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
