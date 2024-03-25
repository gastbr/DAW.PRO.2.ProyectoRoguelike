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
            tecla = Console.ReadKey(true).Key;
            mueve(tecla);
            interactua(tecla);
        }
        static void mueve(ConsoleKey tecla)
        {
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Partida.protagonista.camina(Entidad.Direccion.abajo);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Partida.protagonista.camina(Entidad.Direccion.arriba);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    Partida.protagonista.camina(Entidad.Direccion.izquierda);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Partida.protagonista.camina(Entidad.Direccion.derecha);
                    break;
            }
        }
        static void interactua(ConsoleKey tecla)
        {

        }
        static void abreInventario() { }
        static void abandonaPartida() { }
    }
}
