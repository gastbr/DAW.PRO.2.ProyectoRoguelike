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

        static public void addSala() { salas.Add(new Sala()); }
        static public Sala getSala(int index) { return salas[index]; }
        static public void rmSala(int index) { salas.RemoveAt(index); }
    }
}