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
        public ActionResult ValidarUsuario(Usuario u)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index","Home");
            }
            return View("Login");

        }
        [HttpPost]
        public ActionResult ValidarUsuarioRegistrar(Usuario u)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home");
            }
            return View("Registrar");

        }

    }
}