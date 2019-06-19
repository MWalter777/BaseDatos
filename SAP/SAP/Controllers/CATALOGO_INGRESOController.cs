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
    public class CATALOGO_INGRESOController : Controller
    {
        private Model1 db = new Model1();

        // GET: CATALOGO_INGRESO
        [MyAuthorize(Roles = "index_catalogo_ingreso")]
        public ActionResult Index()
        {
            return View(db.CATALOGO_INGRESO.ToList());
        }

        // GET: CATALOGO_INGRESO/Details/5
        [MyAuthorize(Roles = "index_catalogo_ingreso")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_INGRESO cATALOGO_INGRESO = db.CATALOGO_INGRESO.Find(id);
            ViewBag.deLey = cATALOGO_INGRESO.DELEY_INGRESO;
            ViewBag.activo = cATALOGO_INGRESO.ACTIVO;

            if (cATALOGO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_INGRESO);
        }

        // GET: CATALOGO_INGRESO/Create
        [MyAuthorize(Roles = "crear_catalogo_ingreso")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATALOGO_INGRESO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_catalogo_ingreso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,PORCENTAJE,INGRESO,FECHA_INICIO,FECHA_FIN,ACTIVO")] CATALOGO_INGRESO cATALOGO_INGRESO)
        {
            if (ModelState.IsValid)
            {
                db.CATALOGO_INGRESO.Add(cATALOGO_INGRESO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATALOGO_INGRESO);
        }

        // GET: CATALOGO_INGRESO/Edit/5
        [MyAuthorize(Roles = "editar_catalogo_ingreso")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_INGRESO cATALOGO_INGRESO = db.CATALOGO_INGRESO.Find(id);
            if (cATALOGO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_INGRESO);
        }

        // POST: CATALOGO_INGRESO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_catalogo_ingreso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INGRESO,NOMBRE_INGRESO,DELEY_INGRESO,PORCENTAJE,INGRESO,FECHA_INICIO,FECHA_FIN,ACTIVO")] CATALOGO_INGRESO cATALOGO_INGRESO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATALOGO_INGRESO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATALOGO_INGRESO);
        }

        // GET: CATALOGO_INGRESO/Delete/5
        [MyAuthorize(Roles = "eliminar_catalogo_ingreso")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_INGRESO cATALOGO_INGRESO = db.CATALOGO_INGRESO.Find(id);
            ViewBag.deLey = cATALOGO_INGRESO.DELEY_INGRESO;
            ViewBag.activo = cATALOGO_INGRESO.ACTIVO;
            if (cATALOGO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_INGRESO);
        }

        // POST: CATALOGO_INGRESO/Delete/5
        [MyAuthorize(Roles = "eliminar_catalogo_ingreso")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATALOGO_INGRESO cATALOGO_INGRESO = db.CATALOGO_INGRESO.Find(id);
            db.CATALOGO_INGRESO.Remove(cATALOGO_INGRESO);
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