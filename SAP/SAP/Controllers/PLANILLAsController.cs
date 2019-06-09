using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAP.Models;

namespace SAP.Controllers
{
    public class PLANILLAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PLANILLAs
        public ActionResult Index()
        {
            return View(db.PLANILLA.ToList());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                PLANILLA planilla = new PLANILLA{ID_PLANILLA = 1, CODIGO_PLANILLA = codigo, FECHA = DateTime.Now, ACTIVO=true, TOTAL_DESCUENTOS =0, TOTAL_INGRESOS=0,TOTAL_PAGAR=0};
                db.PLANILLA.Add(planilla);
                db.SaveChanges();
                IEnumerable<DESCUENTO_EMPLEADO> descuento = db.DESCUENTO_EMPLEADO.ToList().Where(DESCUENTO_EMPLEADO => DESCUENTO_EMPLEADO.HABILITAR_DESCUENTO == true);
                int id = db.PLANILLA.ToList().Where(PLANILLA => PLANILLA.CODIGO_PLANILLA.Equals(codigo)).First().ID_PLANILLA;
                foreach (DESCUENTO_EMPLEADO d in descuento)
                {
                    DETALLEPLANILLA detalle = new DETALLEPLANILLA { ID_DETALLE_PLANILLA = 1, ID_PLANILLA = id, ID_DESCUENTO_EMPLEADO = d.ID_DESCUENTO_EMPLEADO, ID_INGRESO_EMPLEADO = null, SALARIO = 0 };
                    db.DETALLEPLANILLA.Add(detalle);
                    db.SaveChanges();
                }
                IEnumerable<INGRESO_EMPLEADO> ingreso = db.INGRESO_EMPLEADO.ToList().Where(INGRESO_EMPLEADO => INGRESO_EMPLEADO.HABILITAR_INGRESO == true);
                foreach (INGRESO_EMPLEADO d in ingreso)
                {
                    DETALLEPLANILLA detalle = new DETALLEPLANILLA { ID_DETALLE_PLANILLA = 1, ID_PLANILLA = db.PLANILLA.ToList().Where(PLANILLA => PLANILLA.CODIGO_PLANILLA.Equals(codigo)).First().ID_PLANILLA, ID_DESCUENTO_EMPLEADO = null, ID_INGRESO_EMPLEADO = d.ID_INGRESO_EMPLEADO, SALARIO = 0 };
                    db.DETALLEPLANILLA.Add(detalle);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: PLANILLAs/VerPlanilla/5
        public ActionResult VerPlanilla(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View();
        }


        // GET: PLANILLAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PLANILLAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLANILLA,FECHA,CODIGO_PLANILLA,TOTAL_INGRESOS,TOTAL_DESCUENTOS,TOTAL_PAGAR,ACTIVO")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.PLANILLA.Add(pLANILLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pLANILLA);
        }

        // GET: PLANILLAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLANILLA,FECHA,CODIGO_PLANILLA,TOTAL_INGRESOS,TOTAL_DESCUENTOS,TOTAL_PAGAR,ACTIVO")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLANILLA).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            db.PLANILLA.Remove(pLANILLA);
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
