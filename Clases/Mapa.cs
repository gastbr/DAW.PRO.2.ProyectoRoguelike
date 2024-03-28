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

        static public void AddSala()
        {
            salas.Add(new Sala(salas.Count));
        }
        static public Sala GetSala(int index)
        {
            return salas[index];
        }
        static public void SiguienteSala()
        {
            if (Partida.protagonista.salaActual == salas.Count - 1)
            {
                AddSala();
            }
            salas[Partida.protagonista.salaActual + 1].DibujaSala();
        }
        static public void SalaAnterior()
        {
            salas[Partida.protagonista.salaActual - 1].DibujaSala();
        }
        static public void BorrarMapa()
        {
            salas.Clear();
        }
    }
}