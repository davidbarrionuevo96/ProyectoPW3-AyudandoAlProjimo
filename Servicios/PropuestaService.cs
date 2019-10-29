using Entidades;
using Entidades.Auxiliares;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PropuestaService
    {
        public void RegistrarPropuesta(PropuestaAux p)
        {
            Propuestas pr = new Propuestas();
            pr.Descripcion = p.Descripcion;
            pr.Estado = 1;
            pr.FechaCreacion = DateTime.Today;
            pr.FechaFin = p.FechaFin;

            String filename = Path.GetFileName(p.Foto.FileName);
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/img/propuestas/"), filename);
            p.Foto.SaveAs(path);
            pr.Foto = filename;

            pr.PropuestasReferencias.Add(
                new PropuestasReferencias()
                {
                 Nombre=p.NombreRef1,
                 Telefono=p.Telefono1
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

            if (p.TipoDonacion==(int)EnumTipoDonacion.Monetaria)
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

        public List<PropuestasDonacionesInsumos> CrearListaPropuestasInsumos(int cant)
        {
            List<PropuestasDonacionesInsumos> list = new List<PropuestasDonacionesInsumos>();
            for (int i = 0; i <cant; i++)
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
            Entities ctx = new Entities();
            var v = (from p in ctx.PropuestasDonacionesInsumos
                             where p.IdPropuesta == id
                             select p.Cantidad
                             ).First();
            return v;
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
        public int CalcularTotalPropuestaIns(int id)
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
        public int CalcularTotalPropuestaHrs(int id)
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
        public decimal CalcularTotalPropuestaMon(int id)
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
            if (dlist.Count>0 )
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
            using (var ctx=new Entities())
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
                           where p.IdPropuesta==id
                           select p_m.Profesion).First();
                return pro;
            }
        }
        public void ModificarPropuesta(PropuestaAux paux)
        {
            
            using (var ctx=new Entities())
            {
                //1->Monetaria   2->Insumos   3->HorasDeTrabajo

                Propuestas prop = (from pr in ctx.Propuestas
                                   where pr.IdPropuesta == paux.IdPropuesta
                                   select pr).First();

                prop.Descripcion = paux.Descripcion;
                prop.Estado = paux.Estado;
                prop.FechaFin = paux.FechaFin;
                //prop.Foto = paux.Foto;
                prop.Foto = "FotoNueva";
                prop.Nombre = paux.Nombre;
                prop.TelefonoContacto = paux.TelefonoContacto;

                if (prop.TipoDonacion == (int)EnumTipoDonacion.Monetaria)
                {
                    prop.PropuestasDonacionesMonetarias.FirstOrDefault().Dinero = paux.Dinero;
                    prop.PropuestasDonacionesMonetarias.FirstOrDefault().CBU = paux.CBU;
                }
                else if (prop.TipoDonacion == (int)EnumTipoDonacion.Insumo)
                {
                    prop.PropuestasDonacionesInsumos.FirstOrDefault().Cantidad = paux.CantidadIns;
                    prop.PropuestasDonacionesInsumos.FirstOrDefault().Nombre = paux.NombreIns;
                }
                else if (prop.TipoDonacion == (int)EnumTipoDonacion.HorasTrabajo)
                {
                    prop.PropuestasDonacionesHorasTrabajo.FirstOrDefault().CantidadHoras = paux.CantidadHoras;
                    prop.PropuestasDonacionesHorasTrabajo.FirstOrDefault().Profesion = paux.Profesion;
                }


                ctx.SaveChanges();

            }
        }
        public Propuestas GetPorId(int id)
        {
            using (Entities ctx=new Entities())
            {
                var p =( from pr in ctx.Propuestas
                               where pr.IdPropuesta == id
                               select pr).FirstOrDefault();
                return p;
            }
        }
        //borrar
        public Propuestas GetPropuestaMonetaria(int id)
        {
            using (Entities ctx = new Entities())
            {
                var p = (from pr in ctx.Propuestas
                         where pr.IdPropuesta == id
                         select pr).FirstOrDefault();
                return p;
            }
        }
    }
}
