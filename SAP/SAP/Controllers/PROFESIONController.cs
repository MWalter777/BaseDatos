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
using System.Data.Entity.Infrastructure;

namespace SAP.Controllers
{
    public class PROFESIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: PROFESION
        [MyAuthorize(Roles = "index_profesion")]
        public ActionResult Index()
        {
            return View(db.PROFESION.ToList());
        }

        // GET: PROFESION/Details/5
        [MyAuthorize(Roles = "index_profesion")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION profesion = db.PROFESION.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View(profesion);
        }

        // GET: PROFESION/Create
        [MyAuthorize(Roles = "crear_profesion")]
        public ActionResult Create()
        {
            PopulatePROFESIONDropDownList();
            return View();
        }

        // POST: PROFESION/Create
        [MyAuthorize(Roles = "crear_profesion")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESION,NOMBRE_PROFESION")] PROFESION profesion)
        {
            if (ModelState.IsValid)
            {
                db.PROFESION.Add(profesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulatePROFESIONDropDownList(profesion.ID_PROFESION);
            return View(profesion);
        }

        // GET: PROFESION/Edit/5
        [MyAuthorize(Roles = "editar_profesion")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION profesion = db.PROFESION.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            PopulatePROFESIONDropDownList(profesion.ID_PROFESION);
            return View(profesion);
        }

        // POST: PROFESION/Edit/5
        [MyAuthorize(Roles = "editar_profesion")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var profesionToUpdate = db.PROFESION.Find(id);
            if (TryUpdateModel(profesionToUpdate, "",
               new string[] { "NOMBRE_PROFESION" }))
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
            PopulatePROFESIONDropDownList(profesionToUpdate.ID_PROFESION);
            return View(profesionToUpdate);
        }

        private void PopulatePROFESIONDropDownList(object selectedPROFESION = null)
        {
            var PROFESIONQuery = from d in db.PROFESION
                                 orderby d.NOMBRE_PROFESION
                                 select d;
            ViewBag.ID_PROFESION = new SelectList(PROFESIONQuery, "ID_PROFESION", "NOMBRE_PROFESION", selectedPROFESION);
        }

        // GET: PROFESION/Delete/5
        [MyAuthorize(Roles = "eliminar_profesion")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION profesion = db.PROFESION.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View(profesion);
        }

        // POST: PROFESION/Delete/5
        [MyAuthorize(Roles = "eliminar_profesion")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PROFESION profesion = db.PROFESION.Find(id);
                db.PROFESION.Remove(profesion);
                db.SaveChanges();
            }

            catch (Exception)
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