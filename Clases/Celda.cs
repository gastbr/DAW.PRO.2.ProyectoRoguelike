using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Celda
    {
        public bool ocupada;
        public abstract void dibuja();
    }
}
