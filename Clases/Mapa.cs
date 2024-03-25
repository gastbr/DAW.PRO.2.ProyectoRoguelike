using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal static class Mapa
    {
        static List<Sala> salas = new List<Sala>();
        static public void dibujaEntidadMovil(Entidad personaje)
        {
            salas[personaje.salaActual].getCelda(personaje.preX, personaje.preY).dibuja();
            personaje.dibuja();
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