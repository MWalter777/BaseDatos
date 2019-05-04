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
    public class ESTADO_CIVILController : Controller
    {
        private Model1 db = new Model1();

        // GET: ESTADO_CIVIL
        [MyAuthorize(Roles = "index_estado")]
        public ActionResult Index()
        {
            return View(db.ESTADO_CIVIL.ToList());
        }

        [MyAuthorize(Roles = "crear_estado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                ESTADO_CIVIL estado_civil = new ESTADO_CIVIL {NOMBRE_ESTADO_CIVIL = estado };
                db.ESTADO_CIVIL.Add(estado_civil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [MyAuthorize(Roles = "editar_estado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string estado1, string id_estado1)
        {
            if (!string.IsNullOrEmpty(estado1) && !string.IsNullOrEmpty(id_estado1))
            {
                ESTADO_CIVIL estado_civil = new ESTADO_CIVIL { ID_ESTADO_CIVIL = int.Parse(id_estado1), NOMBRE_ESTADO_CIVIL = estado1 };
                db.Entry(estado_civil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [MyAuthorize(Roles = "eliminar_estado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id_estado)
        {
            if (!string.IsNullOrEmpty(id_estado))
            {
                ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(int.Parse(id_estado));
                db.ESTADO_CIVIL.Remove(eSTADO_CIVIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }


        // GET: ESTADO_CIVIL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        public ActionResult Create()
        {
            return View();
        }


        // POST: ESTADO_CIVIL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                ESTADO_CIVIL estado_civil = new ESTADO_CIVIL { NOMBRE_ESTADO_CIVIL = estado };
                db.ESTADO_CIVIL.Add(estado_civil);
                db.SaveChanges();
                return View("Index");
            }

            return View("Index");
        }

        // GET: ESTADO_CIVIL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        // POST: ESTADO_CIVIL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTADO_CIVIL,NOMBRE_ESTADO_CIVIL")] ESTADO_CIVIL eSTADO_CIVIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO_CIVIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO_CIVIL);
        }
        /*
        // GET: ESTADO_CIVIL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        // POST: ESTADO_CIVIL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            db.ESTADO_CIVIL.Remove(eSTADO_CIVIL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
