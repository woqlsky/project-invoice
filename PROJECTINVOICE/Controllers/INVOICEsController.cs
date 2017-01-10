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
    public class INVOICEsController : Controller
    {
        private miniprojektEntities db = new miniprojektEntities();

        // GET: INVOICEs
        public ActionResult Index()
        {
            var iNVOICE = db.INVOICE.Include(i => i.Company1).Include(i => i.CostType).Include(i => i.Property1);
            return View(iNVOICE.ToList());
        }

        // GET: INVOICEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICE.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            return View(iNVOICE);
        }

        // GET: INVOICEs/Create
        public ActionResult Create()
        {
            ViewBag.company = new SelectList(db.Company, "idcompany", "cname");
            ViewBag.itype = new SelectList(db.CostType, "idtype", "typename");
            ViewBag.property = new SelectList(db.Property, "idproperty", "pname");
            return View();
        }

        // POST: INVOICEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idinvoice,invoice_number,itype,property,company,cost,istatus,idate")] INVOICE iNVOICE)
        {
            if (ModelState.IsValid)
            {
                db.INVOICE.Add(iNVOICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.company = new SelectList(db.Company, "idcompany", "cname", iNVOICE.company);
            ViewBag.itype = new SelectList(db.CostType, "idtype", "typename", iNVOICE.itype);
            ViewBag.property = new SelectList(db.Property, "idproperty", "pname", iNVOICE.property);
            return View(iNVOICE);
        }

        // GET: INVOICEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICE.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            ViewBag.company = new SelectList(db.Company, "idcompany", "cname", iNVOICE.company);
            ViewBag.itype = new SelectList(db.CostType, "idtype", "typename", iNVOICE.itype);
            ViewBag.property = new SelectList(db.Property, "idproperty", "pname", iNVOICE.property);
            return View(iNVOICE);
        }

        // POST: INVOICEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idinvoice,invoice_number,itype,property,company,cost,istatus,idate")] INVOICE iNVOICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVOICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.company = new SelectList(db.Company, "idcompany", "cname", iNVOICE.company);
            ViewBag.itype = new SelectList(db.CostType, "idtype", "typename", iNVOICE.itype);
            ViewBag.property = new SelectList(db.Property, "idproperty", "pname", iNVOICE.property);
            return View(iNVOICE);
        }

        // GET: INVOICEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICE.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            return View(iNVOICE);
        }

        // POST: INVOICEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVOICE iNVOICE = db.INVOICE.Find(id);
            db.INVOICE.Remove(iNVOICE);
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
