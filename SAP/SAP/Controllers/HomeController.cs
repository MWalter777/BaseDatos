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

namespace SAP.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
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

        public ActionResult NotAuthorized()
        {
            ViewBag.Message = "Pagina no autorizada";
            return View();
        }

        

    }
}