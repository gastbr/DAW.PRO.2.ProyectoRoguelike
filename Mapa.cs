using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike
{
    internal class Mapa
    {
        int ancho;
        int alto;
        Celda[,] celdas;
        public Mapa(int ancho, int alto) {
            this.ancho = ancho;
            this.alto = alto;
            celdas = new Celda[ancho,alto];
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    celdas[j, i] = new Celda();
                }
            }
            RandomWalker(100);
        }

        public void Dibuja() {
            Console.Clear();
            for (int i = 0; i < alto; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ancho; j++)
                {
                    // El +25 en la J hace que el mapa se empiece a dibujar 25 caracteres a la derecha, dejando espacio para la interfaz
                    Console.SetCursorPosition(j+25, i);
                    celdas[j, i].Dibuja();
                }
            }

        }

        public void RandomWalker(int porcentajeSuelo)
        {
            // La función recibe como parámetro el porcentaje de suelo que se busca, basado en el ancho y alto del mapa Con ese porcentaje, se calcula la cantidad de baldosas de suelo que se crearán. De esta forma, no hace falta tener en cuenta el ancho y alto del mapa para establecer la cantidad de suelo que queremos.
            int cantidadSuelo = (ancho * alto) * (porcentajeSuelo / 100);

        }
    }
}
