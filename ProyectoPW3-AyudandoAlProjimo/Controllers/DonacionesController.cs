using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Entidades.Auxiliares;
using Servicios;
using WebApiDonaciones.Controllers;
namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class DonacionesController : Controller
    {
        private PropuestaService _propuestaService = new PropuestaService();
        private DonacionService _DonacionService = new DonacionService();
        public ActionResult MiHistorialDonaciones()
        {
            ViewBag.Usuario = Session["usuario"];
            return View();
        }
        [HttpGet]
        public ActionResult RealizarDonacion(int id)
        {
            ViewBag.IdPropuesta = id;
            ViewBag.Tipo = (_propuestaService.GetPorId(id)).TipoDonacion;
            return View();
        }
        [HttpPost]
        public ActionResult RealizarDonacion(CrearDonacionAux cd)
        {   cd.IdUsuario= int.Parse(Session["usuario"].ToString());
            _DonacionService.RealizarDonacion(cd);

            return View();
        }
    }
}