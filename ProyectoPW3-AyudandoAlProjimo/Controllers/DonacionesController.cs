using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Entidades.Enums;
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
        { int tipo = (_propuestaService.GetPorId(id)).TipoDonacion;
            ViewBag.IdPropuesta = id;
            if (tipo==(int)EnumTipoDonacion.Monetaria)
            {
                ViewBag.Total = _propuestaService.TotalPropuestaMon(id);
                ViewBag.Faltante = (_propuestaService.TotalPropuestaMon(id) - _propuestaService.CalcularTotalPropuestaMon(id));
            }
            else if (tipo == (int)EnumTipoDonacion.HorasTrabajo)
            {
                ViewBag.Total = _propuestaService.TotalPropuestaHrs(id);
                ViewBag.Profesion = _propuestaService.RetornarProfesionPorIdPropuesta(id);
                ViewBag.Faltante = (_propuestaService.TotalPropuestaHrs(id) - _propuestaService.CalcularTotalPropuestaHrs(id));
            }
            ViewBag.Tipo = tipo;
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