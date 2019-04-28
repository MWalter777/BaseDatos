using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace SAP.Security
{
    public class enviar_sms
    {
        public static string correo = "mh15012@ues.edu.sv";
        private static string usuario = "superusuariosap777@gmail.com";
        private static string password = "toor4321";

        public static int enviar_correo(string mensaje, string asunto, string destinatario)
        {
            int valor = 0;
            MailMessage correo = new MailMessage(usuario, destinatario, asunto, mensaje);
            SmtpClient servidor = new SmtpClient("smtp.live.com"); //solo para gmail, es el unico que conozco :v
            NetworkCredential credenciales = new NetworkCredential(usuario, password);
            servidor.Credentials = credenciales;
            servidor.EnableSsl = true;
            try
            {
                servidor.Send(correo);
                valor = 1;
            }catch(Exception e)
            {
                //talvez ponga algo aqui algun dia 
            }
            return valor;
        }
    }
}