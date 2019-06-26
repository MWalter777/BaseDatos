using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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

        // Metodo Ajax para recuperar Posibles jefes
        public JsonResult getJefes(int idPuesto = 0)
        {
            var idPuestoParameter = new SqlParameter("@idPuesto", idPuesto);
            var listaJefes = db.Database.SqlQuery<EMPLEADO>("getJefes @idPuesto", idPuestoParameter);
            return Json(listaJefes, JsonRequestBehavior.AllowGet);
        }

        // GET: EMPLEADOes/Create
        [MyAuthorize(Roles = "crear_empleado")]
        public ActionResult Create()
        {
            ViewBag.DIRECCIONES = db.DIRECCION.ToList();
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL");
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO");
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO");
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION");
            ViewBag.PUESTOS = db.PUESTO.ToList();
            return View();
        }

        // POST: EMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLEADO,ID_DIRECCION,EMP_ID_EMPLEADO,ID_GENERO,ID_PROFESION,ID_ESTADO_CIVIL,ID_PUESTO,CODIGO_EMPLEADO,APELLIDO_MATERNO,APELLIDO_PATERNO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,FECHA_NACIMIENTO,DUI,PASAPORTE,NIT,ISSS,NUP,SALARIO_BASE,CORREO_PERSONAL,CORREO_INSTITUCIONAL,COMISION")] EMPLEADO eMPLEADO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EMPLEADO.Add(eMPLEADO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                ViewBag.error = "No se puede ingresar el usuario. Puede ser que los email, DUI, NUP, NIT ya existan en la BD. Puede que el salario base está fuera del rango permitido";
            }
            catch(Exception ex)
            {
                ViewBag.error =  "No se puede ingresar el usuario. Puede ser que los email, DUI, NUP, NIT ya existan en la BD. Puede que el salario base está fuera del rango permitido";
            }
            
            if (eMPLEADO.ID_DIRECCION == 0) ViewBag.ERROR_DIRECCION = "La dirección es obligatoria";
            if (eMPLEADO.ID_PUESTO == 0) ViewBag.ERROR_PUESTO = "El puesto a asignar es obligatorio";

            ViewBag.DIRECCIONES = db.DIRECCION.ToList();
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL", eMPLEADO.ID_ESTADO_CIVIL);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO", eMPLEADO.ID_GENERO);
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO", eMPLEADO.EMP_ID_EMPLEADO);
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION", eMPLEADO.ID_PROFESION);
            ViewBag.PUESTOS = db.PUESTO.ToList();
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
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
        //[MyAuthorize(Roles = "index_empleado")]
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.direccion).Include(e => e.estado_civil).Include(e => e.genero).Include(e => e.jefe).Include(e => e.profesion).Include(e => e.puesto);
            return View(eMPLEADO.ToList());
        }

        // GET: EMPLEADOes/Details/5
       // [MyAuthorize(Roles = "index_empleado")]
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
       // [MyAuthorize(Roles = "crear_empleado")]
        public ActionResult Create()
        {
            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO");
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL");
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO");
            ViewBag.PAISES = db.PAIS.ToList();
            ViewBag.PUESTOS = db.PUESTO.ToList();
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION");
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "NOMBRE_PUESTO");
            return View();
        }

        // Metodo Ajax para recuperar Regiones
        public JsonResult getRegiones(int idPais = 0)
        {
            var idPaisParameter = new SqlParameter("@idPais", idPais);
            var listaRegiones = db.Database.SqlQuery<REGION>("getRegiones @idPais", idPaisParameter);
            return Json(listaRegiones, JsonRequestBehavior.AllowGet);
        }

        // Metodo Ajax para recuperar SUB Regiones
        public JsonResult getSubRegiones(int idRegion = 0)
        {
            var idRegionParameter = new SqlParameter("@idRegion", idRegion);
            var listaSubRegiones = db.Database.SqlQuery<SUB_REGION>("getSubRegiones @idRegion", idRegionParameter);
            return Json(listaSubRegiones, JsonRequestBehavior.AllowGet);
        }

        // Metodo Ajax para recuperar Posibles jefes
        public JsonResult getJefes(int idPuesto = 0)
        {
            var idPuestoParameter = new SqlParameter("@idPuesto", idPuesto);
            var listaJefes = db.Database.SqlQuery<EMPLEADO>("getJefes @idPuesto", idPuestoParameter);
            return Json(listaJefes, JsonRequestBehavior.AllowGet);
        }

        // POST: EMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[MyAuthorize(Roles = "crear_empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLEADO,CODIGO_EMPLEADO,ID_DIRECCION,EMP_ID_EMPLEADO,ID_GENERO,ID_PROFESION,ID_ESTADO_CIVIL,ID_PUESTO,APELLIDO_MATERNO,APELLIDO_PATERNO,PRIMER_NOMBRE,SEGUNDO_NOMBRE,FECHA_NACIMIENTO,DUI,PASAPORTE,NIT,ISSS,NUP,SALARIO_BASE,CORREO_PERSONAL,CORREO_INSTITUCIONAL,COMISION")] EMPLEADO eMPLEADO, 
            int? pais, int? region, int? sub_region, string barrio, string colonia, string canton, string caserio, string calle, string avenida, 
            string pasaje, string residencial, string numero_casa)
        {
            if (ModelState.IsValid)
            {
                int guardar = 1;
                if (pais == null) { ViewBag.Pais = "Debe de especificar un Pais"; guardar = 0; }
                if (region == null) { ViewBag.Region = "Debe de especificar Una región"; guardar = 0; }
                if (sub_region == null) { ViewBag.SubRegion = "Debe de especificar una Sub reguion"; guardar = 0; }

                if(guardar == 1)
                {
                    //db.EMPLEADO.Add(eMPLEADO);
                    //db.SaveChanges();
                    var empleado = db.Database.SqlQuery<EMPLEADO>("guardarEmpleado @jefe, @genero, @profesion, @estadoCivil, @puesto, @codigoEmpleado, @apeMaterno, @apePaterno, @primerNombre, @segundoNombre, @fechaFacimiento, @dui, @pasaporte, @nit, @isss, @nup, @salarioBase, @correoPersonal, @correoInstitucional, @comision, @subRegion, @barrio, @colonia, @canton, @caserio, @calle, @avenida, @pasaje, @residencial, @numeroCasa",
                                                    new SqlParameter("@jefe", eMPLEADO.EMP_ID_EMPLEADO),
                                                    new SqlParameter("@genero", eMPLEADO.ID_GENERO),
                                                    new SqlParameter("@profesion", eMPLEADO.ID_PROFESION),
                                                    new SqlParameter("@estadoCivil", eMPLEADO.ID_ESTADO_CIVIL),
                                                    new SqlParameter("@puesto", eMPLEADO.ID_PUESTO),
                                                    new SqlParameter("@codigoEmpleado", eMPLEADO.CODIGO_EMPLEADO),
                                                    new SqlParameter("@apeMaterno", eMPLEADO.APELLIDO_MATERNO),
                                                    new SqlParameter("@apePaterno", eMPLEADO.APELLIDO_PATERNO),
                                                    new SqlParameter("@primerNombre", eMPLEADO.PRIMER_NOMBRE),
                                                    new SqlParameter("@segundoNombre", eMPLEADO.SEGUNDO_NOMBRE),
                                                    new SqlParameter("@fechaFacimiento", eMPLEADO.FECHA_NACIMIENTO),
                                                    new SqlParameter("@dui", eMPLEADO.DUI),
                                                    new SqlParameter("@pasaporte", eMPLEADO.PASAPORTE),
                                                    new SqlParameter("@nit", eMPLEADO.NIT),
                                                    new SqlParameter("@isss", eMPLEADO.ISSS),
                                                    new SqlParameter("@nup", eMPLEADO.NUP),
                                                    new SqlParameter("@salarioBase", eMPLEADO.SALARIO_BASE),
                                                    new SqlParameter("@correoPersonal", eMPLEADO.CORREO_PERSONAL),
                                                    new SqlParameter("@correoInstitucional", eMPLEADO.CORREO_INSTITUCIONAL),
                                                    new SqlParameter("@comision", eMPLEADO.COMISION),
                                                    new SqlParameter("@subRegion", sub_region),
                                                    new SqlParameter("@barrio", barrio),
                                                    new SqlParameter("@colonia", colonia),
                                                    new SqlParameter("@canton", canton),
                                                    new SqlParameter("@caserio", caserio),
                                                    new SqlParameter("@calle", calle),
                                                    new SqlParameter("@avenida", avenida),
                                                    new SqlParameter("@pasaje", pasaje),
                                                    new SqlParameter("@residencial", residencial),
                                                    new SqlParameter("@numeroCasa", numero_casa));
                    ViewBag.error = empleado;
                    return RedirectToAction("Index");
                }
                
            }
            if (pais == null) { ViewBag.Pais = "Debe de especificar un Pais"; }
            if (region == null) { ViewBag.Region = "Debe de especificar Una región"; }
            if (sub_region == null) { ViewBag.SubRegion = "Debe de especificar una Sub reguion"; }

            ViewBag.ID_DIRECCION = new SelectList(db.DIRECCION, "ID_DIRECCION", "BARRIO", eMPLEADO.ID_DIRECCION);
            ViewBag.ID_ESTADO_CIVIL = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL", eMPLEADO.ID_ESTADO_CIVIL);
            ViewBag.ID_GENERO = new SelectList(db.GENERO, "ID_GENERO", "NOMBRE_GENERO", eMPLEADO.ID_GENERO);
            ViewBag.EMP_ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLEADO", "CODIGO_EMPLEADO", eMPLEADO.EMP_ID_EMPLEADO);
            ViewBag.ID_PROFESION = new SelectList(db.PROFESION, "ID_PROFESION", "NOMBRE_PROFESION", eMPLEADO.ID_PROFESION);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUESTO", "CODIGO_PUESTO", eMPLEADO.ID_PUESTO);
            ViewBag.PAISES = db.PAIS.ToList();
            ViewBag.PUESTOS = db.PUESTO.ToList();
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Edit/5
       // [MyAuthorize(Roles = "editar_empleado")]
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
        //[MyAuthorize(Roles = "editar_empleado")]
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
        //[MyAuthorize(Roles = "eliminar_empleado")]
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
        //[MyAuthorize(Roles = "eliminar_empleado")]
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
*/
