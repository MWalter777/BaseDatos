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
    public class DESCUENTO_EMPLEADOController : Controller
    {
        private Model1 db = new Model1();

        // GET: DESCUENTO_EMPLEADO/Asignar/5
        [MyAuthorize(Roles = "asignar_descuento")]
        public ActionResult Asignar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO empleado = db.EMPLEADO.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.empleado = empleado;
            ViewBag.descuento_empleado = db.DESCUENTO_EMPLEADO.Where(DESCUENTO_EMPLEADO=>DESCUENTO_EMPLEADO.empleado.ID_EMPLEADO==empleado.ID_EMPLEADO && DESCUENTO_EMPLEADO.HABILITAR_DESCUENTO);
            return View(db.Database.SqlQuery<CATALOGO_DESCUENTO>(@"select ca.ID_DESCUENTO, ca.NOMBRE_DESCUENTO,ca.DELEY_DESCUENTO,ca.PORCENTAJE,ca.DESCUENTO,ca.FECHA_INICIO,ca.FECHA_FIN,ca.ACTIVO from CATALOGO_DESCUENTO ca where ca.ID_DESCUENTO not in (select de.ID_DESCUENTO from DESCUENTO_EMPLEADO de where de.ID_EMPLEADO = " + empleado.ID_EMPLEADO + ") and ca.ACTIVO = 1 and ca.DELEY_DESCUENTO = 0; "));
        }

        [MyAuthorize(Roles = "asignar_descuento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string estado, string empleado)
        {
            if (!String.IsNullOrEmpty(estado) && !String.IsNullOrEmpty(empleado))
            {
                DESCUENTO_EMPLEADO descuento = new DESCUENTO_EMPLEADO { ID_DESCUENTO_EMPLEADO = 1, ID_DESCUENTO = int.Parse(estado), HABILITAR_DESCUENTO = true, ID_EMPLEADO = int.Parse(empleado) };
                db.DESCUENTO_EMPLEADO.Add(descuento);
                db.SaveChanges();
            }
            else
            {
                ViewBag.error = "No se pudo ingresar el nuevo descuento";
            }


            return RedirectToAction("/Asignar/" + empleado);
        }

        [MyAuthorize(Roles = "quitar_descuento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quitar(string estado1,string empleado)
        {
            if (!String.IsNullOrEmpty(estado1) && !String.IsNullOrEmpty(empleado))
            {
                DESCUENTO_EMPLEADO descuento = db.DESCUENTO_EMPLEADO.Find(int.Parse(estado1));
                db.DESCUENTO_EMPLEADO.Remove(descuento);
                db.SaveChanges();
            }
            else
            {
                ViewBag.error = "No se pudo ingresar el nuevo descuento";
            }


            return RedirectToAction("/Asignar/" + empleado);
        }
    }

}
