using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
    public class LoginService
    {

        public void RegistrarUsuario(Usuarios u)
        {
            Entities asd = new Entities();

            u.Activo = false;
            u.Token = "asdsad";
            u.FechaCracion = DateTime.Today;
            u.TipoUsuario = 1;

            asd.Usuarios.Add(u);
            asd.SaveChanges();
        }
    }
}
