﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Auxiliares
{
    public class CrearDonacionAux
    {
        //Horas de Trabajo
        public int CantidadHoras { get; set; }
        //Horas de Trabajo
        //Insumos
        public string NombreIns { get; set; }
        public int CantidadIns { get; set; }
        //Insumos
        //Monetaria
        public decimal Dinero { get; set; }
        public string ArchivoTransferencia { get; set; }
        //Monetaria
        public int IdPropuesta { get; set; }
        public int TipoDonacion { get; set; }
        public int IdUsuario { get; set; }
    }
}