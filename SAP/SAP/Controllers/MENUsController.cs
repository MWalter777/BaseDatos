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
    public class MENUsController : Controller
    {
        private Model1 db = new Model1();

        // GET: MENUs
        public ActionResult Index()
        {
            var mENU = db.MENU.Include(m => m.MENU2);
            return View(mENU.ToList());
        }

        // GET: MENUs/Details/5
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
        public ActionResult Create()
        {
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU, "ID_MENU", "NOMBRE_MENU");
            return View();
        }

        // POST: MENUs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MENU,MEN_ID_MENU,NOMBRE_MENU")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.MENU.Add(mENU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MEN_ID_MENU = new SelectList(db.MENU, "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
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
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU, "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
            return View(mENU);
        }

        // POST: MENUs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MENU,MEN_ID_MENU,NOMBRE_MENU")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MEN_ID_MENU = new SelectList(db.MENU, "ID_MENU", "NOMBRE_MENU", mENU.MEN_ID_MENU);
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
            MENU mENU = db.MENU.Find(id);
            db.MENU.Remove(mENU);
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
