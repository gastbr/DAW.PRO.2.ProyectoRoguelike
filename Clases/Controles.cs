using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Controles
    {
        static ConsoleKey tecla;
        static public void detectaTecla()
        {
            tecla = Console.ReadKey().Key;
            mueve(tecla);
        }
        static public void abandonaPartida() { }
        public static void abreInventario() { }
        static public void mueve(ConsoleKey tecla)
        {
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    Partida.protagonista.setY(Partida.protagonista.getY() + 1); break;
                case ConsoleKey.UpArrow:
                    Partida.protagonista.setY(Partida.protagonista.getY() - 1); break;
                case ConsoleKey.LeftArrow:
                    Partida.protagonista.setX(Partida.protagonista.getX() - 1); break;
                case ConsoleKey.RightArrow:
                    Partida.protagonista.setX(Partida.protagonista.getX() + 1); break;
            }
        }
    }
}
