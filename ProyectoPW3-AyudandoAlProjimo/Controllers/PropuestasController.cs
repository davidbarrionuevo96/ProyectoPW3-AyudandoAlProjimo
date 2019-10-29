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
        public ActionResult Crear(PropuestaAux p)
        {
            p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());


            if (p.TipoDonacion==(int)EnumTipoDonacion.Insumo)
            {
                p.pins = new List<PropuestasDonacionesInsumos>();
                Session["pinsumo"]=p;
                return RedirectToAction("CargarListaInsumos", "Propuestas",p);
            }
            _propuestaService.RegistrarPropuesta(p);
            return RedirectToAction("MisPrupuestas", "Propuestas");
        }

        [HttpGet]
        public ActionResult CargarListaInsumos(PropuestaAux p)
        {            
            //idpropuesta nombre cant
            return View(_propuestaService.CrearListaPropuestasInsumos(p.CantidadIns));
        }
        [HttpPost]
        public ActionResult CargarListaInsumos(List<PropuestasDonacionesInsumos> plist)
        {
            PropuestaAux p= (PropuestaAux)Session["pinsumo"];
           
                foreach (var item in plist)
                {
                    p.pins.Add(item);
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