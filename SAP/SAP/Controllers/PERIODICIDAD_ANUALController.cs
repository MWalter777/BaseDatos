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
    public class PERIODICIDAD_ANUALController : Controller
    {
        private Model1 db = new Model1();

        // GET: PERIODICIDAD_ANUALs
        [MyAuthorize(Roles = "index_periodicidad_anual")]
        public ActionResult Index()
        {
            return View(db.PERIODICIDAD_ANUAL.ToList());
        }

        // GET: PERIODICIDAD_ANUALs/Details/5
        [MyAuthorize(Roles = "index_periodicidad_anual")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = db.PERIODICIDAD_ANUAL.Find(id);
            if (pERIODICIDAD_ANUAL == null)
            {
                return HttpNotFound();
            }
            return View(pERIODICIDAD_ANUAL);
        }

        // GET: PERIODICIDAD_ANUALs/Create
        [MyAuthorize(Roles = "crear_periodicidad_anual")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERIODICIDAD_ANUALs/Create
        [MyAuthorize(Roles = "crear_periodicidad_anual")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = new PERIODICIDAD_ANUAL();
            if (ModelState.IsValid)
            {
                String pse = collection["PERIODICIDAD_SELECT"];
                int anio = Int32.Parse(collection["ANIO_PERIODICIDAD"]);

                pERIODICIDAD_ANUAL.ANIO_PERIODICIDAD = anio;
                    
                if(pse == "0")
                    pERIODICIDAD_ANUAL.MENSUAL = true;
                else
                    pERIODICIDAD_ANUAL.QUINCENAL = true;

                db.PERIODICIDAD_ANUAL.Add(pERIODICIDAD_ANUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERIODICIDAD_ANUAL);
        }

        // GET: PERIODICIDAD_ANUALs/Edit/5
        [MyAuthorize(Roles = "editar_periodicidad_anual")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = db.PERIODICIDAD_ANUAL.Find(id);
            if (pERIODICIDAD_ANUAL == null)
            {
                return HttpNotFound();
            }
            return View(pERIODICIDAD_ANUAL);
        }

        // POST: PERIODICIDAD_ANUALs/Edit/5
        [MyAuthorize(Roles = "editar_periodicidad_anual")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = new PERIODICIDAD_ANUAL();
            if (ModelState.IsValid)
            {
                String pse = collection["PERIODICIDAD_SELECT"];
                int anio = Int32.Parse(collection["ANIO_PERIODICIDAD"]);
                int id = Int32.Parse(collection["ID_PERIODICIDAD"]);

                pERIODICIDAD_ANUAL.ID_PERIODICIDAD = id;

                pERIODICIDAD_ANUAL.ANIO_PERIODICIDAD = anio;

                if (pse == "0")
                    pERIODICIDAD_ANUAL.MENSUAL = true;
                else
                    pERIODICIDAD_ANUAL.QUINCENAL = true;

                db.Entry(pERIODICIDAD_ANUAL).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERIODICIDAD_ANUAL);


           
        }

        // GET: PERIODICIDAD_ANUALs/Delete/5
        [MyAuthorize(Roles = "eliminar_periodicidad_anual")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = db.PERIODICIDAD_ANUAL.Find(id);
            if (pERIODICIDAD_ANUAL == null)
            {
                return HttpNotFound();
            }
            return View(pERIODICIDAD_ANUAL);
        }

        // POST: PERIODICIDAD_ANUALs/Delete/5
        [MyAuthorize(Roles = "eliminar_periodicidad_anual")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERIODICIDAD_ANUAL pERIODICIDAD_ANUAL = db.PERIODICIDAD_ANUAL.Find(id);
            db.PERIODICIDAD_ANUAL.Remove(pERIODICIDAD_ANUAL);
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