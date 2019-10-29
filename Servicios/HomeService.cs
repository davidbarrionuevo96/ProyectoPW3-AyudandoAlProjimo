using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<DenunciaMotivo> BuscarDenuncias()
        {
            var usua2 = (from p in asd.Denuncias
                                     join f in asd.Motivo on p.IdMotivo equals f.IdMotivo
                                     where p.Estado == 1
                                     orderby p.FechaCreacion
                                     select new {
                                            idDbenuncia = p.IdDenuncia,
                                            IdPropuesta=p.IdPropuesta,
                                            Comentarios=p.Comentarios,
                                            DescripcionMotivo = f.Descripcion,
                                            FechaCreacion = p.FechaCreacion,

                                     }).ToList();

            List<DenunciaMotivo> denumoti = new List<DenunciaMotivo>();
           
            foreach (var a in usua2)
            {
                DenunciaMotivo denu = new DenunciaMotivo();
                denu.Comentarios = a.Comentarios;
                denu.DescripcionMotivo = a.DescripcionMotivo;
                denu.IdDenuncia = a.idDbenuncia;
                denu.IdPropuesta = a.IdPropuesta;
                denu.FechaCreacion = a.FechaCreacion;
                denumoti.Add(denu);
            }
            return denumoti;
        }

        public void CargarImagen(HttpPostedFileBase file)
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

            var filename = Path.GetFileName(file.FileName);
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/"), filename);
            file.SaveAs(path);
            usu2.Foto = filename;
            asd.SaveChanges();
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

