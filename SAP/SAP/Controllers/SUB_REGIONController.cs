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
    public class SUB_REGIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: SUB_REGION
        [MyAuthorize(Roles = "index_sub_region")]
        public ActionResult Index()
        {
            var sub_regiones = db.SUB_REGION.Include(c => c.REGION);

            return View(sub_regiones.ToList());
        }

        // GET: SUB_REGION/Details/5
        [MyAuthorize(Roles = "index_sub_region")]
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
        [MyAuthorize(Roles = "crear_sub_region")]
        public ActionResult Create()
        {
            PopulateREGIONDropDownList();
            return View();
        }

        // POST: SUB_REGION/Create
        [MyAuthorize(Roles = "crear_sub_region")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUB_REGION,ID_REGION,NOMBRE_SUB_REGION,CODIGO_SUB_REGION")] SUB_REGION sub_region)
        {
            if (ModelState.IsValid)
            {
                db.SUB_REGION.Add(sub_region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateREGIONDropDownList(sub_region.ID_REGION);
            return View(sub_region);
        }

        // GET: SUB_REGION/Edit/5
        [MyAuthorize(Roles = "editar_sub_region")]
        public ActionResult Edit(int? id)
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
            PopulateREGIONDropDownList(sub_region.ID_REGION);
            return View(sub_region);
        }

        // POST: SUB_REGION/Edit/5
        [MyAuthorize(Roles = "editar_sub_region")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sub_regionToUpdate = db.SUB_REGION.Find(id);
            if (TryUpdateModel(sub_regionToUpdate, "",
               new string[] { "NOMBRE_SUB_REGION", "CODIGO_SUB_REGION", "ID_REGION" }))
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
            PopulateREGIONDropDownList(sub_regionToUpdate.ID_REGION);
            return View(sub_regionToUpdate);
        }
        private void PopulateREGIONDropDownList(object selectedREGION = null)
        {
            var REGIONQuery = from d in db.REGION
                            orderby d.NOMBRE_REGION
                            select d;
            ViewBag.ID_REGION = new SelectList(REGIONQuery, "ID_REGION", "NOMBRE_REGION", selectedREGION);
        }

        // GET: SUB_REGION/Delete/5
        [MyAuthorize(Roles = "eliminar_sub_region")]
        public ActionResult Delete(int? id)
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

        // POST: SUB_REGION/Delete/5
        [MyAuthorize(Roles = "eliminar_sub_region")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SUB_REGION sub_region = db.SUB_REGION.Find(id);
                IEnumerable<DIRECCION> borrar = db.DIRECCION.Where(p => p.ID_SUB_REGION == sub_region.ID_SUB_REGION).ToList();
                if (borrar.Count() == 0)
                {
                    db.SUB_REGION.Remove(sub_region);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.error = "No se pudo eliminar, la sub región contiene direcciones";
                    return View("Index", db.SUB_REGION.ToList());
                }
                
                
            }
            catch(Exception)
            {
                ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";

                return View("Index", db.SUB_REGION.ToList());
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
