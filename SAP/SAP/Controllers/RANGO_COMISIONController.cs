using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Models;

namespace SAP.Controllers
{
    public class RANGO_COMISIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: RANGO_COMISION
        public ActionResult Index()
        {
            return View(db.RANGO_COMISION.ToList());
        }

        // GET: RANGO_COMISION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANGO_COMISION rANGO_COMISION = db.RANGO_COMISION.Find(id);
            if (rANGO_COMISION == null)
            {
                return HttpNotFound();
            }
            return View(rANGO_COMISION);
        }

        // GET: RANGO_COMISION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RANGO_COMISION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RANGO,MIN_COMISION,MAX_COMISION,PORCENTAJE_POR_COMISION")] RANGO_COMISION rANGO_COMISION)
        {
            if (ModelState.IsValid)
            {
                db.RANGO_COMISION.Add(rANGO_COMISION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rANGO_COMISION);
        }

        // GET: RANGO_COMISION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANGO_COMISION rANGO_COMISION = db.RANGO_COMISION.Find(id);
            if (rANGO_COMISION == null)
            {
                return HttpNotFound();
            }
            return View(rANGO_COMISION);
        }

        // POST: RANGO_COMISION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RANGO,MIN_COMISION,MAX_COMISION,PORCENTAJE_POR_COMISION")] RANGO_COMISION rANGO_COMISION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rANGO_COMISION).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rANGO_COMISION);
        }

        // GET: RANGO_COMISION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANGO_COMISION rANGO_COMISION = db.RANGO_COMISION.Find(id);
            if (rANGO_COMISION == null)
            {
                return HttpNotFound();
            }
            return View(rANGO_COMISION);
        }

        // POST: RANGO_COMISION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RANGO_COMISION rANGO_COMISION = db.RANGO_COMISION.Find(id);
            db.RANGO_COMISION.Remove(rANGO_COMISION);
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
