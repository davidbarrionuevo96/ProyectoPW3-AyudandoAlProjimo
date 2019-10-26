using Entidades;
using Entidades.Auxiliares;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PropuestaService
    {
        public void RegistrarPropuesta(Propuestas p)
        {
            using (Entities ctx = new Entities())
            {

                p.FechaCreacion = DateTime.Today;
                p.Estado = 1;
                p.Foto = "asdas";
                ctx.Propuestas.Add(p);
                ctx.SaveChanges();
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

    }
}
