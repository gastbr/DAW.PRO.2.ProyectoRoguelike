using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike
{
    internal class Celda
    {
        Terreno terreno;
        public Celda() {
            terreno = Terreno.Muro;
        }

        public void Dibuja()
        {
            switch (terreno)
            {
                case Terreno.Muro:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Terreno.Suelo:
                    Console.Write(" ");
                    break;
                case Terreno.Agua:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Terreno.Lava:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Terreno.Puerta:
                    Console.Write("X");
                    break;
                case Terreno.Evento:
                    Console.Write("?");
                    break;
            }
        }
    }
}
