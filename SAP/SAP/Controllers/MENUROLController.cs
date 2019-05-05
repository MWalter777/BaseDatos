using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SAP.Controllers
{
    public class MENUROLController : Controller
    {
        private Model1 db = new Model1();

        // GET: MENUROL
        public ActionResult Index()
        {
            ViewBag.roles = db.ROL.ToList();
            return View();
        }

        // GET: MENUs/Details/5
        public ActionResult Agregar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rol= db.ROL.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol = rol;
            IEnumerable<ACCEDE> accesos = db.ACCEDE.ToList().Where(accede => accede.ID_ROL == rol.ID_ROL); //Traemos todos los accesso a los que tiene

            List<String> id_accesos = new List<string>();
            foreach (ACCEDE a in accesos)
            {
                id_accesos.Add(""+a.ID_MENU); //menu al que tiene acceso
            }
            String cadena = string.Join(",", id_accesos.ToArray());
            String[] all_menu = cadena.Split(new char[] { ',' });
            if (all_menu != null)
            {
                ViewBag.menus = db.MENU.ToList().Where(menu => !all_menu.Contains(""+menu.ID_MENU));
            }
            ViewBag.acceso = accesos;            
            return View();
        }


    }
}