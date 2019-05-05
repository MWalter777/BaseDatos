using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using SAP.Models;
using SAP.Security;
using SAP.Servicio;

namespace SAP.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Servicio()
        {
            try
            {
                string id_rol = SessionPersister.rol;
                if (!string.IsNullOrEmpty(id_rol))
                {
                    IEnumerable<ACCEDE> accesos = db.ACCEDE.ToList().Where(accede => accede.ID_ROL == int.Parse(id_rol)); //Traemos todos los accesso a los que tiene

                    List<String> id_accesos = new List<string>();
                    foreach (ACCEDE a in accesos)
                    {
                        id_accesos.Add("" + a.ID_MENU); //menu al que tiene acceso
                    }
                    String cadena = string.Join(",", id_accesos.ToArray());
                    String[] all_menu = cadena.Split(new char[] { ',' });
                    if (all_menu != null)
                    {
                        ViewBag.menus = db.MENU.ToList().Where(m => all_menu.Contains("" + m.ID_MENU));
                        return View();
                    }
                    else
                    {
                        return Redirect("/Home/Redireccion");
                    }
                }
                else
                {
                    return Redirect("/Home/Redireccion");
                }
            }
            catch (Exception)
            {
                return Redirect("/Home/Redireccion");
            }
        }

        public ActionResult Redireccion()
        {

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            GenericIdentity myIdentity = new GenericIdentity("usuario");
            String[] myStringArray = { "rol1", "rol2" };
            GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, myStringArray);
            Thread.CurrentPrincipal = myPrincipal;
            return View();

        }
        [MyAuthorize(Roles = "permiso_no_existe")]
        public ActionResult NotAuthorized()
        {
            ViewBag.Message = "Pagina no autorizada";
            return View();
        }

        

    }
}