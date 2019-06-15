/*using System;
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
    public class DEPARTAMENTOController : Controller
    {
        private Model1 db = new Model1();

        // GET: DEPARTAMENTOs
        public ActionResult Index()
        {
            var dEPARTAMENTO = db.DEPARTAMENTO.Include(d => d.DEPARTAMENTO2);
            return View(dEPARTAMENTO.ToList());
        }

        // GET: DEPARTAMENTOs/Details/5
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
        public ActionResult Create()
        {

            //ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => menu.MEN_ID_MENU == null), "ID_MENU", "NOMBRE_MENU"); //por si solo se muestran menus padres
            ViewBag.DEP_ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO.Where(menu => string.IsNullOrEmpty(menu.URL)),"ID_EMPRESA", "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO");
            return View();
        }

        // POST: DEPARTAMENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
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

            ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => string.IsNullOrEmpty(menu.URL)), "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
            return View(mENU);
        }

        // GET: MENUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENU.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => menu.MEN_ID_MENU == null), "ID_MENU", "NOMBRE_MENU"); //por si solo se muestran menus padres
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => string.IsNullOrEmpty(menu.URL)), "ID_MENU", "NOMBRE_MENU");
            ViewBag.ID_MENU = mENU.MEN_ID_MENU;
            return View(mENU);
        }

        // POST: MENUs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL")] MENU mENU, int men_id_menu1)
        {
            if (ModelState.IsValid)
            {
                if (mENU.MEN_ID_MENU == null)
                {
                    mENU.MEN_ID_MENU = men_id_menu1;
                }

                db.Entry(mENU).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU, "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
            ViewBag.ID_MENU = mENU.MEN_ID_MENU;
            return View(mENU);
        }

        // GET: MENUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENU.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: MENUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MENU mENU = db.MENU.Find(id);
                db.MENU.Remove(mENU);
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
}ME QUEDÉ EN LA LÍNEA 57
*/
