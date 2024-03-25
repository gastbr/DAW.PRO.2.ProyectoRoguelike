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
        public int x;
        public int y;
        public bool spawneado = false;
        public void Spawn(int x, int y)
        {
            this.x = x;
            this.y = y;
            spawneado = true;
        }
        public void Aplicar(Entidad jugador, int stat)
        {
            // aplicar el efecto (+vida, +fuerza o +defensa) a la stat correspondiente del jugador correspondiente
        }
    }
}
