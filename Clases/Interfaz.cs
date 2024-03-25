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
        static string info = "infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo infoabajo ";
        static int posX = 97;
        static int posY = 0;
        public static void dibujaHUD()
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(posX, posY + 15);
            Console.Write("Pos: " + $"{Partida.protagonista.x}".PadLeft(3) + " / " + $"{Partida.protagonista.y}".PadLeft(3));
            Console.SetCursorPosition(posX, posY + 16);
            Console.Write("Pre :" + $"{Partida.protagonista.preX}".PadLeft(3) + " / " + $"{Partida.protagonista.preY}".PadLeft(3));
            Console.SetCursorPosition(posX, posY + 17);
            Console.Write("Celda: " + $"{Mapa.getSala(Partida.protagonista.salaActual).getCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".Substring($"{Mapa.getSala(Partida.protagonista.salaActual).getCelda(Partida.protagonista.x, Partida.protagonista.y).GetType()}".LastIndexOf('.') + 1).PadLeft(7));
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
        public static void dibujaEntidades()
        {
            Mapa.dibujaEntidadMovil(Partida.protagonista);
        }
        static public void dibujaInfo(string texto)
        {
            info = texto.Substring(0,360);
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
        static public void setInfo(string info) { Interfaz.info = info; }
        static public string getInfo() { return info; }
    }
}
