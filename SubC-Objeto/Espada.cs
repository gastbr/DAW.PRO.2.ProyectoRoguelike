﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAW.PRO._2.ProyectoRoguelike.Clases;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Objeto
{
    internal class Espada : Objeto
    {
        public Espada()
        {
            nombre = "Espada";
        }
        public override void Aplica(Entidad personaje)
        {
            personaje.ataque *= 2;
        }
    }
}
