using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal class Sala
    {
        List<Objeto> objetos;
        List<Entidad> entidades;
        Celda[,] celdas;
        public Sala()
        {
            celdas = new Celda[,] { }; //Poner un tamaño fijo acorde a la ventana de la consola
        }
        public void dibuja() { }
        public void generaMapa() { } // Random Walker
    }
}
