using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class LoginController : Controller
    {
        Entities asd = new Entities();
        // GET: Login
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
            if (s["pass"].Length == 0)
            {
                ModelState.AddModelError("pass", "puto el que lee 2.");



            }
           else if (!u.Password.Equals(s["pass"]))
            {
                ModelState.AddModelError("pass", "puto el que lee.");
            }

            

            if (ModelState.IsValid)
            {
                Usuarios n = new Usuarios();
                
                n.Activo = true;
                n.Token = "asdsad";
                n.FechaCracion = DateTime.Today;
                n.TipoUsuario = 1;
                n.FechaNacimiento = u.FechaNacimiento;
                n.Email = u.Email;
                n.Password = u.Password;
                
                asd.Usuarios.Add(n);
                asd.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View("Registrar");

        }

    }
}