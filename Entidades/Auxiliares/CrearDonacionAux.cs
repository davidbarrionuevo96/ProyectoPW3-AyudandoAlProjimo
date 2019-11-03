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
        public CrearDonacionAux()
        {
            CantidadHoras = 0;
            Dinero = 0;
            TotalMon = 0;
            FaltanteMon = 0;
            Totales = new List<int>();
            Faltantes = new List<int>();
        }
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
        public decimal TotalMon { get; set; }
        public string Profesion { get; set; }
        public int Faltanteh { get; set; }
        public int Totalh { get; set; }
        public decimal FaltanteMon { get; set; }
        public List<int> Totales { get; set; }
        public List<int> Faltantes { get; set; }
    }
}
