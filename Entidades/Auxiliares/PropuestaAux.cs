using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entidades.Auxiliares
{
    public  class PropuestaAux
    {   //Horas de Trabajo
        public int CantidadHoras { get; set; }
        public string Profesion { get; set; }
        //Horas de Trabajo
        //Insumos
        public string NombreIns { get; set; }
        public int CantidadIns { get; set; }
        public List<PropuestasDonacionesInsumos> pins { get; set; }
        //Insumos
        //Monetaria
        public decimal Dinero { get; set; }
        public string CBU { get; set; }
        //Monetaria
        public int IdPropuesta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaFin { get; set; }
        public string TelefonoContacto { get; set; }
        public int TipoDonacion { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int Estado { get; set; }
        public string Telefono1{ get; set; }
        public string NombreRef1 { get; set; }
        public string Telefono2 { get; set; }
        public string NombreRef2 { get; set; }
        public Nullable<decimal> Valoracion { get; set; }
    }
}
