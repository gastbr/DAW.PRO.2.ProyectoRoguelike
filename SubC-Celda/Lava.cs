using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Celda
{
    internal class Lava : Clases.Celda
    {
        public override void dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("~");
        }
        public void personajeQuemado()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("a");
        }
    }
}
