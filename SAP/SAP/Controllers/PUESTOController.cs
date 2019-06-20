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
    public class PUESTOController : Controller
    {
        private Model1 db = new Model1();

        // GET: PUESTO
        [MyAuthorize(Roles = "index_puesto")]
        public ActionResult Index()
        {
            var puestos = db.PUESTO.Include(c => c.DEPARTAMENTO);

            return View(puestos.ToList());
        }

        // GET: REGION/Details/5
        [MyAuthorize(Roles = "index_puesto")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO puesto = db.PUESTO.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // GET: REGION/Create
        [MyAuthorize(Roles = "crear_puesto")]
        public ActionResult Create()
        {
            PopulateDEPARTAMENTODropDownList();
            return View();
        }

        // POST: REGION/Create
        [MyAuthorize(Roles = "crear_puesto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PUESTO,ID_DEPARTAMENTO,CODIGO_PUESTO,NOMBRE_PUESTO,SALARIO_MINIMO,SALARIO_MAXIMO")] PUESTO puesto)
        {
            if (ModelState.IsValid)
            {

                if (puesto.SALARIO_MAXIMO < puesto.SALARIO_MINIMO)
                {
                    ViewBag.error = "El valor del salario máximo no puede ser menor al salario mínimo";
                    return View("Index", db.PUESTO.ToList());
                }
                if (puesto.SALARIO_MAXIMO < 0 || puesto.SALARIO_MINIMO < 0)
                {
                        ViewBag.error = "El valor del salario máximo o mínimo no pueden ser negativos";
                        return View("Index", db.PUESTO.ToList());
                }
                else
                {
                    db.PUESTO.Add(puesto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            PopulateDEPARTAMENTODropDownList(puesto.ID_DEPARTAMENTO);
            return View(puesto);
        }

        // GET: REGION/Edit/5
        [MyAuthorize(Roles = "editar_puesto")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO puesto = db.PUESTO.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            PopulateDEPARTAMENTODropDownList(puesto.ID_DEPARTAMENTO);
            return View(puesto);
        }

        // POST: REGION/Edit/5
        [MyAuthorize(Roles = "editar_puesto")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var puestoToUpdate = db.PUESTO.Find(id);
            if (TryUpdateModel(puestoToUpdate, "",
               new string[] { "NOMBRE_PUESTO", "CODIGO_PUESTO", "ID_DEPARTAMENTO", "SALARIO_MINIMO", "SALARIO_MAXIMO" }))
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
            PopulateDEPARTAMENTODropDownList(puestoToUpdate.ID_DEPARTAMENTO);
            return View(puestoToUpdate);
        }
        private void PopulateDEPARTAMENTODropDownList(object selectedDEPARTAMENTO = null)
        {
            var DEPARTAMENTOQuery = from d in db.DEPARTAMENTO
                            orderby d.NOMBRE_DEPARTAMENTO
                            select d;
            ViewBag.ID_DEPARTAMENTO = new SelectList(DEPARTAMENTOQuery, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", selectedDEPARTAMENTO);
        }

        // GET: REGION/Delete/5
        [MyAuthorize(Roles = "eliminar_puesto")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO puesto = db.PUESTO.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: REGION/Delete/5
        [MyAuthorize(Roles = "eliminar_puesto")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PUESTO puesto = db.PUESTO.Find(id);
                db.PUESTO.Remove(puesto);
                db.SaveChanges();
            }

            catch (Exception)
            {
                ViewBag.error = "No se puede eliminar, hacer referencia a otra clase";

                return View("Index", db.PUESTO.ToList());
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
