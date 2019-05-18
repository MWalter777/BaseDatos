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
    public class PERMISOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: PERMISOes
        [MyAuthorize(Roles = "index_permiso")]
        public ActionResult Index()
        {
            return View(db.PERMISO.ToList());
        }

        [MyAuthorize(Roles = "crear_permiso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string permiso_nombre, string permiso_descripcion)
        {
            if (!string.IsNullOrEmpty(permiso_nombre) || string.IsNullOrEmpty(permiso_descripcion))
            {
                PERMISO permiso = new PERMISO { NOMBRE_PERMISO = permiso_nombre, DESCRIPCION_PERMISO = permiso_descripcion};
                db.PERMISO.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [MyAuthorize(Roles = "editar_permiso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string id_estado1, string permiso_nombre1, string permiso_descripcion1)
        {
            if (!string.IsNullOrEmpty(permiso_descripcion1) && !string.IsNullOrEmpty(id_estado1) && !string.IsNullOrEmpty(permiso_nombre1))
            {
                PERMISO permiso = new PERMISO { ID_PERMISO = int.Parse(id_estado1), DESCRIPCION_PERMISO=permiso_descripcion1, NOMBRE_PERMISO=permiso_nombre1};
                db.Entry(permiso).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Datos no pueden ir vacios";
            }
            return RedirectToAction("Index");
        }

        [MyAuthorize(Roles = "eliminar_permiso")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id_estado)
        {
            if (!string.IsNullOrEmpty(id_estado))
            {
                try
                {
                    PERMISO permiso = db.PERMISO.Find(int.Parse(id_estado));
                    db.PERMISO.Remove(permiso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception){
                    ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";
                    return View("Index", db.PERMISO.ToList());
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
