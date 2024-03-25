using System;
using System.Collections.Generic;
using System.Linq;
using DAW.PRO._2.ProyectoRoguelike.Clases;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Celda
{
    internal class Suelo : Celda
    {
        public Suelo(int x, int y) : base(x, y)
        {
        }

        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
