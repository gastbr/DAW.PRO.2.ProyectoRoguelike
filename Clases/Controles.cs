﻿using DAW.PRO._2.ProyectoRoguelike.SubC_Entidad;
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
                    Partida.protagonista.camina(Entidad.Direccion.abajo);
                    break;
                case ConsoleKey.UpArrow:
                    Partida.protagonista.camina(Entidad.Direccion.arriba);
                    break;
                case ConsoleKey.LeftArrow:
                    Partida.protagonista.camina(Entidad.Direccion.izquierda);
                    break;
                case ConsoleKey.RightArrow:
                    Partida.protagonista.camina(Entidad.Direccion.derecha);
                    break;
            }
        }
    }
}
