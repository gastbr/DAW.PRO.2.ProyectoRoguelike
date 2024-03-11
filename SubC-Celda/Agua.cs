using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Celda
{
    internal class Agua : Clases.Celda
    {
        public override void dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
        }
        public void personajeMojado()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("a");
        }
    }
}
