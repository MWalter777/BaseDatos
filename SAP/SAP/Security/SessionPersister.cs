﻿using SAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.Security
{
    public class SessionPersister
    {
        private Model1 db = new Model1();
        public static string usernamesessionvar = "username";
        public static string rolessessionvar = "rol";
        public static string idsessionvar = "id";
        public static string emailsessionvar = "email";
        public static string menu_raizsessionvar = "menu_raiz";


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

        public static string email
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionvar = HttpContext.Current.Session[emailsessionvar];
                if (sessionvar != null)
                {
                    return sessionvar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[emailsessionvar] = value;
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

        public static IEnumerable<MENU> menu_raiz
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionvar = HttpContext.Current.Session[menu_raizsessionvar];
                if (sessionvar != null)
                {
                    return sessionvar as IEnumerable<MENU>;
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