using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Auxiliares
{
    public class CrearDonacionAux
    {
        //Horas de Trabajo
        [Required(ErrorMessage = "Cantidad invalida")]
        [Range(0, int.MaxValue)]
        public int CantidadHoras { get; set; }
        //Horas de Trabajo
        //Insumos
        public List<DonacionesInsumos> dlistins { get; set; }
        //Insumos
        //Monetaria
        [Required(ErrorMessage = "Dinero invalido")]
        [Range(0, int.MaxValue)]
        public decimal Dinero { get; set; }
        public string ArchivoTransferencia { get; set; }
        //Monetaria
        public int IdPropuesta { get; set; }
        public int TipoDonacion { get; set; }
        public int IdUsuario { get; set; }
    }
}
