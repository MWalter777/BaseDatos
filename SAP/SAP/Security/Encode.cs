using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SAP.Security
{
    public class Encode
    {
        public static string EncodePassword(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        public static bool validar(String password)
        {
            String [] patron1 = {"!","/","·","$","%","&",")","(","=","?","¿","_",":",";","{","}","[","]"};
            bool resultado = false;
            String pass2 = password;
            String cadena = string.Join(",", pass2.ToArray());
            String [] permiso = cadena.Split(new char[] { ',' }); //Vemos los caracteres que tiene el password

            if (permiso.Any(r => patron1.Contains(r)))
            {
                resultado = true;
            }
            return resultado;
        }
    }
}