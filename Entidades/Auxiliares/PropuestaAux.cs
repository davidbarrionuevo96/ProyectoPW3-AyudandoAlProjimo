using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entidades.Auxiliares
{
    public  class PropuestaAux
    {   //Horas de Trabajo
        [Required(ErrorMessage = "La cantidad de horas es requerida")]
        public int CantidadHoras { get; set; }

        [Required(ErrorMessage = "La profesion es requerida")]
        public string Profesion { get; set; }
        //Horas de Trabajo
        //Insumos

        [Required(ErrorMessage = "La cantidad de insumos es requerida")]
        public int CantidadIns { get; set; }
        public List<PropuestasDonacionesInsumos> pins { get; set; }
        //Insumos
        //Monetaria
        [Required(ErrorMessage = "El dinero es requerido")]
        public decimal Dinero { get; set; }
        [Required(ErrorMessage = "El CBU es requerido")]
        public string CBU { get; set; }
        //Monetaria

        /// <summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre debe ser como maximo 50 caracteres")
       , MinLength(2, ErrorMessage = "El nombre debe ser como minimo dos caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(280, ErrorMessage = "La descripcion debe ser como maximo 280 caracteres")
        , MinLength(2, ErrorMessage = "El nombre debe ser como minimo dos caracteres")]
        //[StringLength(50, ErrorMessage = "El nombre debe ser menor a 50 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Fecha de Fin es requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha es invalida")]
        public System.DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "La Fecha de Creacion es requerida")]
        [RegularExpression("([1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]*)", ErrorMessage = "Telefono invalido")]
        public string TelefonoContacto { get; set; }
        /// </summary>
        public int IdPropuesta { get; set; }
        public int TipoDonacion { get; set; }
        public HttpPostedFileBase Foto { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int Estado { get; set; }
        [Required(ErrorMessage = "El telefono de es requerido")]
        [RegularExpression("([1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]*)", ErrorMessage = "Telefono invalido")]
        public string Telefono1{ get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre debe ser como maximo 50 caracteres")
       , MinLength(2, ErrorMessage = "El nombre debe ser como minimo dos caracteres")]
        public string NombreRef1 { get; set; }
        [Required(ErrorMessage = "El telefono de es requerido")]
        [RegularExpression("([1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]*)", ErrorMessage = "Telefono invalido")]
        public string Telefono2 { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre debe ser como maximo 50 caracteres")
      , MinLength(2, ErrorMessage = "El nombre debe ser como minimo dos caracteres")]
        public string NombreRef2 { get; set; }
        public Nullable<decimal> Valoracion { get; set; }
    }
}
