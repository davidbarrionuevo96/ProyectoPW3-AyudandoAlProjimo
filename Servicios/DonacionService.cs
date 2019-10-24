﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Servicios
{
    public class DonacionService
    {
        public List<Donacion> MisDonacionesId(int id)
        {
            Entities ctx = new Entities();
            List<Donacion> donacions = new List<Donacion>();

            #region Donaciones por Id Consulta
            var Donaciones = (from p in ctx.Propuestas
                              join p_mon in ctx.PropuestasDonacionesMonetarias
                               on p.IdPropuesta equals p_mon.IdPropuesta
                              join d_mon in ctx.DonacionesMonetarias
                               on p_mon.IdPropuestaDonacionMonetaria equals d_mon.IdPropuestaDonacionMonetaria
                              where d_mon.IdUsuario == id
                              select new Donacion
                              {
                                  Estado = p.Estado,
                                  FechaDonacion = d_mon.FechaCreacion,
                                  IdUsuario = d_mon.IdUsuario,
                                  MiDonacion = d_mon.Dinero,
                                  Nombre = p.Nombre,
                                  TipoDonacion = 3,
                                  TotalRecaudado = 9
                              }
                             ).ToList();

            var DonacionesI = (from p in ctx.Propuestas
                               join p_in in ctx.PropuestasDonacionesInsumos
                                on p.IdPropuesta equals p_in.IdPropuesta
                               join d_in in ctx.DonacionesInsumos
                                on p_in.IdPropuestaDonacionInsumo equals d_in.IdPropuestaDonacionInsumo
                               where d_in.IdUsuario == id
                               select new Donacion
                               {
                                   Estado = p.Estado,
                                   // = d_in.FechaCreacion,
                                   IdUsuario = d_in.IdUsuario,
                                   MiDonacion = d_in.Cantidad,
                                   Nombre = p.Nombre,
                                   TipoDonacion = 2,
                                   TotalRecaudado = 9
                               }
                             ).ToList();
            var DonacionesHrs = (from p in ctx.Propuestas
                                 join p_hrs in ctx.PropuestasDonacionesHorasTrabajo
                                  on p.IdPropuesta equals p_hrs.IdPropuesta
                                 join d_hrs in ctx.DonacionesHorasTrabajo
                                  on p_hrs.IdPropuestaDonacionHorasTrabajo equals d_hrs.IdPropuestaDonacionHorasTrabajo
                                 where d_hrs.IdUsuario == id
                                 select new Donacion
                                 {
                                     Estado = p.Estado,
                                     // = d_hrs.FechaCreacion,
                                     IdUsuario = d_hrs.IdUsuario,
                                     MiDonacion = d_hrs.Cantidad,
                                     Nombre = p.Nombre,
                                     TipoDonacion = 2,
                                     TotalRecaudado = 9
                                 }
                             ).ToList();
            #endregion

            donacions.AddRange(Donaciones);
            donacions.AddRange(DonacionesI);
            donacions.AddRange(DonacionesHrs);

            return donacions;
        }
    }
}