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
            switch (direccion)
            {
                case Direccion.arriba: y--; break;
                case Direccion.abajo: y++; break;
                case Direccion.izquierda: x--; break;
                case Direccion.derecha: x++; break;
            }
        }
        public void spawn(int x, int y)
        {
            setX(x);
            setY(y);
            dibuja();
        }
        public string getNombre() { return nombre; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public int getX() { return x; }
        public void setX(int x) { this.x = x; }
        public int getY() { return y; }
        public void setY(int y) { this.y = y; }
        public int getSalaActual() { return salaActual; }
        public void setSalaActual(int sala) { this.salaActual = sala; }
        public Profesion getProfesion() { return profesion; }
        public void setProfesion(Profesion profesion) { this.profesion = profesion; }
        public Direccion getDireccion() { return direccion; }
        public void setDireccion(Direccion direccion) { this.direccion = direccion; }
        public int getOro() { return oro; }
        public void setOro(int oro) { this.oro = oro; }
        public int getNivel() { return nivel; }
        public void setNivel(int nivel) { this.nivel = nivel; }
        public int getExperiencia() { return experiencia; }
        public void setExperiencia(int exp) { experiencia = exp; }
        public int getVidaActual() { return vidaActual; }
        public void setVidaActual(int vida) { this.vidaActual = vida; }
        public int getVidaMax() { return vidaMax; }
        public void setVidaMax(int vida) { this.vidaMax = vida; }
        public int getAtaque() { return ataque; }
        public void setAtaque(int ataque) { this.ataque = ataque; }
        public int getDefensa() { return defensa; }
        public void setDefensa(int defensa) { this.defensa = defensa; }
        public Objeto getInventario(int index) { return inventario[index]; }
        public void addInventario(Objeto objeto) { inventario.Add(objeto); }
        public void rmInventario(int index) { inventario.RemoveAt(index); }
    }
}
