﻿using Entidades;
using Entidades.Auxiliares;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servicios
{
    public class PropuestaService
    {
        Entities asd = new Entities();
        public void RegistrarPropuesta(PropuestaAux p, HttpPostedFileBase Foto)
        {
            Propuestas pr = new Propuestas();
            pr.Descripcion = p.Descripcion;
            pr.Estado = 0;
            pr.FechaCreacion = DateTime.Today;
            pr.FechaFin = p.FechaFin;


            var filename = Path.GetFileName(Foto.FileName);
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/"), filename);
            Foto.SaveAs(path);
            pr.Foto = filename;

            pr.PropuestasReferencias.Add(
                new PropuestasReferencias()
                {
                    Nombre = p.NombreRef1,
                    Telefono = p.Telefono1
                }
                );
            pr.PropuestasReferencias.Add(
                new PropuestasReferencias()
                {
                    Nombre = p.NombreRef2,
                    Telefono = p.Telefono2
                }
                );
            pr.IdUsuarioCreador = p.IdUsuarioCreador;
            pr.Nombre = p.Nombre;
            pr.TelefonoContacto = p.TelefonoContacto;
            pr.TipoDonacion = p.TipoDonacion;

            if (p.TipoDonacion == (int)EnumTipoDonacion.Monetaria)
            {
                PropuestasDonacionesMonetarias d = new PropuestasDonacionesMonetarias();
                d.Dinero = p.Dinero;
                d.CBU = p.CBU;
                pr.PropuestasDonacionesMonetarias.Add(d);
            }
            if (p.TipoDonacion == (int)EnumTipoDonacion.Insumo)
            {
                foreach (var item in p.pins)
                {
                    pr.PropuestasDonacionesInsumos.Add(item);
                }

            }
            if (p.TipoDonacion == (int)EnumTipoDonacion.HorasTrabajo)
            {
                PropuestasDonacionesHorasTrabajo d = new PropuestasDonacionesHorasTrabajo();
                d.CantidadHoras = p.CantidadHoras;
                d.Profesion = p.Profesion;
                pr.PropuestasDonacionesHorasTrabajo.Add(d);
            }
            using (Entities ctx = new Entities())
            {
                ctx.Propuestas.Add(pr);
                ctx.SaveChanges();
            }
        }

        public List<PropuestaUsuario> BuscarPropuestas()
        {
            int id = Int32.Parse(HttpContext.Current.Session["usuario"].ToString());
            var usua2 = (from p in asd.Propuestas
                         join f in asd.Usuarios on p.IdUsuarioCreador equals f.IdUsuario
                         where f.IdUsuario == id
                         orderby p.FechaCreacion
                         select new
                         {
                             idPropuesta = p.IdPropuesta,
                             nombre = p.Nombre,
                             usuario = f.Nombre,
                             foto = p.Foto,
                             fechaFin = p.FechaFin,
                             porcentajePositivo = p.Valoracion,

                         }).ToList();

            List<PropuestaUsuario> propu = new List<PropuestaUsuario>();

            foreach (var a in usua2)
            {
                PropuestaUsuario p = new PropuestaUsuario();
                p.fechaFin = a.fechaFin;
                p.foto = a.foto;
                p.idPropuesta = a.idPropuesta;
                p.nombre = a.nombre;
                p.usuario = a.usuario;
                p.porcentajePositivo = Convert.ToDecimal(a.porcentajePositivo);
                p.generarPorcentajeNegativo();

                propu.Add(p);
            }
            return propu;
        }

        public List<PropuestaUsuario> BuscarPropuestasActivas()
        {
            int id = Int32.Parse(HttpContext.Current.Session["usuario"].ToString());
            var usua2 = (from p in asd.Propuestas
                         join f in asd.Usuarios on p.IdUsuarioCreador equals f.IdUsuario
                         where f.IdUsuario == id && p.FechaFin >= DateTime.Today
                         orderby p.FechaCreacion
                         select new
                         {
                             idPropuesta = p.IdPropuesta,
                             nombre = p.Nombre,
                             usuario = f.Nombre,
                             foto = p.Foto,
                             fechaFin = p.FechaFin,
                             porcentajePositivo = p.Valoracion,

                         }).ToList();

            List<PropuestaUsuario> propu = new List<PropuestaUsuario>();

            foreach (var a in usua2)
            {
                PropuestaUsuario p = new PropuestaUsuario();
                p.fechaFin = a.fechaFin;
                p.foto = a.foto;
                p.idPropuesta = a.idPropuesta;
                p.nombre = a.nombre;
                p.usuario = a.usuario;
                p.porcentajePositivo = Convert.ToDecimal(a.porcentajePositivo);
                p.generarPorcentajeNegativo();

                propu.Add(p);
            }
            return propu;
        }
        public List<PropuestaUsuario> BuscarPropuestasInactivas()
        {
            int id = Int32.Parse(HttpContext.Current.Session["usuario"].ToString());
            var usua2 = (from p in asd.Propuestas
                         join f in asd.Usuarios on p.IdUsuarioCreador equals f.IdUsuario
                         where f.IdUsuario == id && p.FechaFin <= DateTime.Today
                         orderby p.FechaCreacion
                         select new
                         {
                             idPropuesta = p.IdPropuesta,
                             nombre = p.Nombre,
                             usuario = f.Nombre,
                             foto = p.Foto,
                             fechaFin = p.FechaFin,
                             porcentajePositivo = p.Valoracion,

                         }).ToList();

            List<PropuestaUsuario> propu = new List<PropuestaUsuario>();

            foreach (var a in usua2)
            {
                PropuestaUsuario p = new PropuestaUsuario();
                p.fechaFin = a.fechaFin;
                p.foto = a.foto;
                p.idPropuesta = a.idPropuesta;
                p.nombre = a.nombre;
                p.usuario = a.usuario;
                p.porcentajePositivo = Convert.ToDecimal(a.porcentajePositivo);
                p.generarPorcentajeNegativo();

                propu.Add(p);
            }
            return propu;
        }

        public int TamListaInsPorId(int idPropuesta)
        {
            using (Entities ctx = new Entities())
            {
                int cant = (from p in ctx.Propuestas
                            join pi in ctx.PropuestasDonacionesInsumos
                            on p.IdPropuesta equals pi.IdPropuesta
                            where pi.IdPropuesta == idPropuesta
                            select pi
                         ).Count();
                return cant;
            }
        }

        public List<PropuestasDonacionesInsumos> CrearListaPropuestasInsumos(int cant)
        {
            List<PropuestasDonacionesInsumos> list = new List<PropuestasDonacionesInsumos>();
            for (int i = 0; i < cant; i++)
            {
                list.Add(
                    new PropuestasDonacionesInsumos()
                    {
                    }
                    );
            }
            return list;
        }

        public int TotalPropuestaIns(int id)
        {
            int contTotal = 0;
            Entities ctx = new Entities();
            var plist = (from p in ctx.PropuestasDonacionesInsumos
                         where p.IdPropuesta == id
                         select p.Cantidad
                             ).ToList();
            if (plist.Count > 0)
            {
                foreach (int item in plist)
                {
                    contTotal += item;
                }
                return contTotal;
            }
            else return 0;
        }
        public int TotalPropuestaHrs(int id)
        {
            Entities ctx = new Entities();
            var v = (from p in ctx.PropuestasDonacionesHorasTrabajo
                     where p.IdPropuesta == id
                     select p.CantidadHoras
                             ).First();

            return v;
        }
        public decimal TotalPropuestaMon(int id)
        {
            Entities ctx = new Entities();
            var v = (from p in ctx.PropuestasDonacionesMonetarias
                     where p.IdPropuesta == id
                     select p.Dinero
                             ).First();

            return v;
        }
        public int CalcularTotalDonadoPropuestaIns(int id)
        {
            Entities ctx = new Entities();
            int contTotal = 0;
            var dlist = (from p in ctx.Propuestas
                         join p_in in ctx.PropuestasDonacionesInsumos
                          on p.IdPropuesta equals p_in.IdPropuesta
                         join d_in in ctx.DonacionesInsumos
                          on p_in.IdPropuestaDonacionInsumo equals d_in.IdPropuestaDonacionInsumo
                         where p.IdPropuesta == id
                         select d_in.Cantidad
                             ).ToList();

            if (dlist.Count > 0)
            {
                foreach (int item in dlist)
                {
                    contTotal += item;
                }
                return contTotal;
            }
            else return 0;
        }
        public int CalcularTotalDonadoPropuestaHrs(int id)
        {
            Entities ctx = new Entities();

            int contTotal = 0;
            var dlist = (from p in ctx.Propuestas
                         join p_in in ctx.PropuestasDonacionesHorasTrabajo
                          on p.IdPropuesta equals p_in.IdPropuesta
                         join d_in in ctx.DonacionesHorasTrabajo
                          on p_in.IdPropuestaDonacionHorasTrabajo equals d_in.IdPropuestaDonacionHorasTrabajo
                         where p.IdPropuesta == id
                         select d_in.Cantidad
                             ).ToList();

            if (dlist.Count > 0)
            {
                foreach (int item in dlist)
                {
                    contTotal += item;
                }
                return contTotal;
            }
            else return 0;
        }
        public decimal CalcularTotalDonadoPropuestaMon(int id)
        {
            Entities ctx = new Entities();

            decimal contTotal = 0;
            var dlist = (from p in ctx.Propuestas
                         join p_in in ctx.PropuestasDonacionesMonetarias
                          on p.IdPropuesta equals p_in.IdPropuesta
                         join d_in in ctx.DonacionesMonetarias
                          on p_in.IdPropuestaDonacionMonetaria equals d_in.IdPropuestaDonacionMonetaria
                         where p.IdPropuesta == id
                         select d_in.Dinero
                          ).ToList();
            if (dlist.Count > 0)
            {
                foreach (decimal item in dlist)
                {
                    contTotal += item;
                }
                return contTotal;
            }
            else return 0;
        }
        public int IdPropuestaMonetaria(int id)
        {
            using (var ctx = new Entities())
            {
                int ide = (from p in ctx.Propuestas
                           join p_m in ctx.PropuestasDonacionesMonetarias
                           on p.IdPropuesta equals p_m.IdPropuesta
                           select p_m.IdPropuestaDonacionMonetaria).First();
                return ide;
            }


        }
        public int IdPropuestaInsumos(int id)
        {
            using (var ctx = new Entities())
            {
                int ide = (from p in ctx.Propuestas
                           join p_m in ctx.PropuestasDonacionesInsumos
                           on p.IdPropuesta equals p_m.IdPropuesta
                           select p_m.IdPropuestaDonacionInsumo).First();
                return ide;
            }


        }
        public int IdPropuestaHoras(int id)
        {
            using (var ctx = new Entities())
            {
                int ide = (from p in ctx.Propuestas
                           join p_m in ctx.PropuestasDonacionesHorasTrabajo
                           on p.IdPropuesta equals p_m.IdPropuesta
                           select p_m.IdPropuestaDonacionHorasTrabajo).First();
                return ide;
            }


        }
        public string RetornarProfesionPorIdPropuesta(int id)
        {
            using (var ctx = new Entities())
            {
                string pro = (from p in ctx.Propuestas
                              join p_m in ctx.PropuestasDonacionesHorasTrabajo
                              on p.IdPropuesta equals p_m.IdPropuesta
                              where p.IdPropuesta == id
                              select p_m.Profesion).First();
                return pro;
            }
        }
        public void ModificarPropuesta(Propuestas p, HttpPostedFileBase Foto)
        {

            using (var ctx = new Entities())
            {
                //1->Monetaria   2->Insumos   3->HorasDeTrabajo

                Propuestas pr = (from prop in ctx.Propuestas
                                 where prop.IdPropuesta == p.IdPropuesta
                                 select prop).First();
                pr.Descripcion = p.Descripcion;
                pr.FechaFin = p.FechaFin;
                pr.Nombre = p.Nombre;
                pr.TelefonoContacto = p.TelefonoContacto;
                pr.TipoDonacion = p.TipoDonacion;

                if (p.TipoDonacion == (int)EnumTipoDonacion.Monetaria)
                {
                    pr.PropuestasDonacionesMonetarias.First().CBU = p.PropuestasDonacionesMonetarias.First().CBU;
                    pr.PropuestasDonacionesMonetarias.First().Dinero = p.PropuestasDonacionesMonetarias.First().Dinero;
                }
                if (p.TipoDonacion == (int)EnumTipoDonacion.Insumo)
                {
                    for (int i = 0; i < p.PropuestasDonacionesInsumos.Count; i++)
                    {
                        pr.PropuestasDonacionesInsumos.ToList()[i].Cantidad = p.PropuestasDonacionesInsumos.ToList()[i].Cantidad;
                        pr.PropuestasDonacionesInsumos.ToList()[i].Nombre = p.PropuestasDonacionesInsumos.ToList()[i].Nombre;
                    }

                }
                if (p.TipoDonacion == (int)EnumTipoDonacion.HorasTrabajo)
                {
                    pr.PropuestasDonacionesHorasTrabajo.First().Profesion = p.PropuestasDonacionesHorasTrabajo.First().Profesion;
                    pr.PropuestasDonacionesHorasTrabajo.First().CantidadHoras = p.PropuestasDonacionesHorasTrabajo.First().CantidadHoras;
                }

                var filename = Path.GetFileName(Foto.FileName);
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/"), filename);
                Foto.SaveAs(path);
                pr.Foto = filename;


                ctx.SaveChanges();

            }
        }
        public Propuestas GetPorId(int id)
        {
            using (Entities ctx = new Entities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var p = (from pr in ctx.Propuestas.Include("PropuestasDonacionesHorasTrabajo").Include("PropuestasDonacionesInsumos").Include("PropuestasDonacionesMonetarias")
                         where pr.IdPropuesta == id
                         select pr).FirstOrDefault();
                return p;
            }
        }

    }
}
