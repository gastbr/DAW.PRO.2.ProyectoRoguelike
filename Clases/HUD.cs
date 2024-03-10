using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class HUD
    {
        static string infoArriba = "MISIÓN: Encuentra el mono de Jade antes de que cambie la fase de la luna o te crecerán pelos dentro del ombligo.";
        static string infoAbajo = "MANOLITO, EL DE LA TIENDA: \"Como me toques una sola poti te reviento la puta cabeza, cara de orco malnacido.\"";
        public static void dibuja()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(infoArriba);
            Console.SetCursorPosition(0, 28);
            Console.WriteLine(infoAbajo);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine();
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
            Console.WriteLine("Exp:\t\t" + Partida.protagonista.getExperiencia().ToString().PadLeft(3));
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
        static public void setInfoArriba(string info) { infoArriba = info; }
        static public string getInfoArriba() { return infoArriba; }
        static public void setInfoAbajo(string info) { infoAbajo = info; }
        static public string getInfoAbajo() { return infoAbajo; }
    }
}
