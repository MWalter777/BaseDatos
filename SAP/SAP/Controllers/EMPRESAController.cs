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
    public class EMPRESAController : Controller
    {
        private Model1 db = new Model1();

        // GET: EMPRESA
        //[MyAuthorize(Roles = "index_empresa")]
        public ActionResult Index()
        {
            return View(db.EMPRESA.ToList());
        }

        // GET: EMPRESA/Details/5
        //[MyAuthorize(Roles = "index_empresa")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA empresa = db.EMPRESA.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: EMPRESA/Create
        //[MyAuthorize(Roles = "crear_empresa")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPRESA/Create
        //[MyAuthorize(Roles = "crear_empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPRESA,NOMBRE_EMPRESA,DIRECCION,REPRESENTANTE,NIT_EMPRESA,NIC,TELEFONO_EMPRESA,PAGINA_WEB,CORREO_EMPRESA,PAGE")] EMPRESA empresa)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: EMPRESA/Edit/5
        //[MyAuthorize(Roles = "editar_empresa")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA empresa = db.EMPRESA.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: EMPRESA/Edit/5
        //[MyAuthorize(Roles = "editar_empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPRESA,NOMBRE_EMPRESA,DIRECCION,REPRESENTANTE,NIT_EMPRESA,NIC,TELEFONO_EMPRESA,PAGINA_WEB,CORREO_EMPRESA,PAGE")] EMPRESA empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: EMPRESA/Delete/5
        //[MyAuthorize(Roles = "eliminar_empresa")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA empresa = db.EMPRESA.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: EMPRESA/Delete/5
        //[MyAuthorize(Roles = "eliminar_empresa")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EMPRESA empresa = db.EMPRESA.Find(id);
                db.EMPRESA.Remove(empresa);
                db.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.error = "No se puede eliminar, hace referencia a otra clase";

                return View("Index", db.EMPRESA.ToList());
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
