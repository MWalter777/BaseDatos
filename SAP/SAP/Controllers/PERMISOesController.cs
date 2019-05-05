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
    public class PERMISOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: PERMISOes
        [MyAuthorize(Roles = "index_permiso")]
        public ActionResult Index()
        {
            return View(db.PERMISO.ToList());
        }

        // GET: PERMISOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISO.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // GET: PERMISOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERMISOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.PERMISO.Add(pERMISO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERMISO);
        }

        // GET: PERMISOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISO.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // POST: PERMISOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERMISO,NOMBRE_PERMISO,DESCRIPCION_PERMISO")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERMISO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERMISO);
        }

        // GET: PERMISOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISO.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // POST: PERMISOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERMISO pERMISO = db.PERMISO.Find(id);
            db.PERMISO.Remove(pERMISO);
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
