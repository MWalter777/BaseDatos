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
    public class REGIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: REGION
        public ActionResult Index()
        {
            var regiones = db.REGION.Include(c => c.PAIS);

            return View(regiones.ToList());
        }

        // GET: REGION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION region = db.REGION.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: REGION/Create
        public ActionResult Create()
        {
            PopulatePAISDropDownList();
            return View();
        }

        // POST: REGION/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REGION,ID_PAIS,NOMBRE_REGION,CODIGO_REGION")] REGION region)
        {
            if (ModelState.IsValid)
            {
                db.REGION.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulatePAISDropDownList(region.ID_PAIS);
            return View(region);
        }

        // GET: REGION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION region = db.REGION.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            PopulatePAISDropDownList(region.ID_PAIS);
            return View(region);
        }

        // POST: REGION/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var regionToUpdate = db.REGION.Find(id);
            if (TryUpdateModel(regionToUpdate, "",
               new string[] { "NOMBRE_REGION", "CODIGO_REGION", "ID_PAIS" }))
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
            PopulatePAISDropDownList(regionToUpdate.ID_PAIS);
            return View(regionToUpdate);
        }
        private void PopulatePAISDropDownList(object selectedPAIS = null)
        {
            var PAISQuery = from d in db.PAIS
                                   orderby d.NOMBRE_PAIS
                                   select d;
            ViewBag.ID_PAIS = new SelectList(PAISQuery, "ID_PAIS", "NOMBRE_PAIS", selectedPAIS);
        }

        // GET: REGION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION region = db.REGION.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: REGION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                REGION region = db.REGION.Find(id);
                db.REGION.Remove(region);
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
