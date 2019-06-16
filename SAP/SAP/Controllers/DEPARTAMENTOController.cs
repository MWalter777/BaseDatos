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
    public class DEPARTAMENTOController : Controller
    {
        private Model1 db = new Model1();

        // GET: DEPARTAMENTOs
        [MyAuthorize(Roles = "index_departamento")]
        public ActionResult Index()
        {
            var dEPARTAMENTO = db.DEPARTAMENTO.Include(d => d.DEPARTAMENTO2);
            return View(dEPARTAMENTO.ToList());
        }

        // GET: DEPARTAMENTOs/Details/5
        [MyAuthorize(Roles = "index_departamento")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOs/Create
        [MyAuthorize(Roles = "crear_departamento")]
        public ActionResult Create()
        {
            PopulateDEPARTAMENTODropDownList();
            PopulateEMPRESADropDownList();
            return View();
        }

        // POST: DEPARTAMENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "crear_departamento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEPARTAMENTO,DEP_ID_DEPARTAMENTO,NOMBRE_DEPARTAMENTO,ID_EMPRESA")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTAMENTO.Add(dEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDEPARTAMENTODropDownList(dEPARTAMENTO.DEP_ID_DEPARTAMENTO);
            PopulateEMPRESADropDownList(dEPARTAMENTO.ID_EMPRESA);
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOs/Edit/5
        [MyAuthorize(Roles = "editar_departamento")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => menu.MEN_ID_MENU == null), "ID_MENU", "NOMBRE_MENU"); //por si solo se muestran menus padres
            ViewBag.DEP_ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO.Where(departamento => departamento.DEP_ID_DEPARTAMENTO == null), "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", "ID_EMPRESA");
            ViewBag.ID_DEPARTAMENTO = dEPARTAMENTO.DEP_ID_DEPARTAMENTO;
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_departamento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEPARTAMENTO,DEP_ID_DEPARTAMENTO,NOMBRE_DEPARTAMENTO,ID_EMPRESA")] DEPARTAMENTO dEPARTAMENTO, int dep_id_departamento1=0)
        {
            if (ModelState.IsValid)
            {
                if (dEPARTAMENTO.DEP_ID_DEPARTAMENTO == null)
                {
                    dEPARTAMENTO.DEP_ID_DEPARTAMENTO = dep_id_departamento1;
                }
                if(dep_id_departamento1==0)
                {
                    dEPARTAMENTO.DEP_ID_DEPARTAMENTO = null;
                }

                db.Entry(dEPARTAMENTO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEP_ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", "ID_EMPRESA", dEPARTAMENTO.DEP_ID_DEPARTAMENTO);
            ViewBag.ID_DEPARTAMENTO = dEPARTAMENTO.DEP_ID_DEPARTAMENTO;
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOs/Delete/5
        [MyAuthorize(Roles = "eliminar_departamento")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }
        private void PopulateDEPARTAMENTODropDownList(object selectedDEPARTAMENTO = null)
        {
            var DEPARTAMENTOQuery = from d in db.DEPARTAMENTO
                            where d.DEP_ID_DEPARTAMENTO==null
                            orderby d.NOMBRE_DEPARTAMENTO
                            select d;
            ViewBag.DEP_ID_DEPARTAMENTO = new SelectList(DEPARTAMENTOQuery, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", selectedDEPARTAMENTO);
        }
        private void PopulateEMPRESADropDownList(object selectedEMPRESA = null)
        {
            var EMPRESAQuery = from d in db.EMPRESA
                                    orderby d.NOMBRE_EMPRESA
                                    select d;
            ViewBag.ID_EMPRESA = new SelectList(EMPRESAQuery, "ID_EMPRESA", "NOMBRE_EMPRESA", selectedEMPRESA);
        }

        // POST: DEPARTAMENTOs/Delete/5
        [MyAuthorize(Roles = "eliminar_departamento")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
                db.DEPARTAMENTO.Remove(dEPARTAMENTO);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.error = "No se pudo eliminar pues hay un objeto dependiente de este menu";
                return View();
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
