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
    public class CENTRO_COSTOController : Controller
    {
        private Model1 db = new Model1();

        // GET: CENTRO_COSTO
        public ActionResult Index()
        {
            
            var centro_costos = db.CENTRO_COSTO.Include(c => c.DEPARTAMENTO);

            return View(centro_costos.ToList());
        }

        // GET: CENTRO_COSTO/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTRO_COSTO centro_costo = db.CENTRO_COSTO.Find(id);
            if (centro_costo == null)
            {
                return HttpNotFound();
            }
 
            /*int id_pla = 1;
            int id_cc=centro_costo.ID_CENTRO_COSTO;
            db.Database.ExecuteSqlCommand("exec descuento_cc " + id_pla + "," + id_cc);*/
            return View(centro_costo);
        }

        // GET: CENTRO_COSTO/Create
        public ActionResult Create()
        {
            PopulateDEPARTAMENTODropDownList();
            return View();
        }

        // POST: CENTRO_COSTO/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID_CENTRO_COSTO,ID_DEPARTAMENTO,ANIO,MONTO_ASIGNADO,SALDO")] CENTRO_COSTO centro_costo)
        {
            int anio = DateTime.Now.Year;
            if (ModelState.IsValid)
            {
                centro_costo.ANIO = anio;
                centro_costo.SALDO = 0;
                IEnumerable<CENTRO_COSTO> planillas = db.CENTRO_COSTO.Where(CENTRO_COSTO => CENTRO_COSTO.ID_DEPARTAMENTO==centro_costo.ID_DEPARTAMENTO);
                    if (planillas.Count() > 0)
                    {
                        ViewBag.error = "Ya existe un centro de costos de este año para este departamento";
                        return View("Index", db.CENTRO_COSTO.ToList());
                    }
                    else
                    {
                    db.CENTRO_COSTO.Add(centro_costo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    }

            }
            PopulateDEPARTAMENTODropDownList(centro_costo.ID_DEPARTAMENTO);
            return View(centro_costo);
        }

        // GET: CENTRO_COSTO/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CENTRO_COSTO/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CENTRO_COSTO/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CENTRO_COSTO/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private void PopulateDEPARTAMENTODropDownList(object selectedDEPARTAMENTO = null)
        {
            var DEPARTAMENTOQuery = from d in db.DEPARTAMENTO
                                    orderby d.NOMBRE_DEPARTAMENTO
                                    select d;
            ViewBag.ID_DEPARTAMENTO = new SelectList(DEPARTAMENTOQuery, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", selectedDEPARTAMENTO);
        }
    }
}
