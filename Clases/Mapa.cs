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

        static public void dibujaEntidadMovil(Entidad personaje)
        {
            salas[personaje.salaActual].GetCelda(personaje.preX, personaje.preY).Dibuja();
            personaje.Dibuja();
        }
        static public void addSala()
        {
            salas.Add(new Sala(salas.Count()));
        }
        static public Sala getSala(int index)
        {
            return salas[index];
        }
    }
}