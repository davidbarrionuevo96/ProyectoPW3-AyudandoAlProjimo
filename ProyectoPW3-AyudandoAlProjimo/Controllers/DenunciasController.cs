using System;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class DenunciasController : Controller
    {
        DenunciasService l = new DenunciasService();
        public ActionResult Desestimar( String id)
        {
            int idInt = Int32.Parse(id);
            l.DesestimarDenuncia(idInt);
            return RedirectToAction("Denuncias", "Home");
        }

        public ActionResult Aceptar(String id)
        {
            int idInt = Int32.Parse(id);
            l.AceptarDenuncia(idInt);
            return RedirectToAction("Denuncias", "Home");
        }
    }
}