using Entidades;
using Entidades.Auxiliares;
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
            using (Entities ctx=new Entities())
            {
                //1->Monetaria   2->Insumos   3->HorasDeTrabajo

                Propuestas prop = GetPorId(paux.IdPropuesta);

                prop.Descripcion = paux.Descripcion;
                prop.Estado = paux.Estado;
                prop.FechaFin = paux.FechaFin;
                prop.Foto = paux.Foto;
                prop.Nombre = paux.Nombre;
                prop.TelefonoContacto = paux.TelefonoContacto;

                if (prop.TipoDonacion==1)
                {
                    prop.PropuestasDonacionesMonetarias.Single().Dinero=paux.Dinero;
                    prop.PropuestasDonacionesMonetarias.Single().CBU = paux.CBU;
                }
                else if (prop.TipoDonacion == 2)
                {   
                    prop.PropuestasDonacionesInsumos.Single().Cantidad = paux.CantidadIns;
                    prop.PropuestasDonacionesInsumos.Single().Nombre = paux.NombreIns;
                }
                else if (prop.TipoDonacion == 3)
                {
                    prop.PropuestasDonacionesHorasTrabajo.Single().CantidadHoras= paux.CantidadHoras;
                    prop.PropuestasDonacionesHorasTrabajo.Single().Profesion = paux.Profesion;
                }


                ctx.SaveChanges();
            }
        }
        public Propuestas GetPorId(int id)
        {
            using (Entities ctx=new Entities())
            {
                Propuestas p = (from pr in ctx.Propuestas
                                where pr.IdPropuesta == id
                                select pr).Single();
                return p;
            }
        }
        

    }
}
