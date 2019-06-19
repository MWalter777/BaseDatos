﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Models;
using SAP.Security;
using System.Data.Entity.Infrastructure;

namespace SAP.Controllers
{
    public class DIRECCIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: SUB_REGION
        //[MyAuthorize(Roles = "index_sub_region")]
        public ActionResult Index()
        {
            var direcciones = db.DIRECCION.Include(c => c.SUB_REGION);

            return View(direcciones.ToList());
        }

        // GET: SUB_REGION/Details/5
        //[MyAuthorize(Roles = "index_sub_region")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUB_REGION sub_region = db.SUB_REGION.Find(id);
            if (sub_region == null)
            {
                return HttpNotFound();
            }
            return View(sub_region);
        }

        // GET: SUB_REGION/Create
        //[MyAuthorize(Roles = "crear_sub_region")]
        public ActionResult Create()
        {
            PopulateSUB_REGIONDropDownList();
            return View();
        }

        // POST: SUB_REGION/Create
        //[MyAuthorize(Roles = "crear_sub_region")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DIRECCION, ID_SUB_REGION, BARRIO, COLONIA, CANTON, CASERIO, CALLE, AVENIDA, PASAJE, RESIDENCIAL, NUMERO_CASA")] DIRECCION direccion)
        {
            if (ModelState.IsValid)
            {
                db.DIRECCION.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateSUB_REGIONDropDownList(direccion.ID_SUB_REGION);
            return View(direccion);
        }

        // GET: SUB_REGION/Edit/5
        //[MyAuthorize(Roles = "editar_sub_region")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION direccion = db.DIRECCION.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            PopulateSUB_REGIONDropDownList(direccion.ID_SUB_REGION);
            return View(direccion);
        }

        // POST: SUB_REGION/Edit/5
        //[MyAuthorize(Roles = "editar_sub_region")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var direccionToUpdate = db.DIRECCION.Find(id);
            if (TryUpdateModel(direccionToUpdate, "",
               new string[] { "ID_SUB_REGION", "BARRIO", "COLONIA", "CANTON", "CASERIO", "CALLE", "AVENIDA", "PASAJE", "RESIDENCIAL", "NUMERO_CASA" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "No es posible guardar los cambios.");
                }
            }
            PopulateSUB_REGIONDropDownList(direccionToUpdate.ID_SUB_REGION);
            return View(direccionToUpdate);
        }
        private void PopulateSUB_REGIONDropDownList(object selectedSUB_REGION = null)
        {
            var SUB_REGIONQuery = from d in db.SUB_REGION
                              orderby d.NOMBRE_SUB_REGION
                              select d;
            ViewBag.ID_SUB_REGION = new SelectList(SUB_REGIONQuery, "ID_SUB_REGION", "NOMBRE_SUB_REGION", selectedSUB_REGION);
        }

        // GET: SUB_REGION/Delete/5
        //[MyAuthorize(Roles = "eliminar_sub_region")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION direccion = db.DIRECCION.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: SUB_REGION/Delete/5
        //[MyAuthorize(Roles = "eliminar_sub_region")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                DIRECCION direccion = db.DIRECCION.Find(id);
                db.DIRECCION.Remove(direccion);
                db.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";

                return View("Index", db.DIRECCION.ToList());
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
