using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Foto { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int Estado { get; set; }
        public Nullable<decimal> Valoracion { get; set; }
    }
}
