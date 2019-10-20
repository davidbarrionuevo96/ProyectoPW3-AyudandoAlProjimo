using Entidades;
using System;
using System.Linq;
using System.Web;

namespace Servicios
{
    public class HomerService
    {
        Entities asd = new Entities();
        public Usuarios ActualizarPerfil(Usuarios u)
        {
            var usua = (from p in asd.Usuarios
                        where p.Email == u.Email
                        select p).ToList();

            Usuarios usu2 = new Usuarios();
            foreach (var a in usua)
            {
                usu2 = a;
            }

            usu2.Nombre = u.Nombre;
            usu2.Apellido = u.Apellido;
            usu2.FechaNacimiento = u.FechaNacimiento;
            asd.SaveChanges();
            return usu2;
        }

        public Usuarios BuscarUsuarioPorIdYPassword()
        {
            int id = Int32.Parse(HttpContext.Current.Session["usuario"].ToString());
            var usua = (from p in asd.Usuarios
                        where p.IdUsuario == id
                        select p).ToList();

            Usuarios usu2 = new Usuarios();
            foreach (var a in usua)
            {
                usu2 = a;
            }
            return usu2;
        }

        public Usuarios ActualizarPassword(String u)
        {
            int id = Int32.Parse(HttpContext.Current.Session["usuario"].ToString());
            var usua = (from p in asd.Usuarios
                        where p.IdUsuario == id
                        select p).ToList();

            Usuarios usu2 = new Usuarios();
            foreach (var a in usua)
            {
                usu2 = a;
            }

            usu2.Password =u;
            asd.SaveChanges();
            return usu2;
        }

    }
}

