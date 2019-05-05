using SAP.Models;
using SAP.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.Servicio
{
    public class Menu_Dinamico
    {
        private static Model1 db = new Model1();
        public static IEnumerable<MENU> get_menu_padres()
        {
            IEnumerable<MENU> menu = null;
            string id_rol = SessionPersister.rol;
            try
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
                    menu = db.MENU.ToList().Where(m => all_menu.Contains("" + m.ID_MENU));
                }
            }catch(Exception)
            {

            }
            return menu;
        }

    }
}