using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;
namespace ProyectoPW3_AyudandoAlProjimo.Controllers
{
    public class PropuestasController : Controller
    {
        private readonly PropuestaService _propuestaService = new PropuestaService();
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Propuestas p, FormCollection form)
        {
            PropuestasDonacionesMonetarias pr = new PropuestasDonacionesMonetarias();
            pr.Dinero = Convert.ToDecimal(form["Dinero"]);
            pr.CBU = form["CBU"];
            p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());

            p.PropuestasDonacionesMonetarias.Add(pr);

            _propuestaService.RegistrarPropuesta(p);
            return RedirectToAction("MisPrupuestas", "Propuestas");


        }
    }
}