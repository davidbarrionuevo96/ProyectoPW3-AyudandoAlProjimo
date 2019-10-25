﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
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
            if (p.TipoDonacion==1)
            {
                pm.Dinero = Convert.ToDecimal(form["Dinero"]);
                pm.CBU = form["CBU"];

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesMonetarias.Add(pm);
            }
            else if (p.TipoDonacion == 2)
            {
                pi.Nombre = form["NombreIns"];
                pi.Cantidad = Convert.ToInt32(form["Cantidad"]);

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesInsumos.Add(pi);
            }
            else if (p.TipoDonacion == 3)
            {
                ph.CantidadHoras = Convert.ToInt32(form["CantidadHoras"]);
                ph.Profesion = form["Profesion"];

                p.IdUsuarioCreador = int.Parse(Session["usuario"].ToString());
                p.PropuestasDonacionesHorasTrabajo.Add(ph);
            }
            _propuestaService.RegistrarPropuesta(p);
            return RedirectToAction("MisPrupuestas", "Propuestas");

        }
        public ActionResult Modificar(int id)
        {
            
            
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(Propuestas p, FormCollection form)
        {
            PropuestaAux paux = new PropuestaAux();

            if (p.TipoDonacion == 1)
            {
                paux.Dinero = Convert.ToDecimal(form["Dinero"]);
                paux.CBU = form["CBU"];
            }
            else if (p.TipoDonacion == 2)
            {
                paux.NombreIns = form["NombreIns"];
                paux.CantidadIns = Convert.ToInt32(form["Cantidad"]);
            }
            else if (p.TipoDonacion == 3)
            {
                paux.CantidadHoras = Convert.ToInt32(form["CantidadHoras"]);
                paux.Profesion = form["Profesion"];
            }
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