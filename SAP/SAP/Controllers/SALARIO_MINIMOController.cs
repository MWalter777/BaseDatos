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
    public class SALARIO_MINIMOController : Controller
    {
        private Model1 db = new Model1();

        // GET: SALARIO_MINIMOSs
        [MyAuthorize(Roles = "index_salario_minimo")]
        public ActionResult Index()
        {
            return View(db.SALARIO_MINIMO.ToList());
        }

        // GET: SALARIO_MINIMOs/Details/5
        [MyAuthorize(Roles = "index_salario_minimo")]
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

        

        // GET: SALARIO_MINIMOs/Edit/5
        [MyAuthorize(Roles = "editar_salario_minimo")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALARIO_MINIMO sALARIO_MINIMO = db.SALARIO_MINIMO.Find(id);
            if (sALARIO_MINIMO == null)
            {
                return HttpNotFound();
            }
            return View(sALARIO_MINIMO);
        }

        // POST: SALARIO_MINIMOs/Edit/5
        [MyAuthorize(Roles = "editar_salario_minimo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SALARIO_MINIMO,MONTO_SALARIO_MINIMO")] SALARIO_MINIMO sALARIO_MINIMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALARIO_MINIMO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALARIO_MINIMO);
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