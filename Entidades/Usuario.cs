using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuario{
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress(ErrorMessage ="Formato valido: ejemplo@ejemplo.com.ar")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage ="Las contraseñas no coinciden")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
