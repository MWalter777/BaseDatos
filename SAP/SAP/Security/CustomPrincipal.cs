using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using SAP.Models;

namespace SAP.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Model1 db = new Model1();

        public IIdentity Identity
        {
            get;
            set;
        }

        private USUARIO account;
        private String[] permiso { get; set; }

        public CustomPrincipal(USUARIO account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.EMAIL);
        }


        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            ROL rol = db.ROL.Find(account.ID_ROL);
            if (rol != null)
            {
                List<String> permisos = new List<string>();
                foreach (PERMITE r in db.PERMITE.ToList().Where(per => per.ID_ROL == rol.ID_ROL))
                {
                    permisos.Add(db.PERMISO.Find(r.ID_PERMISO).NOMBRE_PERMISO);
                }
                String cadena = string.Join(",", permisos.ToArray());
                permiso = cadena.Split(new char[] { ',' });
                if (permiso != null)
                {
                    return roles.All(r => this.permiso.Contains(r));
                }
                return false;
            }
            return false;
        }
    }
}