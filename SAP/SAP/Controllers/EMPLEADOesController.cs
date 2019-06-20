using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Models;
using SAP.Models;
using SAP.Security;

namespace SAP.Controllers
{
    public class EMPLEADOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: EMPLEADOes
        [MyAuthorize(Roles = "index_empleado")]
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.direccion).Include(e => e.estado_civil).Include(e => e.genero).Include(e => e.jefe).Include(e => e.profesion).Include(e => e.puesto);
            return View(eMPLEADO.ToList());
        }

        // GET: EMPLEADOes/Details/5
        [MyAuthorize(Roles = "index_empleado")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Create
        [MyAuthorize(Roles = "crear_empleado")]
        public ActionResult Create()
        {
            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO");
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL");
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO");
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO");
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION");
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "CODIGO_PUESTO");
            return View();
        }

        // POST: EMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLEADO,ID_DIRECCION,EMP_ID_EMPLEADO,ID_GENERO,ID_PROFESION,ID_ESTADO_CIVIL,ID_PUESTO,CODIGO_EMPLEADO,APELLIDO_MATERNO,APELLIDO_PATERNO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,FECHA_NACIMIENTO,DUI,PASAPORTE,NIT,ISSS,NUP,SALARIO_BASE,CORREO_PERSONAL,CORREO_INSTITUCIONAL,COMISION")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADO.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO", eMPLEADO.ID_DIRECCION);
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL", eMPLEADO.ID_ESTADO_CIVIL);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO", eMPLEADO.ID_GENERO);
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO", eMPLEADO.EMP_ID_EMPLEADO);
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION", eMPLEADO.ID_PROFESION);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "CODIGO_PUESTO", eMPLEADO.ID_PUESTO);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Edit/5
        [MyAuthorize(Roles = "editar_empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO", eMPLEADO.ID_DIRECCION);
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL", eMPLEADO.ID_ESTADO_CIVIL);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO", eMPLEADO.ID_GENERO);
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO", eMPLEADO.EMP_ID_EMPLEADO);
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION", eMPLEADO.ID_PROFESION);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "CODIGO_PUESTO", eMPLEADO.ID_PUESTO);
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPLEADO,ID_DIRECCION,EMP_ID_EMPLEADO,ID_GENERO,ID_PROFESION,ID_ESTADO_CIVIL,ID_PUESTO,CODIGO_EMPLEADO,APELLIDO_MATERNO,APELLIDO_PATERNO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,FECHA_NACIMIENTO,DUI,PASAPORTE,NIT,ISSS,NUP,SALARIO_BASE,CORREO_PERSONAL,CORREO_INSTITUCIONAL,COMISION")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO", eMPLEADO.ID_DIRECCION);
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL", eMPLEADO.ID_ESTADO_CIVIL);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO", eMPLEADO.ID_GENERO);
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO", eMPLEADO.EMP_ID_EMPLEADO);
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION", eMPLEADO.ID_PROFESION);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "CODIGO_PUESTO", eMPLEADO.ID_PUESTO);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Delete/5
        [MyAuthorize(Roles = "eliminar_empleado")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Delete/5
        [MyAuthorize(Roles = "eliminar_empleado")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            db.EMPLEADO.Remove(eMPLEADO);
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
