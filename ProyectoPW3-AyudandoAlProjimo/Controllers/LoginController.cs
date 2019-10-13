using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarUsuario(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            return View("Login");

        }
        [HttpPost]
        public ActionResult ValidarUsuarioRegistrar(Usuarios u, FormCollection s)
        {
            DateTime horacorta = u.FechaNacimiento;
            TimeSpan ts = DateTime.Today - horacorta;
            int diferencia = ts.Days;

            if (diferencia <= 6570)
            {
                ModelState.AddModelError("FechaNacimiento", "Tiene que ser mayor a 18 años");
            }
            if (s["pass"].Length == 0)
            {
                ModelState.AddModelError("pass", "Campo obligatorio");
            }
           else if (!u.Password.Equals(s["pass"]))
            {
                ModelState.AddModelError("pass", "Las contraseñas no coinciden");
            }
            if (ModelState.IsValid)
            {
                LoginService l = new LoginService();
                l.RegistrarUsuario(u);
                l.enviarCorreo(u);
                return RedirectToAction("Index", "Home");
            }
            return View("Registrar");

        }

    }
}