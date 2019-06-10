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
    public class CATALOGO_DESCUENTOController : Controller
    {
        private Model1 db = new Model1();

        // GET: CATALOGO_DESCUENTO
        public ActionResult Index()
        {
            return View(db.CATALOGO_DESCUENTO.ToList());
        }

        // GET: CATALOGO_DESCUENTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DESCUENTO cATALOGO_DESCUENTO = db.CATALOGO_DESCUENTO.Find(id);
            ViewBag.deLey = cATALOGO_DESCUENTO.DELEY_DESCUENTO;
            ViewBag.activo = cATALOGO_DESCUENTO.ACTIVO;

            if (cATALOGO_DESCUENTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DESCUENTO);
        }

        // GET: CATALOGO_DESCUENTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATALOGO_DESCUENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DESCUENTO,NOMBRE_DESCUENTO,DELEY_DESCUENTO,PORCENTAJE,DESCUENTO,FECHA_INICIO,FECHA_FIN,ACTIVO")] CATALOGO_DESCUENTO cATALOGO_DESCUENTO)
        {
            if (ModelState.IsValid)
            {
                db.CATALOGO_DESCUENTO.Add(cATALOGO_DESCUENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATALOGO_DESCUENTO);
        }

        // GET: CATALOGO_DESCUENTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DESCUENTO cATALOGO_DESCUENTO = db.CATALOGO_DESCUENTO.Find(id);
            if (cATALOGO_DESCUENTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DESCUENTO);
        }

        // POST: CATALOGO_DESCUENTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DESCUENTO,NOMBRE_DESCUENTO,DELEY_DESCUENTO,PORCENTAJE,DESCUENTO,FECHA_INICIO,FECHA_FIN,ACTIVO")] CATALOGO_DESCUENTO cATALOGO_DESCUENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATALOGO_DESCUENTO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATALOGO_DESCUENTO);
        }

        // GET: CATALOGO_DESCUENTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DESCUENTO cATALOGO_DESCUENTO = db.CATALOGO_DESCUENTO.Find(id);
            ViewBag.deLey = cATALOGO_DESCUENTO.DELEY_DESCUENTO;
            ViewBag.activo = cATALOGO_DESCUENTO.ACTIVO;
            if (cATALOGO_DESCUENTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DESCUENTO);
        }

        // POST: CATALOGO_DESCUENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATALOGO_DESCUENTO cATALOGO_DESCUENTO = db.CATALOGO_DESCUENTO.Find(id);
            db.CATALOGO_DESCUENTO.Remove(cATALOGO_DESCUENTO);
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
