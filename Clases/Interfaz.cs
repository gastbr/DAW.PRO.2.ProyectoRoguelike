using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Interfaz
    {
        static string info = "HOMBRE SOSPECHOSO CON LA BRAGUETA BAJADA:\n\"Tráeme el mono de jade antes de que cambie la luna y te daré una buena recompensa.\"";
        static int posX = 97;
        static int posY = 0;
        public static void DibujaHUD()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(posX, posY);
            Console.Write(Partida.protagonista.nombre + " (" + Partida.protagonista.profesion + ")");
            Console.SetCursorPosition(posX, posY + 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (Partida.protagonista.salaActual == 0)
            {
                Console.Write("PISO ACTUAL:\t" + "PB".ToString().PadLeft(3));
            }
            else
            {
                Console.Write("PISO ACTUAL:\t" + Partida.protagonista.salaActual.ToString().PadLeft(3));
            }
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("ORO:\t\t" + Partida.protagonista.oro.ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("NIVEL:\t\t" + Partida.protagonista.nivel.ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("EXP:\t\t" + Partida.protagonista.experiencia.ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("ATQ:\t\t" + Partida.protagonista.ataque.ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("DEF:\t\t" + Partida.protagonista.defensa.ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 9);
            Console.Write("HP:\t ");
            if (Partida.protagonista.vidaActual < Partida.protagonista.vidaMax * 0.3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Partida.protagonista.vidaActual.ToString().PadLeft(3));
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Partida.protagonista.vidaActual.ToString().PadLeft(3));
            }
            Console.Write("  /  " + Partida.protagonista.vidaMax);

            /*
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(posX, posY + 15);
            Console.Write("Pos: ".PadRight(9) + $"{Partida.protagonista.x}".PadLeft(3) + " / " + $"{Partida.protagonista.y}".PadLeft(3));
            Console.SetCursorPosition(posX, posY + 16);
            Console.Write("Pre: ".PadRight(9) + $"{Partida.protagonista.preX}".PadLeft(3) + " / " + $"{Partida.protagonista.preY}".PadLeft(3));
            Console.SetCursorPosition(posX, posY + 17);
            Console.Write("Terreno:".PadRight(9) + $"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".Substring($"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".LastIndexOf('.') + 1).PadLeft(9));
            Console.SetCursorPosition(posX, posY + 18);
            Console.Write("Ves:".PadRight(9) + $"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".Substring($"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".LastIndexOf('.') + 1).PadLeft(9));
            */

            Console.SetCursorPosition(posX, posY + 11);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('@');
            Console.Write(" - ");
            Console.Write("Protagonista");

            Console.SetCursorPosition(posX, posY + 12);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('Ï');
            Console.Write(" - ");
            Console.Write("Enemigos");
                        
            Console.SetCursorPosition(posX, posY + 13);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('ï');
            Console.Write(" - ");
            Console.Write("PNJ");
                        
            Console.SetCursorPosition(posX, posY + 14);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write('?');
            Console.Write(" - ");
            Console.Write("Objetos");
                        
            Console.SetCursorPosition(posX, posY + 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('~');
            Console.Write(" - ");
            Console.Write("Agua");
                        
            Console.SetCursorPosition(posX, posY + 16);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('~');
            Console.Write(" - ");
            Console.Write("Lava");
                        
            Console.SetCursorPosition(posX, posY + 17);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('֍');
            Console.Write(" - ");
            Console.Write("Trampa");
                        
            Console.SetCursorPosition(posX, posY + 18);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write('<');
            Console.Write(" - ");
            Console.Write("Entrada");
                        
            Console.SetCursorPosition(posX, posY + 19);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write('>');
            Console.Write(" - ");
            Console.Write("Salida");

            //////////////////////////

            Console.SetCursorPosition(posX, posY + 22);
            Console.Write("CONTROLES:");
            Console.SetCursorPosition(posX, posY + 23);
            Console.Write("Flechas:".PadRight(9) + "MOVER".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 24);
            Console.Write("Shift:".PadRight(9) + "EXAMINAR".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 25);
            Console.Write("Enter:".PadRight(9) + "OBJETOS".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 26);
            Console.Write("Esc:".PadRight(9) + "OPCIONES".PadLeft(9));
        }
        static public void dibujaInfo(string texto)
        {
            info = texto.PadRight(360).Substring(0, 360);
            Console.SetCursorPosition(0, 27);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < info.Length; i++)
            {
                Console.Write(info[i]);
                Thread.Sleep(20);
            }
            Console.ReadLine();
            for (int i = 0; i < info.Length; i++)
            {
                Console.Write(" ");
            }
            info = "";
        }

    }
}
