using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;
using WebApiDonaciones.Controllers;
namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class DonacionesController : Controller
    {
        
        public ActionResult MiHistorialDonaciones()
        {
            ViewBag.Usuario = Session["usuario"];
            return View();
        }
    }
}