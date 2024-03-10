using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW.PRO._2.ProyectoRoguelike.Clases
{
    internal abstract class Objeto
    {
        public int valor;
        public int efecto;
        public void aplicar(Jugador jugador, int stat)
        {
            // aplicar el efecto (+vida, +fuerza o +defensa) a la stat correspondiente del jugador correspondiente
        }
        public int getValor() { return valor; }
        public void setValor(int valor) { this.valor = valor; }
        public int getEfecto() { return efecto; }
        public void setEfecto(int efecto) { this.efecto = efecto; }
    }
}
