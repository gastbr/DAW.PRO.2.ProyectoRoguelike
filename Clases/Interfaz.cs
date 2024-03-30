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
        static string nombrePersonaje = "";
        static string frasePersonaje = "";
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
                Console.Write("PISO ACTUAL:\t" + "PB".ToString().PadLeft(4));
            }
            else
            {
                Console.Write("PISO ACTUAL:\t" + Partida.protagonista.salaActual.ToString().PadLeft(4));
            }
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("ORO:\t\t" + Partida.protagonista.oro.ToString().PadLeft(4));
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("NIVEL:\t\t" + Partida.protagonista.nivel.ToString().PadLeft(4));
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("EXP:\t\t" + Partida.protagonista.experiencia.ToString().PadLeft(4));
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("ATQ:\t\t" + Partida.protagonista.ataque.ToString().PadLeft(4));
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("DEF:\t\t" + Partida.protagonista.defensa.ToString().PadLeft(4));
            Console.SetCursorPosition(posX, posY + 9);
            Console.Write("HP:\t ");
            if (Partida.protagonista.vidaActual < Partida.protagonista.vidaMax * 0.3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Partida.protagonista.vidaActual.ToString().PadLeft(4));
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Partida.protagonista.vidaActual.ToString().PadLeft(4));
            }
            Console.Write("  /  " + Partida.protagonista.vidaMax);


            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.SetCursorPosition(posX, posY + 15);
            //Console.Write("Pos: ".PadRight(9) + $"{Partida.protagonista.x}".PadLeft(3) + " / " + $"{Partida.protagonista.y}".PadLeft(3));
            //Console.SetCursorPosition(posX, posY + 16);
            //Console.Write("Pre: ".PadRight(9) + $"{Partida.protagonista.preX}".PadLeft(3) + " / " + $"{Partida.protagonista.preY}".PadLeft(3));
            //Console.SetCursorPosition(posX, posY + 17);
            //Console.Write("Terreno:".PadRight(9) + $"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".Substring($"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".LastIndexOf('.') + 1).PadLeft(9));
            //Console.SetCursorPosition(posX, posY + 18);
            //Console.Write("Ves:".PadRight(9) + $"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".Substring($"{Mapa.GetSala(Partida.protagonista.salaActual).GetCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".LastIndexOf('.') + 1).PadLeft(9));

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(posX, posY + 20);
            Console.Write("CONTROLES:");
            Console.SetCursorPosition(posX, posY + 21);
            Console.Write("Flechas/WASD:".PadRight(13) + "MOVER".PadLeft(6));
            Console.SetCursorPosition(posX, posY + 22);
            Console.Write("Espacio:".PadRight(9) + "ATACAR".PadLeft(10));
            Console.SetCursorPosition(posX, posY + 23);
            Console.Write("C:".PadRight(9) + "ESPECIAL".PadLeft(10));
            Console.SetCursorPosition(posX, posY + 24);
            Console.Write("E:".PadRight(9) + "EXAMINAR".PadLeft(10));
            Console.SetCursorPosition(posX, posY + 25);
            Console.Write("Q:".PadRight(9) + "OBJETOS".PadLeft(10));
            Console.SetCursorPosition(posX, posY + 26);
            Console.Write("Esc:".PadRight(9) + "PAUSA".PadLeft(10));

            Vision();
        }
        static public void Escribe(string nombre, string frase)
        {
            // Los strings se recortan para que tengan un máximo de 120 caracteres (una línea de ancho de la consola) o 240 caracteres (dos líneas)
            BorraInfo(360);
            nombrePersonaje = nombre.Substring(0, Math.Min(nombre.Length, 120));
            frasePersonaje = frase.Substring(0, Math.Min(frase.Length, 240));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 27);

            for (int i = 0; i < nombrePersonaje.Length; i++)
            {
                Console.Write(nombrePersonaje[i]);
                Thread.Sleep(20);
            }
            Console.Write(":");
            Console.WriteLine();
            for (int i = 0; i < frasePersonaje.Length; i++)
            {
                Console.Write(frasePersonaje[i]);
                Thread.Sleep(15);
            }
            Console.ReadKey(true);
            BorraInfo(360);
            frasePersonaje = "";
            nombrePersonaje = "";
        }
        static void Vision()
        {
            Console.SetCursorPosition(0, 27);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Ves:");
            Console.WriteLine(Partida.protagonista.Ve().PadRight(40));
        }
        static void BorraInfo(int longitud)
        {
            Console.SetCursorPosition(0, 27);
            for (int i = 0; i < longitud; i++)
            {
                Console.Write(" ");
            }
        }
        public static void LimpiaPantalla()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }
    }
}
