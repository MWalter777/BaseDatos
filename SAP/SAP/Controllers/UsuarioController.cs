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
            return View(db.USUARIO.ToList().Where(user => user.ID_USUARIO!=1));
        }


        public ActionResult perfil()
        {
            String id = SessionPersister.id_usuario;
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.usuario = db.USUARIO.Find(int.Parse(id));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult perfil(String username, String password, String email, String password2)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(username))
            {
                try
                {
                    USUARIO user = db.USUARIO.Find(int.Parse(SessionPersister.id_usuario));
                    if (user.PASSWORD.Equals(Encode.EncodePassword(password)))
                    {
                        if (!string.IsNullOrEmpty(password2) && password2.Length >= 8 && Encode.validar(password2))
                        {
                            user.PASSWORD = Encode.EncodePassword(password2);
                            user.USERNAME = username;
                            user.EMAIL = email;
                            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            user.USERNAME = username;
                            user.EMAIL = email;
                            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        ViewBag.error = "La contraseña antigua no concuerda con la nueva";
                    }
                }
                catch (Exception)
                {
                    ViewBag.error = "El username no es valido, cambielo!";
                }
            }
            String id = SessionPersister.id_usuario;
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.usuario = db.USUARIO.Find(int.Parse(id));
            }
            return View("perfil");

        }


        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) )
            {
                try
                {
                    USUARIO usuario = db.USUARIO.Where(u => u.USERNAME == username).Single();
                    if (usuario != null)
                    {
                        if (usuario.HABILITADO == true)
                        {
                            if (usuario.USERNAME.Equals(username) && usuario.PASSWORD.Equals(Encode.EncodePassword(password)))
                            {
                                SessionPersister.username = usuario.USERNAME;
                                SessionPersister.email = usuario.EMAIL;
                                SessionPersister.rol = usuario.ID_ROL.ToString();
                                SessionPersister.id_usuario = usuario.ID_USUARIO.ToString();
                                SessionPersister.inhabilitar = "0";
                                return RedirectToRoute(new
                                {
                                    Controller = "Home",
                                    Action = "Index"
                                });
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(SessionPersister.inhabilitar))
                                {
                                    SessionPersister.inhabilitar = "0";
                                }
                                SessionPersister.inhabilitar = ""+(int.Parse(SessionPersister.inhabilitar) + 1);
                                if (int.Parse(SessionPersister.inhabilitar) >= 3) 
                                {
                                    string mensaje = "El usuario: " + usuario.USERNAME + " intento iniciar erroneamente sesion muchas veces, se procedio a inhabilitarlo, debe verificar lo ocurrido";
                                    int val = enviar_sms.enviar_correo(mensaje, "Inicio de sesion erroneo", enviar_sms.correo);
                                    SessionPersister.inhabilitar = "0";
                                    usuario.HABILITADO = false;
                                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                    ViewBag.Error = "Usuario deshabilitado, muchos intentos de session, el administrador se comunicara con usted";
                                    return View("login");
                                }
                                ViewBag.Error = "Credenciales no coinciden";
                                return View("login");
                            }
                        }
                        else
                        {
                            ViewBag.Error = "El usuario aun no esta habilitado";
                            return View("login");
                        }
                    }
                }catch(Exception e)
                {
                    ViewBag.Error = "Usuario no existe";
                }
                return View("login");
            }
            ViewBag.Error = "Error Datos no validos";
            return View("login");
        }


        public ActionResult logout()
        {
            SessionPersister.username = null;
            SessionPersister.rol = null;
            SessionPersister.id_usuario = null;
            SessionPersister.email = null;
            SessionPersister.inhabilitar = "0";
            return RedirectToAction("login");
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
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String email, String password, String username)
        {

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username) && Encode.validar(password))
            {
                try
                {
                    USUARIO uSUARIO = new USUARIO { EMAIL = email, USERNAME = username, PASSWORD = Encode.EncodePassword(password), HABILITADO = false };
                    db.USUARIO.Add(uSUARIO);
                    db.SaveChanges();
                    string mensaje = "El usuario " + email + " solicita su ingreso al Sistema de Administracion de Planilla (SAP)\n\nIngrese a: http://localhost:52228/Usuario/Edit/" + uSUARIO.ID_USUARIO + "  \n\nSolicitamos cordialemente que NO acepte usuarios desconocidos ni le otorgue permisos que no deberian tener, feliz dia";
                    int val = enviar_sms.enviar_correo(mensaje, "Solicitud de nuevo usuario", enviar_sms.correo);
                    if (val == 1)
                    {
                        ViewBag.Success = "Usuario solicitado con exito, espere el mensaje de confirmacion en su correo";
                    }
                    else
                    {
                        ViewBag.Success = "El internet era demasiado lento, espere la confirmacion algun dia";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Error al guardar, el Usuario ya existe";
                    
                }
                return View("Create");
            }
            else
            {
                ViewBag.Error = "Error al guardar, la contraseña debe tener al menos 8 caracteres y caracteres especiales asi como numeros";
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
            ViewBag.ID_ROL = new SelectList(db.ROL.ToList().Where(rol => rol.ID_ROL!=1), "ID_ROL", "NOMBRE_ROL"); //Vamos a quitar el rol de superusuario y dejar olo del admin y demas
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO.ToList(), "ID_EMPLEADO", "PRIMER_NOMBRE");
            return View(uSUARIO);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "editar_usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,ID_EMPLEADO,ID_ROL,EMAIL,PASSWORD,HABILITADO,USERNAME")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                //uSUARIO.PASSWORD = Encode.EncodePassword(uSUARIO.PASSWORD);
                db.Entry(uSUARIO).State = System.Data.Entity.EntityState.Modified;
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
