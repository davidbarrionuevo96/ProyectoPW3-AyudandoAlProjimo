using Entidades;
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

    }
}
