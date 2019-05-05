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
            return RedirectToAction("Index");
        }

        [MyAuthorize(Roles = "editar_estado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string estado1, string id_estado1)
        {
            if (!string.IsNullOrEmpty(estado1) && !string.IsNullOrEmpty(id_estado1))
            {
                ESTADO_CIVIL estado_civil = new ESTADO_CIVIL { ID_ESTADO_CIVIL = int.Parse(id_estado1), NOMBRE_ESTADO_CIVIL = estado1 };
                db.Entry(estado_civil).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [MyAuthorize(Roles = "eliminar_estado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id_estado)
        {
            if (!string.IsNullOrEmpty(id_estado))
            {
                try
                {
                    ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(int.Parse(id_estado));
                    db.ESTADO_CIVIL.Remove(eSTADO_CIVIL);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";
                    return View("Index", db.ESTADO_CIVIL.ToList());
                }
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
