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
    public class PLANILLAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PLANILLAs
        [MyAuthorize(Roles = "ver_planilla")]
        public ActionResult Index()
        {
            return View(db.PLANILLA.ToList());
        }


        [MyAuthorize(Roles = "ver_planilla")]
        public ActionResult PlanillaPorEmpleado()
        {
            ViewBag.empleados = db.EMPLEADO.ToList();
            return View();
        }


        [MyAuthorize(Roles = "ver_planilla")]
        public ActionResult Verboleta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO empleado = db.EMPLEADO.Find(id);
            if (empleado == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int anio = DateTime.Now.Year;
            PERIODICIDAD_ANUAL periodo = db.PERIODICIDAD_ANUAL.Where(PERIODICIDAD_ANUAL => PERIODICIDAD_ANUAL.ANIO_PERIODICIDAD == anio).First();
            if (periodo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.empleado = empleado;
            ViewBag.descuento = db.DESCUENTO_EMPLEADO.Where(DESCUENTO_EMPLEADO => DESCUENTO_EMPLEADO.ID_EMPLEADO == empleado.ID_EMPLEADO && DESCUENTO_EMPLEADO.HABILITAR_DESCUENTO);
            ViewBag.ingreso = db.INGRESO_EMPLEADO.Where(INGRESO_EMPLEADO => INGRESO_EMPLEADO.ID_EMPLEADO == empleado.ID_EMPLEADO);

            decimal total = empleado.SALARIO_BASE;
            decimal comision = 0;

            foreach (INGRESO_EMPLEADO i in ViewBag.ingreso)
            {
                if (!i.ingreso.DELEY_INGRESO)
                {
                    total = total + (decimal)i.ingreso.INGRESO;
                }
                else
                {
                    if (empleado.COMISION != null && empleado.COMISION == true)
                    {
                        RANGO_COMISION rango = db.RANGO_COMISION.Where(RANGO_COMISION => i.ingreso.INGRESO >= RANGO_COMISION.MIN_COMISION && i.ingreso.INGRESO <= RANGO_COMISION.MAX_COMISION).First();
                        if (rango != null)
                        {
                            comision = comision + (decimal)(i.ingreso.INGRESO * rango.PORCENTAJE_POR_COMISION);
                            total = total + comision;
                        }
                    }
                }
            }

            foreach (DESCUENTO_EMPLEADO i in ViewBag.descuento)
            {
                if (i.descuento.DELEY_DESCUENTO)
                {
                    total = total - (decimal)(i.descuento.PORCENTAJE * empleado.SALARIO_BASE);
                }
                else
                {
                    total = total - (decimal)i.descuento.DESCUENTO;
                }
            }
            DateTime fecha_actual = DateTime.Now;
            String tipo_pago = null;
            if (periodo.MENSUAL)
            {
                tipo_pago = "MENSUAL";
            }else
            {
                tipo_pago = "QUINCENAL";
            }


            ViewBag.comision = comision;
            ViewBag.tipo_pago = tipo_pago;
            ViewBag.total = total;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "crear_planilla")]
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
        [MyAuthorize(Roles = "ver_planilla")]
        public ActionResult VerPlanilla(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA planilla = db.PLANILLA.Where(PLANILLA => PLANILLA.ID_PLANILLA == id).First();
            if (planilla == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<DETALLEPLANILLA> detalle = db.DETALLEPLANILLA.Where(DETALLEPLANILLA => DETALLEPLANILLA.ID_PLANILLA == planilla.ID_PLANILLA);
            EMPRESA empresa = db.EMPRESA.Find(1); //Empresa numero 1, esto cambiara cuando kike haga la estructura organizativa
            IEnumerable<EMPLEADO> empleados = db.EMPLEADO.Where(EMPLEADO => EMPLEADO.puesto.DEPARTAMENTO.EMPRESA.ID_EMPRESA==1); //solo los empleados de la empresa 1 para cuando kike haga la estructura organizativa
            IEnumerable<CATALOGO_INGRESO> catalogo_ingreso = db.CATALOGO_INGRESO.Where(CATALOGO_INGRESO => CATALOGO_INGRESO.ACTIVO);
            IEnumerable<CATALOGO_INGRESO> descontar = db.CATALOGO_INGRESO.Where(CATALOGO_INGRESO => CATALOGO_INGRESO.ACTIVO && CATALOGO_INGRESO.DELEY_INGRESO);
            IEnumerable<CATALOGO_DESCUENTO> catalogo_descuento = db.CATALOGO_DESCUENTO.Where(CATALOGO_DESCUENTO => CATALOGO_DESCUENTO.ACTIVO);
            ViewBag.planilla = planilla;
            ViewBag.detalle_planilla = detalle;
            ViewBag.catalogo_ingreso = catalogo_ingreso;
            ViewBag.catalogo_descuento = catalogo_descuento;
            ViewBag.empleados = empleados;
            int cantidad_ingreso = catalogo_ingreso.Count() - descontar.Count() + 1;
            int candidad_descuento = catalogo_descuento.Count();
            ViewBag.cantidad_ingreso = cantidad_ingreso;
            ViewBag.candidad_descuento = candidad_descuento;
            ViewBag.total_espacio = cantidad_ingreso + candidad_descuento + 3;
            ViewBag.empresa = empresa;
            ViewBag.fecha_actual = DateTime.Now;
            return View();
        }


        // GET: PLANILLAs/Details/5
        [MyAuthorize(Roles = "ver_planilla")]
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
