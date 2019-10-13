using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net.Mail;

namespace Servicios
{
    public class LoginService
    {

        public void RegistrarUsuario(Usuarios u)
        {
            Entities asd = new Entities();

            u.Activo = true;
            u.Token = "19E41C31E74A4526";
            u.FechaCracion = DateTime.Today;
            u.TipoUsuario = 1;

            asd.Usuarios.Add(u);
            asd.SaveChanges();
        }

        public void enviarCorreo(Usuarios u)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("ecommerce.mmda@gmail.com");
                correo.To.Add(u.Email);
                correo.Subject = "Activacion de Cuenta";
                correo.Body = "Active su cuenta mediante el siguiente link: WWW.asdasdasd.com";
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string scuentaCorreo = "ecommerce.mmda@gmail.com";
                string spasswordCorreo = "admin-123";

                smtp.Credentials = new System.Net.NetworkCredential(scuentaCorreo,spasswordCorreo);

                smtp.Send(correo);

            }
            catch(Exception ex)
            {
               string error = ex.Message;
            }

        }
    }
}
