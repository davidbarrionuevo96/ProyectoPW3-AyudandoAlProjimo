using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Entidades.Enums;
using Entidades.Auxiliares;
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
            PropuestasDonacionesMonetarias pm = new PropuestasDonacionesMonetarias();
            PropuestasDonacionesInsumos pi = new PropuestasDonacionesInsumos();
            PropuestasDonacionesHorasTrabajo ph = new PropuestasDonacionesHorasTrabajo();
            //1->Monetaria   2->Insumos   3->HorasDeTrabajo
            if (p.TipoDonacion==(int)EnumTipoDonacion.Monetaria)
            {
                pm.Dinero = Convert.ToDecimal(form["Dinero"]);
                pm.CBU = form["CBU"];

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesMonetarias.Add(pm);
            }
            else if (p.TipoDonacion == (int)EnumTipoDonacion.Insumo)
            {
                pi.Nombre = form["NombreIns"];
                pi.Cantidad = Convert.ToInt32(form["Cantidad"]);

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesInsumos.Add(pi);
            }
            else if (p.TipoDonacion == (int)EnumTipoDonacion.HorasTrabajo)
            {
                ph.CantidadHoras = Convert.ToInt32(form["CantidadHoras"]);
                ph.Profesion = form["Profesion"];

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesHorasTrabajo.Add(ph);
            }
            _propuestaService.RegistrarPropuesta(p);
            return RedirectToAction("MisPrupuestas", "Propuestas");

        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.IdPropuesta = id;
            ViewBag.Tipo = (_propuestaService.GetPorId(id)).TipoDonacion;
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(PropuestaAux p)
        {
            
            _propuestaService.ModificarPropuesta(p);

            return RedirectToAction("MisPrupuestas", "Propuestas");

            //return View();
        }
        public ActionResult MisPropuestas()
        {
            //no esta hecho
            return View();
        }
    }
}