using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Celda
{
    internal class Salida : Celda
    {
        public Salida(int x, int y) : base(x, y)
        {
        }

        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
        }
    }
}
