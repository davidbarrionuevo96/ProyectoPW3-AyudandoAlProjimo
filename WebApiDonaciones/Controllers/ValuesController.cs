using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDonaciones.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private Entities ctx = new Entities();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/1
        public List<Donacion> Get(int id)
        {

            var Donaciones = (from p in ctx.Propuestas
                             join p_mon in ctx.PropuestasDonacionesMonetarias
                              on p.IdPropuesta equals p_mon.IdPropuesta
                             join d_mon in ctx.DonacionesMonetarias
                              on p_mon.IdPropuestaDonacionMonetaria equals d_mon.IdPropuestaDonacionMonetaria
                             where d_mon.IdUsuario==id
                             select new Donacion {Estado=p.Estado,
                                                 FechaDonacion =d_mon.FechaCreacion,
                                                 IdUsuario =d_mon.IdUsuario,
                                                 MiDonacion =d_mon.Dinero,
                                                 Nombre =p.Nombre,
                                                 TipoDonacion =1,
                                                 TotalRecaudado =9}
                             ).ToList();
            
            return Donaciones;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
