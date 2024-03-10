using DAW.PRO._2.ProyectoRoguelike.SubC_Celda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal class Sala
    {
        int ancho;
        int alto;
        List<Objeto> objetos;
        List<Entidad> entidades;
        Celda[,] celdas;
        public Sala()
        {
            this.ancho = 100;
            this.alto = 27;
            celdas = new Celda[ancho, alto]; // Poner un tamaño fijo acorde a la ventana de la consola
            generaSala();
        }
        public void dibuja()
        {
            int posX = 20;
            int posY = 1;
            for (int i = 0; i < alto; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i].dibuja();
                }
            }
        }
        void generaSala()
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i] = new Muro();
                }
            }
        }
        void tiraMuro()
        {

        }
    }
}
