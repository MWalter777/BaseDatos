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
        public ActionResult Index()
        {
            ViewBag.menus = Menu_Dinamico.get_menu_padres();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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