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

        public ActionResult Index()
        {
            return View(db.PLANILLA.ToList().OrderByDescending(PLANILLA=>PLANILLA.ID_PLANILLA));
        }



        public ActionResult PlanillaPorEmpleado()
        {
            ViewBag.empleados = db.EMPLEADO.ToList();
            return View();
        }



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
            ViewBag.descuento = db.DESCUENTO_EMPLEADO.Where(DESCUENTO_EMPLEADO => DESCUENTO_EMPLEADO.ID_EMPLEADO == empleado.ID_EMPLEADO && DESCUENTO_EMPLEADO.HABILITAR_DESCUENTO && DESCUENTO_EMPLEADO.HABILITAR_DESCUENTO && DESCUENTO_EMPLEADO.descuento.ACTIVO);
            ViewBag.ingreso = db.INGRESO_EMPLEADO.Where(INGRESO_EMPLEADO => INGRESO_EMPLEADO.ID_EMPLEADO == empleado.ID_EMPLEADO && INGRESO_EMPLEADO.HABILITAR_INGRESO==true && INGRESO_EMPLEADO.ingreso.ACTIVO==true);

            decimal total = empleado.SALARIO_BASE;
            decimal comision = 0;
            decimal renta = empleado.SALARIO_BASE;
            DESCUENTO_RENTA renta_descuento = null;
            try
            {
                renta_descuento = db.DESCUENTO_RENTA.Where(DESCUENTO_RENTA => renta > (decimal)DESCUENTO_RENTA.MIN_RENTA && renta <= DESCUENTO_RENTA.MAX_RENTA).First();
            }
            catch (Exception)
            {

            }

            if (renta_descuento != null)
            {
                renta = renta * renta_descuento.PORCENTAJE_RENTA;
            }
            else{
                renta = 0;
            }
            ViewBag.renta = renta;
            total = total - renta;
            foreach (INGRESO_EMPLEADO i in empleado.ingreso_empleados)
            {
                if (!i.ingreso.DELEY_INGRESO)
                {
                    total = total + (decimal)i.ingreso.INGRESO;
                }
                else
                {
                    if (empleado.COMISION != null && empleado.COMISION == true)
                    {
                        RANGO_COMISION rango = db.RANGO_COMISION.Where(RANGO_COMISION => i.ingreso.INGRESO > RANGO_COMISION.MIN_COMISION && i.ingreso.INGRESO <= RANGO_COMISION.MAX_COMISION).First();
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

        public ActionResult Save(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                IEnumerable<PLANILLA> planillas = db.PLANILLA.Where(PLANILLA=> PLANILLA.ACTIVO);
                if (planillas.Count() <=0)
                {
                    PLANILLA planilla = new PLANILLA { ID_PLANILLA = 1, CODIGO_PLANILLA = codigo, FECHA = DateTime.Now, ACTIVO = true, TOTAL_DESCUENTOS = 0, TOTAL_INGRESOS = 0, TOTAL_PAGAR = 0 };
                    db.PLANILLA.Add(planilla);
                    try
                    {
                        db.SaveChanges();
                    }catch(Exception e)
                    {
                        ViewBag.error = "No puedes crear planillas con el mismo codigo de planilla";
                        return View("Index", db.PLANILLA.ToList());
                    }
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
                else
                {
                    ViewBag.error = "No puedes crear planillas, por que hay alguna activa, primero tienes que cerrar planillas :v";
                    return View("Index",db.PLANILLA.ToList().OrderByDescending(PLANILLA => PLANILLA.ID_PLANILLA));
                }
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
            PLANILLA planilla = db.PLANILLA.Where(PLANILLA => PLANILLA.ID_PLANILLA == id).First();
            if (planilla == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (planilla.ACTIVO)
            {
                IEnumerable<String> cabecera_ingreso = null;
                IEnumerable<String> cabecera_descuento = null;
                try
                {
                    cabecera_descuento = db.Database.SqlQuery<String>(@"select distinct(NOMBRE_DESCUENTO) from CATALOGO_DESCUENTO c join DESCUENTO_EMPLEADO d on d.ID_DESCUENTO = c.ID_DESCUENTO and c.ACTIVO=1 and d.HABILITAR_DESCUENTO=1");
                    cabecera_ingreso = db.Database.SqlQuery<String>(@"select distinct(NOMBRE_INGRESO) from CATALOGO_INGRESO c join INGRESO_EMPLEADO i on  i.ID_INGRESO = c.ID_INGRESO and c.ACTIVO=1 and i.HABILITAR_INGRESO=1");
                }
                catch (Exception e)
                {

                }
                if(cabecera_ingreso!=null && cabecera_descuento != null)
                {
                    IEnumerable<DETALLEPLANILLA> detalle = db.DETALLEPLANILLA.Where(DETALLEPLANILLA => DETALLEPLANILLA.ID_PLANILLA == planilla.ID_PLANILLA);
                    EMPRESA empresa = db.EMPRESA.Find(1); //Empresa numero 1, esto cambiara cuando kike haga la estructura organizativa
                    IEnumerable<EMPLEADO> empleados = db.EMPLEADO.Where(EMPLEADO => EMPLEADO.puesto.DEPARTAMENTO.EMPRESA.ID_EMPRESA == 1); //solo los empleados de la empresa 1 para cuando kike haga la estructura organizativa
                    IEnumerable<CATALOGO_INGRESO> catalogo_ingreso = db.Database.SqlQuery<CATALOGO_INGRESO>(@"select c.ID_INGRESO,c.NOMBRE_INGRESO, c.DELEY_INGRESO,c.INGRESO,c.ACTIVO,c.COMISION from CATALOGO_INGRESO c join INGRESO_EMPLEADO i on  i.ID_INGRESO = c.ID_INGRESO and c.ACTIVO=1 and i.HABILITAR_INGRESO=1");
                    IEnumerable<CATALOGO_INGRESO> descontar = db.Database.SqlQuery<CATALOGO_INGRESO>(@"select c.ID_INGRESO,c.NOMBRE_INGRESO, c.DELEY_INGRESO,c.INGRESO,c.ACTIVO,c.COMISION from CATALOGO_INGRESO c join INGRESO_EMPLEADO i on  i.ID_INGRESO = c.ID_INGRESO and c.ACTIVO = 1 and i.HABILITAR_INGRESO = 1 and c.DELEY_INGRESO = 1");
                    IEnumerable<DESCUENTO_RENTA> renta = db.DESCUENTO_RENTA.ToList().OrderBy(m=>m.MIN_RENTA);

                    ViewBag.detalle_planilla = detalle;
                    ViewBag.catalogo_ingreso = catalogo_ingreso;
                    ViewBag.cabecera_descuento = cabecera_descuento;
                    ViewBag.empleados = empleados;
                    int cantidad_ingreso = catalogo_ingreso.Count() - descontar.Count() + 1;
                    int candidad_descuento = cabecera_descuento.Count();
                    ViewBag.cantidad_ingreso = cantidad_ingreso;
                    ViewBag.candidad_descuento = candidad_descuento;
                    ViewBag.total_espacio = cantidad_ingreso + candidad_descuento + 4;
                    ViewBag.empresa = empresa;
                    ViewBag.fecha_actual = DateTime.Now;

                    ViewBag.renta = renta;
                }
                else
                {
                    ViewBag.error = "No se puede generar planilla, consulte con su administrador";
                    ViewBag.planilla = null;
                    return View();
                }

            }
            else
            {
                IEnumerable<String> historial_cabecera_ingreso = null;
                IEnumerable<String> historial_cabecera_descuento = null;
                try
                {
                    historial_cabecera_ingreso = db.Database.SqlQuery<String>(@"select DISTINCT(NOMBRE_INGRESO_HISTORIAL) from HISTORIAL h join ingreso i on i.ID_HISTORIAL = h.ID_HISTORIAL and ID_PLANILLA = " + planilla.ID_PLANILLA);
                    historial_cabecera_descuento = db.Database.SqlQuery<String>(@"select DISTINCT(NOMBRE_DESCUENTO_HISTORIAL) from HISTORIAL h join DESCUENTO d on d.ID_HISTORIAL = h.ID_HISTORIAL and ID_PLANILLA = " + planilla.ID_PLANILLA);
                }
                catch(Exception e)
                {
                    
                }
                if (historial_cabecera_ingreso != null && historial_cabecera_descuento!=null)
                {
                    IEnumerable<HISTORIAL> historial = db.HISTORIAL.Where(HISTORIAL => HISTORIAL.ID_PLANILLA == planilla.ID_PLANILLA);
                    ViewBag.historial_cabecera_descuento = historial_cabecera_descuento;
                    ViewBag.historial_cabecera_ingreso = historial_cabecera_ingreso;
                    ViewBag.historial = historial;
                    ViewBag.error = "La planilla ya no esta activa";
                    ViewBag.empresa = db.EMPRESA.Where(EMPRESA => EMPRESA.ID_EMPRESA == 1).First();
                    ViewBag.cantidad_ingreso = historial_cabecera_ingreso.Count();
                    ViewBag.cantidad_descuento = historial_cabecera_descuento.Count();
                    ViewBag.planilla = planilla;
                    ViewBag.total_espacio = historial_cabecera_descuento.Count() + 3;
                    ViewBag.fecha_actual = DateTime.Now;
                    return View("Planilla_desactivada");
                }
                else
                {
                    ViewBag.error = "La planilla ya no esta activa y no tiene datos";
                    ViewBag.planilla = null;
                    return View("Planilla_desactivada");
                }
            }
            ViewBag.planilla = planilla;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pagar(String id_planilla)
        {
            if (!string.IsNullOrEmpty(id_planilla)) {
                int id = int.Parse(id_planilla);
                PLANILLA planilla = db.PLANILLA.Find(id);
                if (planilla == null)
                {
                    ViewBag.error = "Error, no tiene Planilla especificada";
                }
                else
                {
                    if (planilla.ACTIVO)
                    {
                        try {
                            planilla.ACTIVO = false;
                            int id_empresa = 1;
                            int id_pla = planilla.ID_PLANILLA;
                            db.Database.ExecuteSqlCommand("exec guardar_planilla " + id_empresa + "," + id_pla);
                            IEnumerable<HISTORIAL> historia = db.HISTORIAL.Where(HISTORIAL => HISTORIAL.ID_PLANILLA == planilla.ID_PLANILLA);
                            decimal totalingreso = 0;
                            decimal totaldescuento = 0;
                            foreach (HISTORIAL h in historia)
                            {
                                totalingreso += (decimal)h.TOTAL;
                                foreach (INGRESO i in h.ingreso)
                                {
                                    if (i.INGRESO_HISTORIAL != null)
                                    {
                                        totalingreso += (decimal)i.INGRESO_HISTORIAL;
                                    }
                                }
                                foreach (DESCUENTO d in h.descuento)
                                {
                                    if (d.DESCUENTO_HISTORIAL != null)
                                    {
                                        totaldescuento += (decimal)d.DESCUENTO_HISTORIAL;
                                    }
                                }

                            }
                            planilla.TOTAL_DESCUENTOS = totaldescuento;
                            planilla.TOTAL_INGRESOS = totalingreso;
                            planilla.TOTAL_PAGAR = totalingreso - totaldescuento;
                            db.Entry(planilla).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("/");
                        }
                        catch(Exception e)
                        {
                            ViewBag.error = "Error, seguramente no has ejecutado el procedimiento almacenado, como no te va a dar error alv :v";
                            ViewBag.planilla = planilla;
                            return View("Planilla_desactivada");
                        }
                    }
                    else
                    {
                        ViewBag.error = "La planilla ya no esta activa";
                        ViewBag.planilla = planilla;
                        return View("Planilla_desactivada");
                    }
                }
                ViewBag.planilla = planilla;
                return View("VerPlanilla");
            }
            else
            {
                return RedirectToAction("/" );
            }
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
