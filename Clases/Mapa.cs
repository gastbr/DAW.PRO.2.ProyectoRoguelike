using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Mapa
    {
        static List<Sala> salas = new List<Sala>();
        public static bool dropMono = false;
        public static bool dropDefensa = false;
        public static bool dropAtaque = false;

        static public void DibujaEntidades()
        {
            if (salas[Partida.protagonista.salaActual].GetPNJ().spawneado)
            {
                salas[Partida.protagonista.salaActual].GetPNJ().Dibuja();
            }

            if (salas[Partida.protagonista.salaActual].GetTienda().spawneado)
            {
                salas[Partida.protagonista.salaActual].GetTienda().Dibuja();
            }

            for (int i = 0; i < salas[Partida.protagonista.salaActual].GetEnemigos().Count; i++)
            {
                DibujaEntidadMovil(salas[Partida.protagonista.salaActual].GetEnemigos()[i]);
            }

            for (int i = 0; i < salas[Partida.protagonista.salaActual].GetObjetos().Count; i++)
            {
                salas[Partida.protagonista.salaActual].GetObjetos()[i].Dibuja();
            }

            DibujaEntidadMovil(Partida.protagonista);
        }
        static void DibujaEntidadMovil(Entidad personaje)
        {
            salas[personaje.salaActual].GetCelda(personaje.preX, personaje.preY).Dibuja();
            personaje.Dibuja();
        }
        static public void addSala()
        {
            salas.Add(new Sala(salas.Count()+10));
        }
        static public Sala GetSala(int index)
        {
            return salas[index];
        }
    }
}