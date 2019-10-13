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
        LoginService l = new LoginService();
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
                if (l.BuscarUsuario(u).Count == 1)
                {
                    Session["usuario"] = l.BuscarUsuario(u);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Usuario y/o contraseña Invalido";
                    return View("Login");
                }
            }
            return View("Login");

        }

        [HttpPost]
        public ActionResult ValidarUsuarioRegistrar(Usuarios u, FormCollection s)
        {
            if (l.ExisteCorreo(u).Count == 1)
            {
                ModelState.AddModelError("Email", "Email ya registrado");
            }

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