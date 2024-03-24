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
        public int x;
        public int y;
        public Celda(int x, int y)
        {
            ocupada = false;
            this.x = x;
            this.y = y;
        }
        public abstract void dibuja();
    }
}
