using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SAP.Models;
using SAP.Security;
using EntityState = System.Data.Entity.EntityState;

namespace SAP.Controllers
{
    public class ROLsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ROLs
        [MyAuthorize(Roles = "index_rol")]
        public ActionResult Index()
        {
            return View(db.ROL.ToList());
        }

        // GET: ROLs/Details/5
        [MyAuthorize(Roles = "index_rol")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            IEnumerable<PERMISO> permisos = db.PERMISO.ToList();
            IEnumerable<PERMITE> permisos_activos = db.PERMITE.Where(p => p.ID_ROL == id).ToList();
            List<int> id_permisos = new List<int>();

            foreach (var permiso in permisos_activos)
            {
                id_permisos.Add(permiso.ID_PERMISO);
            }

            ViewBag.permisos = permisos;
            ViewBag.permisos_activos = id_permisos;

            return View(rOL);
        }

        // GET: ROLs/Create
        [MyAuthorize(Roles = "crear_rol")]
        public ActionResult Create()
        {
            IEnumerable<PERMISO> permisos = db.PERMISO.ToList();
            ViewBag.permisos = permisos;

            return View();
        }

        // POST: ROLs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_rol")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL")] ROL rOL, int[] id_permiso)
        {
            if (ModelState.IsValid)
            {
                db.ROL.Add(rOL);
                db.SaveChanges();

                foreach (var id in id_permiso)
                {
                    db.PERMITE.Add(new PERMITE { ID_ROL = rOL.ID_ROL, ID_PERMISO = id });
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOL);
        }

        // GET: ROLs/Edit/5
        [MyAuthorize(Roles = "editar_rol")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }

            IEnumerable<PERMISO> permisos = db.PERMISO.ToList();
            IEnumerable<PERMITE> permisos_activos = db.PERMITE.Where(p => p.ID_ROL == id).ToList();
            List<int> id_permisos = new List<int>();

            foreach (var permiso in permisos_activos)
            {
                id_permisos.Add(permiso.ID_PERMISO);
            }

            ViewBag.permisos = permisos;
            ViewBag.permisos_activos = id_permisos;

            return View(rOL);
        }

        // POST: ROLs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_rol")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL")] ROL rOL, int[] id_permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL).State = EntityState.Modified;  
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(rOL);
        }

        // GET: ROLs/Delete/5
        [MyAuthorize(Roles = "eliminar_rol")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: ROLs/Delete/5
        [MyAuthorize(Roles = "eliminar_rol")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IEnumerable<PERMITE> borrar = db.PERMITE.Where(p => p.ID_ROL == id).ToList();
            db.PERMITE.RemoveRange(borrar);
            db.SaveChanges();

            ROL rOL = db.ROL.Find(id);
            db.ROL.Remove(rOL);
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
