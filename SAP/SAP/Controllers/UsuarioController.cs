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
    public class UsuarioController : Controller
    {
        private Model1 db = new Model1();

        // GET: Usuario
        [MyAuthorize(Roles = "lista_usuario")] //olvide cambiarle que ahi no es roles es permisos= "String" pero alv solo es el nombre de una variable XD
        public ActionResult Index()
        {
            return View(db.USUARIO.ToList());
        }


        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                USUARIO usuario = db.USUARIO.Where(u => u.EMAIL == email).Single();
                if (usuario != null)
                {
                    if(usuario.EMAIL.Equals(email) && usuario.PASSWORD.Equals(Encode.EncodePassword(password)))
                    {
                        SessionPersister.username = usuario.EMAIL;
                        SessionPersister.rol = usuario.ID_ROL.ToString();
                        SessionPersister.id_usuario = usuario.ID_USUARIO.ToString();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Error = "Usuario no existe";
                return View("login");
            }
            ViewBag.Error = "Error Datos no validos";
            return View("login");
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(int.Parse(id));
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.roles = db.ROL.ToList();
            ViewBag.empleados = db.EMPLEADO.ToList();
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String email, String password)
        {

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    USUARIO uSUARIO = new USUARIO { EMAIL = email, PASSWORD = Encode.EncodePassword(password) };
                    db.USUARIO.Add(uSUARIO);
                    db.SaveChanges();
                    ViewBag.Success = "Usuario solicitado con exito, espere el mensaje de confirmacion en su correo";
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Error al guardar, el correo ya existe";
                }
                return View("Create");
            }

            return View("Create");
        }

        // GET: Usuario/Edit/5
        [MyAuthorize(Roles = "editar_usuario")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(int.Parse(id));
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,ID_EMPLEADO,ID_ROL,EMAIL,PASSWORD,HABILITADO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSUARIO);
        }

        // GET: Usuario/Delete/5
        [MyAuthorize(Roles = "eliminar_usuario")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(int.Parse(id));
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuario/Delete/5
        [MyAuthorize(Roles = "eliminar_usuario")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(int.Parse(id));
            db.USUARIO.Remove(uSUARIO);
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
