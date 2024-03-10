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
        static public ConsoleKey detectaTecla()
        {
            tecla = Console.ReadKey().Key;
            return tecla;
        }
        static public void abandonaPartida() {}
        public static void abreInventario(Entidad jugador) { }
        static public void mueve(Entidad jugador) { }
    }
}
