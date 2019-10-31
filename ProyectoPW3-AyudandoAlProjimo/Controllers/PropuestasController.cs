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
        static HttpPostedFileBase fotofija;
        private readonly PropuestaService _propuestaService = new PropuestaService();
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(PropuestaAux p, HttpPostedFileBase Foto)
        {
            p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());

            fotofija = Foto;
            if (p.TipoDonacion==(int)EnumTipoDonacion.Insumo)
            {
                p.pins = new List<PropuestasDonacionesInsumos>();
                Session["pinsumo"]=p;
                return RedirectToAction("CargarListaInsumos", "Propuestas",p);
            }
            _propuestaService.RegistrarPropuesta(p, Foto);
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
            _propuestaService.RegistrarPropuesta(p,fotofija);
            return RedirectToAction("MisPrupuestas", "Propuestas");
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.IdPropuesta = id;
            ViewBag.TamListaIns = _propuestaService.TamListaInsPorId(id);
            ViewBag.Tipo = (_propuestaService.GetPorId(id)).TipoDonacion;
            var p = _propuestaService.GetPorId(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Modificar(Propuestas p, HttpPostedFileBase FotoN,PropuestasDonacionesMonetarias pm,PropuestasDonacionesHorasTrabajo ph,List<PropuestasDonacionesInsumos> li)
        {
            if (p.TipoDonacion==(int)EnumTipoDonacion.Monetaria)
            {
                p.PropuestasDonacionesMonetarias.Add(pm);
            }
            if (p.TipoDonacion == (int)EnumTipoDonacion.HorasTrabajo)
            {
                p.PropuestasDonacionesHorasTrabajo.Add(ph);
            }
            if (p.TipoDonacion == (int)EnumTipoDonacion.Insumo)
            {
                foreach (var item in li)
                {
                    p.PropuestasDonacionesInsumos.Add(item);
                }
            }

            _propuestaService.ModificarPropuesta(p, FotoN);

            return RedirectToAction("MisPrupuestas", "Propuestas");

            //return View();
        }
        public ActionResult MisPropuestas()
        {
            if (Session["usuario"] != null)
            {
                return View("MisPropuestas", _propuestaService.BuscarPropuestas());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult Activas()
        {
            if (Session["usuario"] != null)
            {
                return View("MisPropuestas", _propuestaService.BuscarPropuestasActivas());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult Inactivas()
        {
            if (Session["usuario"] != null)
            {
                return View("MisPropuestas", _propuestaService.BuscarPropuestasInactivas());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}