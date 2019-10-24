using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System;
using System.Web;


namespace Servicios
{
    public class DenunciasService
    {
        Entities asd = new Entities();
        public void DesestimarDenuncia(int u)
        {
            var usua = (from p in asd.Denuncias
                        where p.IdDenuncia == u
                        select p).ToList();

            Denuncias usu2 = new Denuncias();
            foreach (var a in usua)
            {
                usu2 = a;
            }
            usu2.Estado = 2;
            asd.SaveChanges();
        }

        public void AceptarDenuncia(int u)
        {
            var usua = (from p in asd.Denuncias
                        where p.IdDenuncia == u
                        select p).ToList();

            Denuncias usu2 = new Denuncias();
            foreach (var a in usua)
            {
                usu2 = a;
            }
            usu2.Estado = 0;
            asd.SaveChanges();
        }



    }
    
}
