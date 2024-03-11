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
        public static void dibujaHUD()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(Partida.protagonista.getNombre() + " (" + Partida.protagonista.getProfesion() + ")");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            if (Partida.protagonista.getSalaActual() == 0)
            {
                Console.WriteLine("PISO ACTUAL:\t" + "PB".ToString().PadLeft(3));
            }
            else
            {
                Console.WriteLine("PISO ACTUAL:\t" + Partida.protagonista.getSalaActual().ToString().PadLeft(3));
            }
            Console.WriteLine("ORO:\t\t" + Partida.protagonista.getOro().ToString().PadLeft(3));
            Console.WriteLine("NIVEL:\t\t" + Partida.protagonista.getNivel().ToString().PadLeft(3));
            Console.WriteLine("EXP:\t\t" + Partida.protagonista.getExperiencia().ToString().PadLeft(3));
            Console.WriteLine();
            Console.WriteLine("ATQ:\t\t" + Partida.protagonista.getAtaque().ToString().PadLeft(3));
            Console.WriteLine("DEF:\t\t" + Partida.protagonista.getDefensa().ToString().PadLeft(3));
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
            Console.WriteLine("  /  " + Partida.protagonista.getVidaMax());
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("CONTROLES:");
            Console.WriteLine("Flechas:" + "MOVER".PadLeft(11));
            Console.WriteLine("Shift:\t" + "INTERACTUAR".PadLeft(11));
            Console.WriteLine("Enter:\t" + "INVENTARIO".PadLeft(11));
            Console.WriteLine("Esc:\t" + "OPCIONES".PadLeft(11));
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
