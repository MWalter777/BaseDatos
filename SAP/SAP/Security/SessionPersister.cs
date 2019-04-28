using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.Security
{
    public class SessionPersister
    {
        public static string usernamesessionvar = "username";
        public static string rolessessionvar = "rol";
        public static string idsessionvar = "id";

        public static string username
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionvar = HttpContext.Current.Session[usernamesessionvar];
                if (sessionvar != null)
                {
                    return sessionvar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernamesessionvar] = value;
            }
        }

        public static string rol
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionvar = HttpContext.Current.Session[rolessessionvar];
                if (sessionvar != null)
                {
                    return sessionvar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[rolessessionvar] = value;
            }
        }

        public static string id_usuario
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionvar = HttpContext.Current.Session[idsessionvar];
                if (sessionvar != null)
                {
                    return sessionvar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[idsessionvar] = value;
            }
        }
    }
}