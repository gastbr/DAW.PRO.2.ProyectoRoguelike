using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Entidad
    {
        public string nombre;
        public int x;
        public int y;
        public int preX;
        public int preY;
        public bool spawneado;
        public int salaActual;
        public enum Profesion { Guerrero, Mago, Picaro, PNJ, Tienda };
        public Profesion profesion;
        public enum Direccion { arriba, abajo, izquierda, derecha };
        public Direccion direccion;
        public int oro;
        public int nivel;
        public int experiencia;
        public int vidaActual;
        public int vidaMax;
        public int ataque;
        public int defensa;
        public List<Objeto> inventario;
        public Objeto arma;
        public Objeto armadura;
        public abstract void dibuja();
        public void camina(Direccion direccion)
        {
            this.direccion = direccion;
            preX = x;
            preY = y;
            Mapa.getSala(salaActual).getCelda(x, y).ocupada = false;
            switch (direccion)
            {
                case Direccion.arriba: y--; break;
                case Direccion.abajo: y++; break;
                case Direccion.izquierda: x--; break;
                case Direccion.derecha: x++; break;
            }
            Mapa.getSala(salaActual).getCelda(x, y).ocupada = true;

        }
        public void spawn(int x, int y)
        {
            this.x = x;
            this.y = y;
            preX = x;
            preY = y;
            spawneado = true;
        }
    }
}
