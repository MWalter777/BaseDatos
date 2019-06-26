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
    public class INGRESO_EMPLEADOController : Controller
    {
        private Model1 db = new Model1();

        // GET: INGRESO_EMPLEADO
        [MyAuthorize(Roles = "index_ingreso_empleado")]
        public ActionResult Index()
        {
            Dictionary<int, String> par_ingreso = new Dictionary<int, String>();
            Dictionary<int, String> par_empleado = new Dictionary<int, String>();

            foreach(var record in db.CATALOGO_INGRESO)
            {
                par_ingreso[record.ID_INGRESO] = record.NOMBRE_INGRESO + " (" + record.INGRESO + ")";
            }

            foreach (var record in db.EMPLEADO.ToList())
            {
                par_empleado[record.ID_EMPLEADO] = record.CODIGO_EMPLEADO + " - " + record.APELLIDO_PATERNO + " " + record.APELLIDO_MATERNO + ", " +record.PRIMER_NOMBRE + " " + record.SEGUNDO_NOMBRE;
            }

            ViewBag.PAR_INGRESO = par_ingreso;
            ViewBag.PAR_EMPLEADO = par_empleado;
            return View(db.INGRESO_EMPLEADO.ToList());
        }

        // GET: INGRESO_EMPLEADO/Details/5
        [MyAuthorize(Roles = "index_ingreso_empleado")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESO_EMPLEADO iNGRESO_EMPLEADO = db.INGRESO_EMPLEADO.Find(id);

            ViewBag.HABILITAR_INGRESO = iNGRESO_EMPLEADO.HABILITAR_INGRESO;
            ViewBag.EMPLEADO_INFO = db.EMPLEADO.Find(iNGRESO_EMPLEADO.ID_EMPLEADO);
            ViewBag.CATALOGO_INGRESO_INFO = db.CATALOGO_INGRESO.Find(iNGRESO_EMPLEADO.ID_INGRESO);

            if (iNGRESO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESO_EMPLEADO);
        }

        // GET: INGRESO_EMPLEADO/Create
        [MyAuthorize(Roles = "crear_ingreso_empleado")]
        public ActionResult Create()
        {
            ViewBag.EMPLEADOS = db.EMPLEADO.ToList();
            ViewBag.CATALOGO_INGRESO = db.CATALOGO_INGRESO.ToList();
            return View();
        }

        // POST: INGRESO_EMPLEADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_ingreso_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INGRESO,ID_EMPLEADO,HABILITAR_INGRESO")] INGRESO_EMPLEADO iNGRESO_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.INGRESO_EMPLEADO.Add(iNGRESO_EMPLEADO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.EMPLEADOS = db.EMPLEADO.ToList();
                    ViewBag.CATALOGO_INGRESO = db.CATALOGO_INGRESO.ToList();
                    ViewBag.error = "Ya tienes una comision para este empleado, asignele el valor a ese empleado, no puede tener dos comisiones";
                    return View();
                }
            }

            return View(iNGRESO_EMPLEADO);
        }

        // GET: INGRESO_EMPLEADO/Edit/5
        [MyAuthorize(Roles = "editar_ingreso_empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESO_EMPLEADO iNGRESO_EMPLEADO = db.INGRESO_EMPLEADO.Find(id);
            if (iNGRESO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLEADOS = db.EMPLEADO.ToList();
            ViewBag.CATALOGO_INGRESO = db.CATALOGO_INGRESO.ToList();
            ViewBag.ID_SELECTED = id;
            return View(iNGRESO_EMPLEADO);
        }

        // POST: INGRESO_EMPLEADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_ingreso_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INGRESO_EMPLEADO,ID_INGRESO,ID_EMPLEADO,HABILITAR_INGRESO")] INGRESO_EMPLEADO iNGRESO_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGRESO_EMPLEADO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNGRESO_EMPLEADO);
        }

        // GET: INGRESO_EMPLEADO/Delete/5
        [MyAuthorize(Roles = "eliminar_ingreso_empleado")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESO_EMPLEADO iNGRESO_EMPLEADO = db.INGRESO_EMPLEADO.Find(id);
            ViewBag.HABILITAR_INGRESO = iNGRESO_EMPLEADO.HABILITAR_INGRESO;
            ViewBag.EMPLEADO_INFO = db.EMPLEADO.Find(iNGRESO_EMPLEADO.ID_EMPLEADO);
            ViewBag.CATALOGO_INGRESO_INFO = db.CATALOGO_INGRESO.Find(iNGRESO_EMPLEADO.ID_INGRESO);

            if (iNGRESO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESO_EMPLEADO);
        }

        // POST: INGRESO_EMPLEADO/Delete/5
        [MyAuthorize(Roles = "eliminar_ingreso_empleado")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INGRESO_EMPLEADO iNGRESO_EMPLEADO = db.INGRESO_EMPLEADO.Find(id);
            db.INGRESO_EMPLEADO.Remove(iNGRESO_EMPLEADO);
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