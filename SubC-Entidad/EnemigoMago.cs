﻿using DAW.PRO._2.ProyectoRoguelike.Clases;
using DAW.PRO._2.ProyectoRoguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Entidad
{
    internal class EnemigoMago : Entidad, IMago
    {
        public EnemigoMago()
        {
            nombre = "";
            x = 0;
            y = 0;
            direccion = Direccion.derecha;
            oro = 0;
            nivel = 1;
            vidaMax = 30;
            vidaActual = 30;
            ataque = 3;
            defensa = 0;
        }

        public void atacaDistancia()
        {
            throw new NotImplementedException();
        }

        public void creaPortal()
        {
            throw new NotImplementedException();
        }

        public void cura()
        {
            throw new NotImplementedException();
        }
    }
}