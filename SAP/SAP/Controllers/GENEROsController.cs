using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Models;
using SAP.Security;

namespace SAP.Controllers
{
    public class GENEROsController : Controller
    {
        private Model1 db = new Model1();

        // GET: GENEROs
        public ActionResult Index()
        {
            return View(db.GENERO.ToList());
        }

        // GET: GENEROs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERO gENERO = db.GENERO.Find(id);
            if (gENERO == null)
            {
                return HttpNotFound();
            }
            return View(gENERO);
        }

        // GET: GENEROs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GENEROs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GENERO,NOMBRE_GENERO")] GENERO gENERO)
        {
            if (ModelState.IsValid)
            {
                db.GENERO.Add(gENERO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gENERO);
        }

        // GET: GENEROs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERO gENERO = db.GENERO.Find(id);
            if (gENERO == null)
            {
                return HttpNotFound();
            }
            return View(gENERO);
        }

        // POST: GENEROs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GENERO,NOMBRE_GENERO")] GENERO gENERO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gENERO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gENERO);
        }

        // GET: GENEROs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GENERO gENERO = db.GENERO.Find(id);
            if (gENERO == null)
            {
                return HttpNotFound();
            }
            return View(gENERO);
        }

        // POST: GENEROs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENERO gENERO = db.GENERO.Find(id);
            db.GENERO.Remove(gENERO);
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
