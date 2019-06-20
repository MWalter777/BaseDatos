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
    public class MENUsController : Controller
    {
        private Model1 db = new Model1();

        // GET: MENUs
        [MyAuthorize(Roles = "index_menu")]
        public ActionResult Index()
        {
            var mENU = db.MENU.Include(m => m.MENU2);
            return View(mENU.ToList());
        }

        // GET: MENUs/Details/5
        [MyAuthorize(Roles = "index_menu")]
        public ActionResult Details(int? id)
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

        // GET: MENUs/Create
        [MyAuthorize(Roles = "crear_menu")]
        public ActionResult Create()
        {

            //ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => menu.MEN_ID_MENU == null), "ID_MENU", "NOMBRE_MENU"); //por si solo se muestran menus padres
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => string.IsNullOrEmpty(menu.URL)), "ID_MENU", "NOMBRE_MENU");
            return View();
        }

        // POST: MENUs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "crear_menu")]
        public ActionResult Create([Bind(Include = "ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.MENU.Add(mENU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MEN_ID_MENU = new SelectList(db.MENU.Where(menu => string.IsNullOrEmpty(menu.URL)), "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
            return View(mENU);
        }

        // GET: MENUs/Edit/5
        [MyAuthorize(Roles = "editar_menu")]
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
        [MyAuthorize(Roles = "editar_menu")]
        public ActionResult Edit([Bind(Include = "ID_MENU,MEN_ID_MENU,NOMBRE_MENU,URL")] MENU mENU, int men_id_menu1)
        {
            if (ModelState.IsValid)
            {
                if (mENU.MEN_ID_MENU==null)
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
        [MyAuthorize(Roles = "eliminar_menu")]
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
        [MyAuthorize(Roles = "eliminar_menu")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MENU mENU = db.MENU.Find(id);
                db.MENU.Remove(mENU);
                db.SaveChanges();
            }catch(Exception e)
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
