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
    public class PAISController : Controller
    {
        private Model1 db = new Model1();

        // GET: PAIS
        public ActionResult Index()
        {
            return View(db.PAIS.ToList());
        }

        // GET: PAIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: PAIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAIS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAIS,NOMBRE_PAIS,CODIGO_PAIS")] PAIS pais)
        {
            if (ModelState.IsValid)
            {
                db.PAIS.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: PAIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: PAIS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAIS,NOMBRE_PAIS,CODIGO_PAIS")] PAIS pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        // GET: PAIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pais = db.PAIS.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: PAIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PAIS pais = db.PAIS.Find(id);
                db.PAIS.Remove(pais);
                db.SaveChanges();
            }
            catch(Exception)
            {
                ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";

                return View("Index");
            }
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
