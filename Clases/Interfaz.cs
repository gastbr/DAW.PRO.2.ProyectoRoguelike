using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Interfaz
    {
        static string infoArriba = "infoarriba";
        static string infoAbajo = "infoabajo";
        static int posX = 97;
        static int posY = 1;
        public static void dibujaHUD()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(posX, posY);
            Console.Write(Partida.protagonista.getNombre() + " (" + Partida.protagonista.getProfesion() + ")");
            Console.SetCursorPosition(posX, posY + 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (Partida.protagonista.getSalaActual() == 0)
            {
                Console.Write("PISO ACTUAL:\t" + "PB".ToString().PadLeft(3));
            }
            else
            {
                Console.Write("PISO ACTUAL:\t" + Partida.protagonista.getSalaActual().ToString().PadLeft(3));
            }
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("ORO:\t\t" + Partida.protagonista.getOro().ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("NIVEL:\t\t" + Partida.protagonista.getNivel().ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("EXP:\t\t" + Partida.protagonista.getExperiencia().ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("ATQ:\t\t" + Partida.protagonista.getAtaque().ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("DEF:\t\t" + Partida.protagonista.getDefensa().ToString().PadLeft(3));
            Console.SetCursorPosition(posX, posY + 9);
            Console.Write("HP:\t ");
            if (Partida.protagonista.getVidaActual() < Partida.protagonista.getVidaMax() * 0.3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Partida.protagonista.getVidaActual().ToString().PadLeft(3));
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Partida.protagonista.getVidaActual().ToString().PadLeft(3));
            }
            Console.Write("  /  " + Partida.protagonista.getVidaMax());
            Console.SetCursorPosition(posX, posY + 22);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("CONTROLES:");
            Console.SetCursorPosition(posX, posY + 23);
            Console.Write("←↑→↓:".PadRight(9) + "MOVER".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 24);
            Console.Write("Shift:".PadRight(9) + "EXAMINAR".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 25);
            Console.Write("Enter:".PadRight(9) + "OBJETOS".PadLeft(9));
            Console.SetCursorPosition(posX, posY + 26);
            Console.Write("Esc:".PadRight(9) + "OPCIONES".PadLeft(9));
        }
        public static void dibujaEntidades()
        {
            Partida.protagonista.dibuja();
        }
        static public void setInfoArriba(string info) { infoArriba = info; }
        static public string getInfoArriba() { return infoArriba; }
        static public void dibujaInfoAbajo()
        {
            Console.SetCursorPosition(0, 28);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < infoAbajo.Length; i++)
            {
                Console.Write(infoAbajo[i]);
                Thread.Sleep(20);
            }
        }
        static public void setInfoAbajo(string info) { infoAbajo = info; }
        static public string getInfoAbajo() { return infoAbajo; }
        static public void dibujaInfoArriba()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < infoArriba.Length; i++)
            {
                Console.Write(infoArriba[i]);
                Thread.Sleep(20);
            }
        }
    }
}
