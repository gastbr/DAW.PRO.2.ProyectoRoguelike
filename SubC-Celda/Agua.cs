using DAW.PRO._2.ProyectoRoguelike.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.SubC_Celda
{
    internal class Agua : Celda
    {
        public Agua(int x, int y) : base(x, y)
        {
            nombre = "Agua";
        }

        public override void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
        }
        public void PersonajeMojado()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("a");
        }
    }
}
