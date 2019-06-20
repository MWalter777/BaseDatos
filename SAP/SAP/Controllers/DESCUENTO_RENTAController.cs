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
    public class DESCUENTO_RENTAController : Controller
    {
        private Model1 db = new Model1();

        // GET: DESCUENTO_RENTA
        [MyAuthorize(Roles = "index_renta")]
        public ActionResult Index()
        {
            return View(db.DESCUENTO_RENTA.ToList());
        }

        // GET: DESCUENTO_RENTA/Details/5
        [MyAuthorize(Roles = "index_renta")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTO_RENTA dESCUENTO_RENTA = db.DESCUENTO_RENTA.Find(id);
            if (dESCUENTO_RENTA == null)
            {
                return HttpNotFound();
            }
            return View(dESCUENTO_RENTA);
        }

        // GET: DESCUENTO_RENTA/Create
        [MyAuthorize(Roles = "crear_renta")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DESCUENTO_RENTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "crear_renta")]
        public ActionResult Create([Bind(Include = "ID_DESCUENTO_RENTA,MIN_RENTA,MAX_RENTA,PORCENTAJE_RENTA")] DESCUENTO_RENTA dESCUENTO_RENTA)
        {
            if (ModelState.IsValid)
            {
                db.DESCUENTO_RENTA.Add(dESCUENTO_RENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dESCUENTO_RENTA);
        }

        // GET: DESCUENTO_RENTA/Edit/5
        [MyAuthorize(Roles = "editar_renta")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTO_RENTA dESCUENTO_RENTA = db.DESCUENTO_RENTA.Find(id);
            if (dESCUENTO_RENTA == null)
            {
                return HttpNotFound();
            }
            return View(dESCUENTO_RENTA);
        }

        // POST: DESCUENTO_RENTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "editar_renta")]
        public ActionResult Edit([Bind(Include = "ID_DESCUENTO_RENTA,MIN_RENTA,MAX_RENTA,PORCENTAJE_RENTA")] DESCUENTO_RENTA dESCUENTO_RENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dESCUENTO_RENTA).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dESCUENTO_RENTA);
        }

        // GET: DESCUENTO_RENTA/Delete/5
        [MyAuthorize(Roles = "eliminar_renta")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTO_RENTA dESCUENTO_RENTA = db.DESCUENTO_RENTA.Find(id);
            if (dESCUENTO_RENTA == null)
            {
                return HttpNotFound();
            }
            return View(dESCUENTO_RENTA);
        }

        // POST: DESCUENTO_RENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "eliminar_renta")]
        public ActionResult DeleteConfirmed(int id)
        {
            DESCUENTO_RENTA dESCUENTO_RENTA = db.DESCUENTO_RENTA.Find(id);
            db.DESCUENTO_RENTA.Remove(dESCUENTO_RENTA);
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
